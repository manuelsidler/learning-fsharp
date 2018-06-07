let numbers = [ 1.0 .. 10.0 ]

let total = numbers |> List.sum
let average = numbers |> List.average
let max = numbers |> List.max
let min = numbers |> List.min
let number = numbers |> List.find (fun n -> n = 1.0) // LINQ Single
let head = numbers |> List.head // LINQ First
let numberAtIndex = numbers |> List.item 2 // LINQ ElementAt
let firstThreeNumbers = numbers |> List.truncate 3 // LINQ Take -> beware of F# trunk, will throw exception if amount does exceed list length
let exists = numbers |> List.exists (fun n -> n = 5.0) // LINQ Any
let forAll = numbers |> List.forall (fun n -> n < 20.0)
let contains = numbers |> List.contains 10.0
let filteredNumbers = numbers |> List.filter (fun n -> n < 5.0) // LINQ Where
let length = numbers |> List.length
let distinct = numbers |> List.distinct
let sortedNumbers = numbers |> List.sortByDescending (fun n -> n) // LINQ OrderBy

// converting between lists, arrays and sequences
let numberOne =
    [ 1 .. 5 ]
    |> List.toArray
    |> Seq.ofArray
    |> Seq.head