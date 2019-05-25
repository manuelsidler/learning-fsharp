let insertCustomer customer : Result<'T, 'TFailure> =
    Ok 5

match insertCustomer "Mark" with
    | Ok customerId -> printfn "Saved with %A" customerId
    | Error error -> printfn "Unable to save: %s" error