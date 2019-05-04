type Printer =
    | Inkjet = 0
    | Laserjet = 1
    | DoMatrix = 2

let describe printer =
    match printer with
    | Inkjet -> "Inkjet"
    | Laserjet -> "Laserjet"
    | DoMatrix -> "DoMatrix"
    | _ -> "None"

Printer.Inkjet |> describe