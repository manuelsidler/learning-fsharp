namespace Capstone3.Domain

open System

type Customer = { Name : string }
type Account = { AccountId : Guid; Owner : Customer; Balance : decimal }
type Transaction = { Amount: decimal; Command: char; Timestamp: DateTime; Successful: bool }

module Transactions =
    let serialize transaction =
        sprintf "%O***%c***%M***%b"
            transaction.Timestamp
            transaction.Command
            transaction.Amount
            transaction.Successful

    let deserialize (transaction:string) =
        let parts = transaction.Split([|"***"|], StringSplitOptions.None)
        { Timestamp = DateTime.Parse parts.[0]
          Command = parts.[1].[0]
          Amount = Decimal.Parse parts.[2]
          Successful = bool.Parse parts.[3] }