let printUsersFirstName () =
    let readFullName () =
        System.Console.ReadLine()
    
    let parseFirstName (fullName:string) : string =
        fullName.Split(' ').[0]
    
    let fullName = readFullName()
    let firstName = parseFirstName fullName
    System.Console.WriteLine(firstName)

printUsersFirstName()