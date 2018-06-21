open System
open System.IO

Directory.EnumerateDirectories("C:")
|> Seq.map(fun d -> new System.IO.DirectoryInfo(d))
|> Seq.map(fun d -> d.Name, d.CreationTime)
|> Map.ofSeq
|> Map.map(fun name creationTime -> name, DateTime.Now - creationTime)