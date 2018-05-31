(* 
with this simple record we get:
1. constructor that requires all fields to be set
2. public read-only accessor for all fields 
3. structural equality throughout entire object graph
*)
type Car =
    { Manufacturer : string
      Engine : string
      Size : string
      NumberOfDoors : int }

let car =
    { Manufacturer = "Audi"
      Engine = "V6"
      Size = "M"
      // NumberOfDoors = 5 // all properties have to be set !
      }