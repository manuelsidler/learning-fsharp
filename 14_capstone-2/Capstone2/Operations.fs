module Capstone2.Operations

open Capstone2.Domain

let deposit (amount:decimal) (account:Account) : Account =
    { account with 
        CurrentBalance = account.CurrentBalance + amount }

let withdraw (amount:decimal) (account:Account) : Account =
    if (account.CurrentBalance < amount) then account
    else { account with
            CurrentBalance = account.CurrentBalance - amount }

let auditAs operationName audit operation amount account =
    audit account (sprintf "%s $%M" operationName amount)
    let modifiedAccount = operation amount account
    if (account.CurrentBalance = modifiedAccount.CurrentBalance) then
        audit account "Transaction rejected"
    else
        audit account (sprintf "Transaction accepted. New Balance: $%M" modifiedAccount.CurrentBalance)
    
    modifiedAccount
