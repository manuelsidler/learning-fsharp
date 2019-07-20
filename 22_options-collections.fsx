let tryLoadCustomer customerId =
    Some customerId
    |> Option.filter(fun x -> x >= 2 && x <= 7)
    |> Option.map(fun x -> sprintf "Customer %i" x)

let customerIds = [ 0 .. 10 ]
customerIds |> List.choose tryLoadCustomer // choose is map and filter in one
