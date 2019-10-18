#r @"packages\SQLProvider\lib\netstandard2.0\FSharp.Data.SqlProvider.dll"

open FSharp.Data.Sql

let [<Literal>] Conn = @"Server=(localdb)\MSSQLLocalDb;Database=AdventureWorksLT;Integrated Security=SSPI"

type AdventureWorks = SqlDataProvider<ConnectionString = Conn, UseOptionTypes = true>

let context = AdventureWorks.GetDataContext()

// *** query data ***
let customers =
    query {
        for customer in context.SalesLt.Customer do
        take 10
    } |> Seq.toArray

let customer = customers.[0]

// *** insert data ***
let category = context.SalesLt.ProductCategory.Create()
category.ParentProductCategoryId <- Some 3
category.Name <- "Scarf"
context.SubmitUpdates()

// *** reference data ***
// Individuals = generate list of properties that match rows in database
let mittens =
    context.SalesLt.ProductCategory
                   .Individuals
                   .``As Name``
                   .``1, Bikes``