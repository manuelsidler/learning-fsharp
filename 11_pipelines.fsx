open System.IO
open System

let checkCreation (time:DateTime) =
    if (time < (DateTime.Now.AddDays -7.)) then Console.WriteLine("Old")
    else Console.WriteLine("New")

// Old fashioned ways
let time =
    let directory = Directory.GetCurrentDirectory()
    Directory.GetCreationTime directory
checkCreation time

checkCreation(
    Directory.GetCreationTime(
        Directory.GetCurrentDirectory()))

// Fancy pipelines
Directory.GetCurrentDirectory() // input: - , output: string
|> Directory.GetCreationTime // input: string , output: datetime
|> checkCreation // input: datetime , output: - (prints to console)