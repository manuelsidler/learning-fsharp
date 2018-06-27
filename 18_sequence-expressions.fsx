open System.IO

let lines : string seq =
    seq { // sequence expression
        use sr = new StreamReader(File.OpenRead @"sample.txt")
        while (not sr.EndOfStream) do
            yield sr.ReadLine() } // yielding a row

(0, lines) ||> Seq.fold (fun total line -> total + line.Length)