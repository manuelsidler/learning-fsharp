// useful for quickly generating collections of data based on a set of numbers

open System

let arrayOfChars = [| for c in 'a' .. 'z' -> Char.ToUpper c |]
let listOfSquares = [ for i in 1 .. 10 -> i * i ]
let seqOfStrings = seq { for i in 2 .. 4 .. 20 -> sprintf "Number %d" i }