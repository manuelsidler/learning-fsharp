﻿module Capstone4.Program

open System
open Capstone4.Domain
open Capstone4.Operations

let withdrawWithAudit amount (CreditAccount account as creditAccount) =
    auditAs "withdraw" Auditing.composedLogger withdraw amount creditAccount account.AccountId account.Owner
let depositWithAudit amount (ratedAccount:RatedAccount) =
    let accountId = ratedAccount.GetField (fun a -> a.AccountId)
    let owner = ratedAccount.GetField(fun a -> a.Owner)
    auditAs "deposit" Auditing.composedLogger deposit amount ratedAccount accountId owner
let tryLoadAccountFromDisk = FileRepository.tryFindTransactionsOnDisk >> Option.map Operations.loadAccount

type Command = AccountCommand of BankOperation | Exit

[<AutoOpen>]
module CommandParsing =
    let tryParseCommand cmd =
        match cmd with
        | 'd' -> Some (AccountCommand Deposit)
        | 'w' -> Some (AccountCommand Withdraw)
        | 'x' -> Some Exit
        | _ -> None

[<AutoOpen>]
module UserInput =
    let commands = seq {
        while true do
            Console.Write "(d)eposit, (w)ithdraw or e(x)it: "
            yield Console.ReadKey().KeyChar
            Console.WriteLine() }

    let tryGetAmount command =
        Console.WriteLine()
        Console.Write "Enter Amount: "
        let amount = Console.ReadLine() |> Decimal.TryParse
        match amount with
        | true, amount -> Some(command, amount)
        | false, _ -> None

[<EntryPoint>]
let main _ =
    let openingAccount =
        Console.Write "Please enter your name: "
        let owner = Console.ReadLine()
                
        match tryLoadAccountFromDisk owner with
        | Some account -> account
        | None ->
            InCredit(CreditAccount { AccountId = Guid.NewGuid()
                                     Balance = 0M
                                     Owner = { Name = owner } })
    
    printfn "Opening balance is £%M" (openingAccount.GetField(fun a -> a.Balance))

    let processCommand account (command, amount) =
        printfn ""
        let account =
            match command with
            | Deposit -> account |> depositWithAudit amount
            | Withdraw ->
                match account with
                | InCredit account -> account |> withdrawWithAudit amount
                | Overdrawn _ ->
                    printfn "You cannot withdraw funds as your account is overdrawn!"
                    account
        printfn "Current balance is £%M" (account.GetField(fun a -> a.Balance))
        match account with
        | InCredit _ -> ()
        | Overdrawn _ -> printfn "Your account is overdrawn!!"
        account

    let closingAccount =
        commands
        |> Seq.choose tryParseCommand
        |> Seq.takeWhile ((<>) Exit)
        |> Seq.choose(fun cmd ->
            match cmd with
            | Exit -> None
            | AccountCommand cmd -> Some cmd)
        |> Seq.choose tryGetAmount
        |> Seq.fold processCommand openingAccount
    
    printfn ""
    printfn "Closing Balance:\r\n %A" closingAccount
    Console.ReadKey() |> ignore

    0