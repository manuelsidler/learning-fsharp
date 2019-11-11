module Tests

open System
open FsCheck
open FsCheck.Xunit

let sumsNumbers (numbers:int list) =
    match numbers with
    | numbers when numbers |> List.contains 5 -> -1
    | numbers -> numbers |> List.sum

[<Property(Verbose = true)>]
let ``Correctly adds numbers`` numbers =
    let actual = numbers |> sumsNumbers
    actual = List.sum numbers

let flipCase (text:string) =
    text.ToCharArray()
    |> Array.map(fun c ->
        if Char.IsUpper c then Char.ToLower c
        else Char.ToUpper c)
    |> String

[<Property>]
let ``Always has same number of letters with Guard Clause`` (input:string) =
    input <> null ==> lazy // run the code on the right only if the guard clause on the left passes
        let output = input |> flipCase
        input.Length = output.Length

type LettersOnlyGenerator() =
    static member Letters() =
        Arb.Default.Char() |> Arb.filter Char.IsLetter

[<Property(Verbose = true, Arbitrary = [| typeof<LettersOnlyGenerator> |])>]
let ``Always has same number of letters`` (input:string) =
    let output = input |> flipCase
    input.Length = output.Length