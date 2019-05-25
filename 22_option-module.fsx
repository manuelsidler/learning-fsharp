type Customer =
    {
        SafetyScore : int option
    }

// option type with pattern matching
let description customer =
    match customer.SafetyScore with
    | Some score -> printf "Score %i" score
    | None -> printf "No score provided"

// option module
let descriptionTwo customer =
    customer.SafetyScore
    |> Option.map(fun score -> printf "Score %i" score) // just acts on Some case

// filter with option module
let test1 = Some 5 |> Option.filter(fun x -> x > 5)
let test2 = Some 5 |> Option.filter(fun x -> x = 5)