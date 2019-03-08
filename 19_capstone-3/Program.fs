module Capstone3.Program

open System
open Capstone3.Domain
open Capstone3.Operations

let withdrawWithAudit = auditAs 'w' Auditing.composedLogger withdraw
let depositWithAudit = auditAs 'd' Auditing.composedLogger deposit
let loadAccountFromDisk = FileRepository.findTransactionsOnDisk >> Operations.loadAccount


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
    if command = 'd' then account |> depositWithAudit amount
    elif command = 'w' then account |> withdrawWithAudit amount
    else account

[<EntryPoint>]
let main _ =
    let openingAccount =
        Console.WriteLine "Please enter your name: "
        Console.ReadLine() |> loadAccountFromDisk

    let consoleCommands = seq {
        while true do
            Console.WriteLine()
            Console.Write "(d)eposit, (w)ithdraw or e(x)it: "
            yield Console.ReadKey().KeyChar 
        }

    let getAmountConsole command =
        Console.WriteLine "Insert amount: "
        command, Console.ReadLine() |> Decimal.Parse

    let closingAccount =
        consoleCommands
        |> Seq.filter isValidCommand
        |> Seq.takeWhile (not << isStopCommand)
        |> Seq.map getAmountConsole
        |> Seq.fold processCommand openingAccount

    Console.Clear()
    printfn "Closing Balance:\r\n %A" closingAccount
    Console.ReadKey() |> ignore

    0