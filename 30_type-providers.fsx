#r @"lib\FSharp.Data.dll"
#r @"lib\XPlot.GoogleCharts.dll"
#r @"lib\Google.DataTable.Net.Wrapper.dll"

open FSharp.Data
open XPlot.GoogleCharts

type Football = CsvProvider<"data/FootballResultsBad.csv">
// type Football = CsvProvider<"data/FootballResultsBad.csv"> // leads to a compile error because one row contains string instead of int
let data = Football.GetSample().Rows |> Seq.toArray

data.[0].``Away Cards``

data
|> Seq.filter(fun row -> row.``Full Time Home Goals`` > row.``Full Time Away Goals``)
|> Seq.countBy(fun row -> row.``Home Team``)
|> Seq.sortByDescending snd
|> Seq.take 10
|> Chart.Column
|> Chart.Show