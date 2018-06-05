open System

type Customer = { Name: string }
type Account = { CurrentBalance: decimal; Id: Guid; Customer: Customer }

let account = {
    CurrentBalance = 395.45M
    Id = Guid.NewGuid()
    Customer = { Name = "Chuck Norris" }
}

let deposit (amount:decimal) (account:Account) : Account =
    { account with 
        CurrentBalance = account.CurrentBalance + amount }

let withdraw (amount:decimal) (account:Account) : Account =
    if (account.CurrentBalance < amount) then account
    else { account with
            CurrentBalance = account.CurrentBalance - amount }

let fileSystemAudit account message =
    let path = sprintf @"C:\tmp\%s\%s.txt" account.Customer.Name (account.Id.ToString())
    System.IO.File.AppendAllText(path, message)

let consoleAudit account message =
    printfn "Account %s: %s" (account.Id.ToString()) message

let auditAs operationName audit operation amount account =
    let modifiedAccount = operation amount account
    if (account.CurrentBalance = modifiedAccount.CurrentBalance) then
        audit account "Transaction rejected"
    else
        let message = sprintf "%s $%M" operationName amount
        audit account message
    
    modifiedAccount

let withdrawWithConsoleAudit = auditAs "withdraw" consoleAudit withdraw
let depositWithConsoleAudit = auditAs "deposit" consoleAudit deposit

// withdraw / deposit tests
account |> deposit 5M |> withdraw 5M |> withdraw 600M

// audit tests
consoleAudit account "Testing console audit"

account |> depositWithConsoleAudit 30M |> withdrawWithConsoleAudit 20M |> withdrawWithConsoleAudit 1000M