#r @"packages\FSharp.Data.SqlClient\lib\net40\FSharp.Data.SqlClient.dll"

open FSharp.Data

let [<Literal>] Conn = @"Server=(localdb)\MSSQLLocalDb;Database=AdventureWorksLT;Integrated Security=SSPI"

// *** Query data ***

type GetCustomers = SqlCommandProvider<"SELECT * FROM SalesLT.Customer WHERE CompanyName = @CompanyName", Conn>

// with a where clause
let customers = GetCustomers.Create(Conn).Execute(CompanyName = "A Bike Store") |> Seq.toArray

// without a where clause
// let customers = GetCustomers.Create(Conn).Execute() |> Seq.toArray

let customer = customers.[0]

printfn "%s %s works for %A" customer.FirstName customer.LastName customer.CompanyName

// *** Insert data ***
type AdventureWorks = SqlProgrammabilityProvider<Conn>

let productCategory = new AdventureWorks.SalesLT.Tables.ProductCategory()
productCategory.AddRow("Mittens", Some 3)
productCategory.AddRow("Long Shorts", Some 3)
productCategory.AddRow("Wooly Hats", Some 4)
productCategory.Update()

// *** Enum provider ***
type Categories = SqlEnumProvider<"SELECT Name, ProductCategoryId FROM SalesLT.ProductCategory", Conn>

// this code no longer compiles when the 'Wooly Hats' row has been deleted
let woolyHats = Categories.``Wooly Hats``
printfn "Wooly hats has ID %d" woolyHats