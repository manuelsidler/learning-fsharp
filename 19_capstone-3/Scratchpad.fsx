#load "Domain.fs"
#load "Operations.fs"

open Capstone3.Operations
open Capstone3.Domain
open System

let isValidCommand command =
    let validCommands = [ 'd'; 'w'; 'x' ]
    validCommands |> List.exists(fun c -> c = command)

let isStopCommand command =
    command = 'x'

let getAmount command =
    if command = 'd' then (command, 50M)
    elif command = 'w' then (command, 25M)
    else (command, 0M)

let processCommand (account) (command, amount) =
    if command = 'd' then account |> deposit amount
    elif command = 'w' then account |> withdraw amount
    else account
    
let openingAccount =
    { Owner = { Name = "Manuel" }; Balance = 0M; AccountId = Guid.Empty }

let account =
    let commands = [ 'd'; 'w'; 'z'; 'f'; 'd'; 'x'; 'w' ]

    commands
    |> Seq.filter isValidCommand
    |> Seq.takeWhile (not << isStopCommand)
    |> Seq.map getAmount
    |> Seq.fold processCommand openingAccount

let transactions =
    [ { Transaction.Successful = false; Timestamp = DateTime.MinValue; Command = 'w'; Amount = 10M }
      { Transaction.Successful = true; Timestamp = DateTime.MinValue.AddSeconds 10.; Command = 'w'; Amount = 10M }
      { Transaction.Successful = true; Timestamp = DateTime.MinValue.AddSeconds 30.; Command = 'd'; Amount = 50M }
      { Transaction.Successful = true; Timestamp = DateTime.MinValue.AddSeconds 50.; Command = 'w'; Amount = 10M } ]

let loadAccount (owner, accountId, transactions) =
    let openingAccount = { AccountId = accountId; Balance = 0M; Owner = { Name = owner } }

    transactions
    |> Seq.sortBy(fun t -> t.Timestamp)
    |> Seq.fold(fun account transaction ->
        if transaction.Command = 'w' then account |> withdraw transaction.Amount
        else account |> deposit transaction.Amount)
        openingAccount

let loadedAccount = loadAccount("Manu", Guid.Empty, transactions)