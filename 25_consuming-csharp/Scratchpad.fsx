#r @"CSharpProject/bin/Debug/netstandard2.0/CSharpProject.dll"

open CSharpProject
open System
open System.Collections.Generic

// consuming C# objects and methods
let manuel = Person "Manuel"
manuel.PrintName()

// constructors as functions
let people =
    [ "Manuel"; "Christine"; "Sarah" ]
    |> List.map Person

people |> List.iter (fun p -> p.PrintName())

// interfaces
type PersonComparer() =
    interface IComparer<Person> with
        member this.Compare(x, y) = x.Name.CompareTo(y.Name)

let personComparer = PersonComparer() :> IComparer<Person>
personComparer.Compare(manuel, Person "Michael")
personComparer.Compare(manuel, Person "Manuel")

// object expressions
let pComparer = 
    { new IComparer<Person> with
        member this.Compare(x, y) = x.Name.CompareTo(y.Name) }

// Nulls, nullables and options
let blank:string = null
let name = "Mona"
let number = Nullable 10

let blankAsOption = blank |> Option.ofObj // Null maps to None
let nameAsOption = name |> Option.ofObj // Non-null maps to Some
let numberAsOption = number |> Option.ofNullable
let unsafeName = Some "Fred" |> Option.toObj // Map options back to classes or nullable types