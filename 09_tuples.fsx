let parse (person:string) =
    let parts = person.Split(' ')
    let playername = parts.[0]
    let game = parts.[1]
    let score = int(parts.[2])
    playername, game, score

let person = parse "Schueh Monopoly 14"
let a, b, c = person // deconstructing the tuple into three variables