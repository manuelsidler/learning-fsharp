// type annotations
let add (a:int, b:int) : int =
    let answer:int = a + b
    answer

// without type annotations
let add1 (a, b) =
    let answer = a + b
    answer

// won't compile
let add2 (a:int, b:string) =
    let answer = a + b
    answer

// string * string -> string
let add3 (a, b) =
    let answer = a + b + "hello"
    answer