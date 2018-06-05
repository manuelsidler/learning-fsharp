#load "Domain.fs"
#load "Operations.fs"
#load "Auditing.fs"

open Capstone2.Operations
open Capstone2.Domain
open Capstone2.Auditing
open System

let withdraw = withdraw |> auditAs "withdraw" console
let deposit = deposit |> auditAs "deposit" console

let customer = { Name = "Chuck" }
let account = { Id = Guid.NewGuid(); Customer = customer; CurrentBalance = 30M }

account
|> withdraw 10M
|> deposit 20M
|> withdraw 15M
|> withdraw 10M
|> deposit 100M