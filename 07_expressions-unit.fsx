open System

let describeAge age =
    let ageDescription =
        if age < 18 then "Child!"
        elif age < 65 then "Adult!"
        else "OAP!"
    let greeting = "Hello"
    Console.WriteLine("{0}! You're a '{1}'.", greeting, ageDescription)

let aUnit = ()

// unit is not a real BLC object -> this will throw a null reference exception
aUnit.GetHashCode()

let age = describeAge 99 // functions without returning a result will always return 'unit'