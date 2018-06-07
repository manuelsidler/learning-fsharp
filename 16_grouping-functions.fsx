type Person = { Name : string; Town : string }
let people = [ 
    { Name = "Chuck"; Town = "Zurich" }
    { Name = "Mariah"; Town = "Zurich" }
    { Name = "Peter"; Town = "Lucerne" } ]

// GROUPBY
people |> List.groupBy (fun p -> p.Town)

// COUNTBY
people |> List.countBy (fun p -> p.Town)

// PARTITION
let zurichPeople, otherPeople =
    people |> List.partition(fun p -> p.Town = "Zurich")