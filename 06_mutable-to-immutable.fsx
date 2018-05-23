// mutable version
(*
let mutable petrol = 100.0

let drive(distance) = 
    if distance = "far" then petrol <- petrol / 2.0
    elif distance = "medium" then petrol <- petrol - 10.0
    else petrol <- petrol - 1.0
   
drive("far")
drive("medium")
drive("short")

petrol
*)

// unmutable version
let drive(petrol, distance) = 
    if distance = "far" then petrol / 2.0
    elif distance = "medium" then petrol - 10.0
    else petrol - 1.0

let petrol = 100.0
let firstState = drive(petrol, "far")
let secondState = drive(firstState, "medium")
let finalState = drive(secondState, "short")