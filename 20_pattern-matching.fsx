// classic ugly if-else branching
let limitUgly score years =
    if score = "medium" && years = 1 then 500
    elif score = "good" && (years = 0 || years = 1) then 750
    elif score = "good" && years = 2 then 1000
    elif score = "good" then 2000
    else 250

// pattern matching magic
let limit customer =
    match customer with
    | "medium", 1 -> 500
    | "good", 0 | "good", 1 -> 750
    | "good", 2 -> 1000
    | "good", _ -> 2000
    | _ -> 250

limit ("good", 3)