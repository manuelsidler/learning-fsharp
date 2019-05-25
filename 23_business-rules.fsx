type ContactDetails =
    | Address of string
    | Telephone of string
    | Email of string
 
type CustomerId = CustomerId of string

type Customer =
    {
        CustomerId : CustomerId
        PrimaryContactDetails : ContactDetails
        SecondaryContactDetails : ContactDetails option
    }

type GenuineCustomer = GenuineCustomer of Customer // marker type

let createCustomer id primaryContactDetails secondaryContactDetails =
    {
        CustomerId = id
        PrimaryContactDetails = primaryContactDetails
        SecondaryContactDetails = secondaryContactDetails
    }

let customer = createCustomer (CustomerId "abc") (Email "hi@hello.com")
let customer2 = createCustomer (CustomerId "def") (Email "hello@God.com") (Some (Telephone "555"))

let validateCustomer customer =
    match customer.PrimaryContactDetails with
    | Email e when e.EndsWith "God.com" -> Some(GenuineCustomer customer)
    | Address _ | Telephone _ -> Some(GenuineCustomer customer)
    | Email _ -> None

// use marker type instead of if-else logic
let sendWelcomeMail (GenuineCustomer customer) =
    printfn "Hello %A, welcome!" customer.CustomerId