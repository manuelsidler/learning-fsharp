module Tests

open Xunit
open FsUnit.Xunit
open BusinessLogic

let isTrue (b:bool) = Assert.True b

let department =
    { Name = "Super Team"
      Team = [ for i in 1 .. 15 -> { Name = sprintf "Person %d" i; Age = 19 } ] }

[<Fact>]
let isLargeAndYoungTeam_TeamIsLargeAndYoung_ReturnsTrue() =
    department |> isLargeAndYoungTeam |> Assert.True // Pipeline with plan xunit
    department |> isLargeAndYoungTeam |> isTrue // Pipeline with wrapper

[<Fact>]
let ``FSUnit makes nice DSLs!``() =
    department
    |> isLargeAndYoungTeam
    |> should equal true

    department.Team.Length
    |> should be (greaterThan 10)