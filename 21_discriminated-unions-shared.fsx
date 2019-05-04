// shared fields in base DU not supported. Combine record with DU.

type MMCDisk =
    | RsMmc
    | MmcPlus
    | SecureMmc

type Disk =
    | HardDisk of RPM:int * Platters:int
    | SolidState
    | MMC of MMCDisk * NumberOfPins:int

type DiskInfo =
    { Manufacturer: string
      SizeGb: int
      DiskData: Disk }

type Computer = { Manufacturer : string; Disks : DiskInfo list }

let myPc =
    { Manufacturer = "Computers Inc. "
      Disks = 
      [ { Manufacturer = "Hard Disks Inc."
          SizeGb = 1000
          DiskData = HardDisk(5400, 7) }
        { Manufacturer = "Super Disks Inc."
          SizeGb = 512
          DiskData = MMC(MmcPlus, 5) } ] }