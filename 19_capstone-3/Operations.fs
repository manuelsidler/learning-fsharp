module Capstone3.Operations

open System
open Capstone3.Domain

/// Withdraws an amount of an account (if there are sufficient funds)
let withdraw amount account =
    if amount > account.Balance then account
    else { account with Balance = account.Balance - amount }

/// Deposits an amount into an account
let deposit amount account =
    { account with Balance = account.Balance + amount }

/// Runs some account operation such as withdraw or deposit with auditing.
let auditAs operationName audit operation amount account =
    let updatedAccount = operation amount account

    let accountIsUnchanged = (updatedAccount = account)

    let transaction =
        let transaction = { Command = operationName; Amount = amount; Timestamp = DateTime.UtcNow; Successful = true}
        if accountIsUnchanged then { transaction with Successful = false }
        else transaction

    audit account.AccountId account.Owner.Name transaction
    updatedAccount

let loadAccount (owner, accountId, transactions) =
    let openingAccount = { AccountId = accountId; Balance = 0M; Owner = { Name = owner } }

    transactions
    |> Seq.sortBy(fun t -> t.Timestamp)
    |> Seq.fold(fun account transaction ->
        if transaction.Command = 'w' then account |> withdraw transaction.Amount
        else account |> deposit transaction.Amount)
        openingAccount