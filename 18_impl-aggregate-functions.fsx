let inputs = [ 1 .. 5 ]

let sum inputs =
    let mutable accumulator = 0
    for input in inputs do
        accumulator <- accumulator + input
    accumulator

let length inputs =
    let mutable accumulator = 0
    for input in inputs do
        accumulator <- accumulator + 1
    accumulator

let max inputs =
    let mutable accumulator = 0
    for input in inputs do
        if (input > accumulator) then
            accumulator <- input
    accumulator    

sum inputs
length inputs
max inputs