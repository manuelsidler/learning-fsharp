let readFileNameAndChangeDate path =
    let fileInfo = new System.IO.FileInfo(path);
    fileInfo.Name, fileInfo.LastWriteTime

let fileNameAndDate = readFileNameAndChangeDate "c:\\Users\\Manuel Sidler\\Downloads\\smart-templates.PublishSettings"