// Learn more about F# at http://fsharp.org

open System
open Domain
open Operations

[<EntryPoint>]
let main argv =
    let customer = { FirstName = "Chuck"; LastName = "Norris"; Age = 50 }
    if customer |> isOlderThan 18 then printfn "%s is an adult" customer.FirstName
    else printf "%s is a child." customer.FirstName
    0 // return an integer exit code
    
