// won't compile, compiler doesn't know the length property
let getLength name = sprintf "Name is %d letters." name.Length

// compiles
let getLength (name:string) = sprintf "Name is %d letters." name.Length

// compiler can infer type to be string because of the return type of "getLength"
let foo name = "Hello " + getLength(name)