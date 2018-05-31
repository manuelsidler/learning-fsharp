open System
open System.IO

let checkCreation (time:DateTime) =
    if (time < (DateTime.Now.AddDays -7.)) then Console.WriteLine("Old")
    else Console.WriteLine("New")

// create a new function by composing a set of functions together
let checkCurrentDirectoryAge =
    Directory.GetCurrentDirectory
    >> Directory.GetCreationTime
    >> checkCreation

checkCurrentDirectoryAge()