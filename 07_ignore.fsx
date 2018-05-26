let writeTextToDisk text =
    let path = System.IO.Path.GetTempFileName()
    System.IO.File.WriteAllText(path, text)
    path

let createManyFiles() =
    writeTextToDisk "Blabla" // we don't ignore the return value explicitly, compiler raises warning
    ignore(writeTextToDisk "test") // we explicitly ignore the return value

createManyFiles