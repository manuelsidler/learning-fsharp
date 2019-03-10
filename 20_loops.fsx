// upward-counting
for number in 1 .. 10 do
    printfn "%d Hello!" number
   
// downward-counting
for number in 10 .. -2 .. 0 do
    printfn "%d Hello!" number

// for-each
let orderIds = [ 10001 .. 10101 ]
for orderId in orderIds do
    printfn "Order ID: %d" orderId

// while
let mutable i = 5
while i <> 0 do
    printfn "i: %d" i
    i <- i - 1