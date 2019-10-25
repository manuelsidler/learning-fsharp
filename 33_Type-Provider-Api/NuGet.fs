module NuGet

open FSharp.Data
open System

type PackageVersion =
    | CurrentVersion
    | PreRelease
    | Old

type VersionDetails =
    { Version : Version
      Downloads : decimal
      PackageVersion : PackageVersion
      LastUpdated : DateTime }

type NuGetPackage =
    { PackageName : string
      Versions : VersionDetails list }

type Package = HtmlProvider<"..\data\sample-package.html">

let private parse (versionText:string) =
    let getVersionPart (version:string) isCurrent =
        match version.Split '-', isCurrent with
        | [| version; _ |], true
        | [| version |], true -> Version.Parse version, CurrentVersion
        | [| version; _ |], false -> Version.Parse version, PreRelease
        | [| version |], false -> Version.Parse version, Old
        | _ -> failwith "unknown version format"

    let parts = versionText.Split ' ' |> Seq.toList |> List.rev
    match parts with
    | [] -> failwith "Must be at least two elements"
    | "version)" :: "(this" :: version :: _ -> getVersionPart version true
    | version :: _ -> getVersionPart version false

let private enrich (versionHistory:Package.VersionHistory.Row seq) = 
    { PackageName =
        match versionHistory |> Seq.map(fun row -> row.Version.Split ' ' |> Array.toList |> List.rev) |> Seq.head with
        | "version)" :: "(this" :: _ :: name | _ :: name -> List.rev name |> String.concat " "
        | _ -> failwith "Unable to parse version name"
      Versions =
        versionHistory 
        |> Seq.map(fun versionHistory ->
            let version, packageVersion = parse versionHistory.Version
            { Version = version
              Downloads = versionHistory.Downloads
              LastUpdated = versionHistory.``Last updated``
              PackageVersion = packageVersion })
        |> Seq.toList }

let private getPackage = 
    sprintf "https://www.nuget.org/packages/%s" >> Package.Load

let private getVersionsForPackage (package:Package) =
    package.Tables.``Version History``.Rows

let private loadPackageVersions =
    getPackage >> getVersionsForPackage >> enrich >> (fun x -> x.Versions)

let getDownloadsForPackage =
    loadPackageVersions >> Seq.sumBy(fun x -> x.Downloads)

let getDetailsForVersion version = 
    loadPackageVersions >> Seq.find(fun x -> x.Version = version)

let getDetailsForCurrentVersion = 
    loadPackageVersions >> Seq.find(fun x -> x.PackageVersion = CurrentVersion)