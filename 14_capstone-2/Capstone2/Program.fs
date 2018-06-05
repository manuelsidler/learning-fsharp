// Learn more about F# at http://fsharp.org
module Capstone2.Program

open System
open Capstone2.Domain
open Capstone2.Operations

[<EntryPoint>]
let main argv =
    let mutable account =
        let customer = 
            Console.WriteLine "Please enter your name: "
            let customerName = Console.ReadLine()
            { Name = customerName }

        Console.WriteLine "Please enter your balance: "
        let balance = Console.ReadLine() |> Decimal.Parse
        { Id = Guid.NewGuid()
          Customer = customer
          CurrentBalance = balance }

    let withdrawWithAudit = withdraw |> auditAs "withdraw" Auditing.console
    let depositWithAudit = deposit |> auditAs "deposit" Auditing.console

    while true do
        let action =
            Console.WriteLine()
            printfn "Current balance is $%M" account.CurrentBalance
            Console.WriteLine "(d)eposit, (w)ithdraw, e(x)it"
            Console.ReadLine()
        
        if action = "x" then Environment.Exit 0

        let amount = 
            Console.WriteLine "Amount: "
            Console.ReadLine() |> Decimal.Parse

        account <-
            if action = "d" then account |> depositWithAudit amount
            elif action = "w" then account |> withdrawWithAudit amount
            else account

    0