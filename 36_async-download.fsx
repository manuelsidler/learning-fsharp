open System
open System.Net

let urls = [| "http://fsharp.org"; "http://microsoft.com"; "http://duckduckgo.com" |]

// *** Async version ***
let downloadDataAsync url =
    async {
        let uri = Uri url
        use webClient = new WebClient()
        let! data = webClient.AsyncDownloadData(uri)
        return data.Length
    }

let downloadBytesAsync =
    urls
    |> Array.map downloadDataAsync
    |> Async.Parallel
    |> Async.RunSynchronously
    |> Array.sum

printfn "Downloaded %d bytes async" downloadBytesAsync

// *** Task version ***
let downloadDataTask url =
    async {
        let uri = Uri url
        use webClient = new WebClient()
        let! data = webClient.DownloadDataTaskAsync(uri) |> Async.AwaitTask
        return data.Length
    }

let downloadBytesTask =
    urls
    |> Array.map downloadDataTask
    |> Async.Parallel
    |> Async.StartAsTask

printfn "Downloaded %d bytes task based" (Array.sum downloadBytesTask.Result)