open System.IO

type FolderStatistic = { Name : string 
                         Size : int64 }

let calculateFolderSize (folder : string) =
    folder
    |> Directory.GetFiles
    |> Array.sumBy (fun f -> FileInfo(f).Length)
   
let getSubfolders path =
    let folder = DirectoryInfo path
    folder.GetDirectories("*", SearchOption.AllDirectories)

getSubfolders @"C:\tmp"
|> Array.map (fun x -> { Name = x.Name; Size = calculateFolderSize x.FullName })
|> Array.sortByDescending(fun x -> x.Size)