open System
open NuGet

[<EntryPoint>]
let main argv =
    //let details = "nunit" |> getDetailsForCurrentVersion
    let details = "Newtonsoft.Json" |> getDetailsForCurrentVersion
    0 // return an integer exit code
