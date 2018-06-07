open System

let numbers = [ 1 .. 10 ]
let timesTwo n = n * 2

// *** MAP ***
// imperative way
let outputImperative = ResizeArray()
for number in numbers do
    outputImperative.Add (number |> timesTwo)

// functional way
let outputFunctional = numbers |> List.map timesTwo

// ITER
numbers |> List.iter(fun number -> System.Console.WriteLine(number)) // returns 'unit' -> useful for side effects

// COLLECT
type Order = { OrderId : int }
type Customer = { Orders : Order list }
let customers : Customer list = [ 
    { Orders = [ { OrderId = 1 }; { OrderId = 2 } ]}
    { Orders = [ { OrderId = 2 }; { OrderId = 3 } ]} 
    ]
let orders : Order list = customers |> List.collect(fun c -> c.Orders) // like SelectMany in C#

// PAIRWISE
[ DateTime(2010,5,1)
  DateTime(2010,6,1)
  DateTime(2010,6,12)
  DateTime(2010,7,3) ]
|> List.pairwise // results in collection with three tupled items
|> List.map(fun (a,b) -> b - a)
|> List.map(fun time -> time.TotalDays)

// WINDOWED
let someNumbers = [ 1 .. 9 ]
someNumbers |> List.windowed 3 // like pairwise but we can specify the count of elements