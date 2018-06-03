type Customer = { Age: int }

let consoleWriter (text:string) =
    System.Console.WriteLine(text)

let fileWriter text =
    System.IO.File.WriteAllText(@"C:\tmp\output.txt", text)

let printCustomerAge writer customer =
    if customer.Age < 10 then writer "Child"
    elif customer.Age > 10 && customer.Age < 21 then writer "Teenager"
    else writer "Adult"

printCustomerAge consoleWriter { Age = 9 }
printCustomerAge System.Console.WriteLine { Age = 12 }
printCustomerAge fileWriter { Age = 22 }