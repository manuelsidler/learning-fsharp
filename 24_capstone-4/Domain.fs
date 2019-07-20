namespace Capstone4.Domain

open System

type BankOperation = Deposit | Withdraw
type Customer = { Name : string }
type Account = { AccountId : Guid; Owner : Customer; Balance : decimal }
type CreditAccount = CreditAccount of Account // marker type for an account in credit
type RatedAccount = // Categorization of account
    | InCredit of CreditAccount
    | Overdrawn of Account
type Transaction = { Timestamp : DateTime; Operation : string; Amount : decimal }

module Transactions =
    /// Serializes a transaction
    let serialize transaction =
        sprintf "%O***%s***%M***%b" transaction.Timestamp transaction.Operation transaction.Amount
    
    /// Deserializes a transaction
    let deserialize (fileContents:string) =
        let parts = fileContents.Split([|"***"|], StringSplitOptions.None)
        { Timestamp = DateTime.Parse parts.[0]
          Operation = parts.[1]
          Amount = Decimal.Parse parts.[2] }