open System.Collections.Generic

// F# infers type based on first value added
let numbers = List<_>() // alternative syntax: let numbers = List()
numbers.Add(1)
numbers.Add(1)

// won't compile
let numbers2 = List<_>()
numbers2.Add(1)
numbers2.Add("hi")

// whole function is generic!
let createList(first, second) =
    let output = List<_>()
    output.Add(first)
    output.Add(second)
    output