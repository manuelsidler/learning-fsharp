let numbers = [ 1; 2; 3; 4; 5; 6]
let numbersQuick = [ 1 .. 6]
let head :: tail = numbers // decomposing into head (int, value:1) and tail (list<int>, value:2 .. 6)
let moreNumbers = 0 :: numbers // new list with 0 at the front -> 0, 1, 2, ...
let evenMoreNumbers = moreNumbers @ [ 7 .. 9] // new list with 7 .. 9 at the end (merge two lists)
