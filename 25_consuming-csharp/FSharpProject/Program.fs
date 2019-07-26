// Learn more about F# at http://fsharp.org

open System
open CSharpProject

[<EntryPoint>]
let main argv =
    let tony = Person "Tony"
    tony.PrintName();

    0 // return an integer exit code
