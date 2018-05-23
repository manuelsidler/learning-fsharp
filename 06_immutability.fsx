let name = "hans"
name = "lorena" // compares "hans" with "lorena" and therefore returns false -> val it : bool = false
name <- "lorena" // doesn't compile, name is immutable

let mutable newName = "hans"
newName <- "lorena" // compiles because we declared newName mutable explicitly