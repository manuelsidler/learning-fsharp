open System.IO
open System

// type FolderStatistic = { Name : string 
//                          Size : int
//                          NumberOfFiles : int 
//                          AverageFileSize : int
//                          FileExtensions : string list }

type FolderStatistic = { Name : string 
                         Size : int64 }

let calculateFolderSize (folder : string) =
    let files = Directory.GetFiles folder |> List.ofSeq
    files |> List.sumBy (fun f -> FileInfo(f).Length)
   

let subfolders : DirectoryInfo array =
    let folder = new DirectoryInfo(@"C:\\tmp")
    folder.GetDirectories()

subfolders
|> List.ofArray
// group by?
|> List.map (fun x -> { Name = x.Name; Size = calculateFolderSize x.FullName })
|> List.sortByDescending(fun x -> x.Size)