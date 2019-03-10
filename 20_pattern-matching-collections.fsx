type Customer =
    {
        Balance : int
        Name: string 
    }

let customers = [
    { Balance = 5; Name = "Manu" }
    { Balance = 10; Name = "Christine" }
]

// ugly if-else
let handleCustomersUgly (customers:Customer list) =
    if customers.Length = 0 then failwith "No customers supplied"
    elif customers.Length = 1 then printfn "Customer: %s" customers.[0].Name
    elif customers.Length = 2 then printfn "Balances: %d" (customers.[0].Balance + customers.[1].Balance)
    else printfn "Customers: %i" customers.Length

customers |> handleCustomersUgly

// pattern matching ftw
// seq is not supported! only lists and arrays
let handleCustomers (customers:Customer list) =
    match customers with
    | [] -> failwith "No customers supplied"
    | [ customer ] -> printfn "Customer: %s" customer.Name
    | [ customer1; customer2 ] -> printfn "Balances: %d" (customer1.Balance + customer2.Balance)
    | customers -> printfn "Customers: %i" customers.Length

[] |> handleCustomers
[ { Balance = 20; Name = "Mike" } ] |> handleCustomers
customers |> handleCustomers