open System
open System.IO

let writeToFile (date:DateTime) filename text =
    let file = sprintf "%s-%s.txt" (date.ToString "yyMMdd") filename
    File.WriteAllText(file, text)

let writeToToday = writeToFile DateTime.Today
let writeToTomorrow = writeToFile (DateTime.Today.AddDays 1.)
let writeToTodayHelloWorld = writeToToday "hello-world"

writeToTodayHelloWorld "Hello!"