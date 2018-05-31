// ** EQUALITY **

type Address = 
    { Street : string
      ZIP : int
      City : string }

let address1 =
    { Street = "Bahnhofstr. 32"
      ZIP = 8000
      City = "Zürich" }

let address2 =
    { Street = "Bahnhofstr. 32"
      ZIP = 8000
      City = "Zürich" }

let isEquals = (address1 = address2) // true
let isEquals2 = address1.Equals(address2) // true
let referenceEquals = System.Object.ReferenceEquals(address1, address2) // false

// ** COPY-AND-UPDATE RECORD SYNTAX

type Customer =
    { Name : string
      Age : int }

let changeAge (customer : Customer) : Customer =
    let random = new System.Random()
    let updatedCustomer =
        { customer with
            Age = random.Next(18, 45) } // create new record with existing name but new age
    System.Console.WriteLine("Original Age: {0}", customer.Age)
    System.Console.WriteLine("New Age: {0}", updatedCustomer.Age)
    updatedCustomer

let customer =
    { Name = "Chuck"
      Age = 33 }
let updatedCustomer = changeAge customer