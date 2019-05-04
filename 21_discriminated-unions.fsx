(* the C# way
abstract class Disk { }
class HardDisk : Disk
{
    public int RPM { get; set; }
    public int Platters { get; set; }
}
class SolidSate : Disk {}
class MMC : Disk
{
    public int NumberOfPins { get; set; }
} 
*)

// F# discriminated union
type Disk = // base type
    | HardDisk of RPM:int * Platters:int // two custom fields
    | SolidState // no custom fields
    | MMC of NumberOfPins:int // one custom field

let hd = HardDisk(RPM = 7000, Platters = 8) // explicit arguments
let hdShort = HardDisk(5000, 6) // lightweight

let args = 2500, 4
let hdTupled = HardDisk args

let mmc = MMC 3

let ssd = SolidState

// we use pattern matching to access a specific DU type
// we also use functions with pattern matching (like abstract methods in C# type hierarchies)
let describe disk =
    match disk with
    | SolidState -> printfn "I'm a newfangled SSD."
    | MMC 1 -> printfn "I have only 1 pin."
    | MMC pins when pins < 5 -> printfn "I'm an MMC with a few pins."
    | MMC pins -> printfn "I'm an MMC with %i pins" pins
    | HardDisk (rpm, _) when rpm = 5400 -> printfn "I'm a slow hard disk."
    | HardDisk (_, platters) when platters = 7 -> printfn "I have 7 spindles!"
    | HardDisk _ -> printfn "I'm a hard disk."

(MMC 1) |> describe
SolidState |> describe 
(MMC 4) |> describe 
(MMC 30) |> describe 
(HardDisk(5400, 3)) |> describe 
(HardDisk(7200, 7)) |> describe 
(HardDisk(7200, 2)) |> describe

// printing out DUs
mmc |> sprintf "%A"