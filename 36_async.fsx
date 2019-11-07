printfn "loading data..."
System.Threading.Thread.Sleep(5000)
printfn "loaded data"
printfn "My name is Sarah"

async {
    printfn "loading data..."
    System.Threading.Thread.Sleep(5000)
    printfn "loaded data"
} |> Async.Start

printfn "My name is Sarah"

// returning result from an async block
let asyncHello : Async<string> = async { return "Hello" }
let length = asyncHello.Length // compiler error
let text = asyncHello |> Async.RunSynchronously // executing and unwrapping on current thread
let lengthTwo = text.Length

// continuation
let getTextAsync = async { return "Hello" }
let printHello = 
    async {
        let! text = getTextAsync // ! like await in C# -> only valid in async block
        return printfn "%s World" text
    }
printHello |> Async.Start

// fork / join
let random = System.Random()
let pickNumberAsync = async { return random.Next(10) }
let createFiftyNumbers =
    let workflows = [ for i in 1 .. 50 -> pickNumberAsync ]
    async {
        let! numbers = workflows |> Async.Parallel // executing all workflows in parallel and unwrap results
        printfn "Total is %d" (numbers |> Array.sum)
    }
createFiftyNumbers |> Async.Start