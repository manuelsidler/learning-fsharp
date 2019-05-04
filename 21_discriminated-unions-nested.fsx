type MMCDisk =
    | RsMmc
    | MmcPlus
    | SecureMmc

type Disk =
    | MMC of MMCDisk * NumberOfPins:int

let seek disk =
    match disk with
    | MMC(MmcPlus, 3) -> "Seeking quietly but slowly"
    | MMC(SecureMmc, 6) -> "Seeking quietly with 6 pins."

let secureMmc = MMC(SecureMmc, 6)
secureMmc |> seek
secureMmc |> sprintf "DU: %A"
