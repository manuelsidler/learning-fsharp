let aNumber : int = 10

// Option<T> is a two-case DU => Some (value) or None
let maybeANumber : int option = Some 5

type Driver =
    {
        Name : string
        SafetyScore : int option
        YearPassed : int
    }

let calculate driver =
    match driver.SafetyScore with
    | Some 0 -> 250
    | Some score when score < 0 -> 400
    | Some score when score > 0 -> 150
    | None ->
        printf "No score supplied. Using temporary score."
        300

let drivers = 
    [
        { Name = "Manuel"; SafetyScore = Some 100; YearPassed = 2008 }
        { Name = "Christine"; SafetyScore = None; YearPassed = 2012 }
    ]

drivers |> List.map(calculate)