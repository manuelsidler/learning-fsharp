let inputs = [ 1 .. 5 ]

let sum inputs =
    Seq.fold
        (fun state input -> state + input)
        0
        inputs

// more readable ways with pipe and double pipe
inputs |> Seq.fold (fun state input -> state + input) 0
(0, inputs) ||> Seq.fold (fun state input -> state + input)

let length inputs =
    Seq.fold
        (fun state input -> state + 1)
        0
        inputs

let max inputs =
    Seq.fold 
        (fun state input -> 
            if (input > state) then input
            else state)
        0
        
sum inputs
length inputs
max inputs