module Capstone2.Auditing

open Capstone2.Domain

let fileSystem account message =
    let path = sprintf @"C:\tmp\%s\%s.txt" account.Customer.Name (account.Id.ToString())
    System.IO.File.AppendAllText(path, message)

let console account message =
    printfn "Account %s: %s" (account.Id.ToString()) message