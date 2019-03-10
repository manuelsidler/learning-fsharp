let getCreditLimit customer =
    match customer with
    | _, 1 -> 250
    | "medium", 1 -> 500
    | "good", 0 | "good", 1 -> 750
    | "good", years when years > 2 -> 1000 // guards
    | "good", years ->
        match years with // nested match
        | 0 | 1 -> 750
        | 2 -> 1000
        | _ -> 2000
    | "good", _ -> 2000
//    | _ -> 250

getCreditLimit ("medium", 1)
getCreditLimit ("bad", 0)
getCreditLimit ("good", 5)