open System

type Rule = string -> bool * string

let rules : Rule list =
    [ fun text -> (text.Split ' ').Length = 3, "Must be three words"
      fun text -> text.Length <= 30, "Max length is 30 chars"
      fun text -> text
                  |> Seq.filter Char.IsLetter
                  |> Seq.forall Char.IsUpper, "All letters must be caps" ]

// manually test the rules
let validateManual (rules: Rule list) word =
    let passed, error = rules.[0] word
    if not passed then false, error
    else
        let passed, error = rules.[1] word
        if not passed then false, error
        else
            let passed, error = rules.[2] word
            if not passed then false, error
            else true, ""

let buildValidator (rules : Rule list) =
    rules
    |> List.reduce(fun firstRule secondRule ->
        fun word ->
            let passed, error = firstRule word
            if passed then
                let passed, error = secondRule word
                if passed then true, "" else false, error
            else false, error)
let validate = buildValidator rules
let word =  "hELLO FrOM F#"
validate word