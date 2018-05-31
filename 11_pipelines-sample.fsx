let drive distance petrol =
    if distance = "far" then petrol / 2.0
    elif distance = "medium" then petrol - 10.0
    else petrol - 1.0

(* the old way
let petrol = 100.0
let firstState = drive(petrol, "far")
let secondState = drive(firstState, "medium")
let finalState = drive(secondState, "short")
*)

let petrol = 100.0
petrol 
|> drive "far" 
|> drive "medium" 
|> drive "short"