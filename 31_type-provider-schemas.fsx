#r @"packages\FSharp.Data\lib\netstandard2.0\FSharp.Data.dll"
#r @"packages\XPlot.GoogleCharts\lib\netstandard2.0\XPlot.GoogleCharts.dll"
#r @"packages\Google.DataTable.Net.Wrapper\lib\netstandard2.0\Google.DataTable.Net.Wrapper.dll"

open FSharp.Data
open XPlot.GoogleCharts

type Films = HtmlProvider<"https://en.wikipedia.org/wiki/Robert_De_Niro_filmography">
let deNiro = Films.GetSample()
deNiro.Tables.Film.Rows
|> Array.countBy(fun row -> string row.Year)
|> Chart.SteppedArea
|> Chart.Show

type Package = HtmlProvider<"data/sample-package.html"> // get local schema
let ef = Package.Load("https://www.nuget.org/packages/entityframework") // redirect to remote source
let nunit = Package.Load("https://www.nuget.org/packages/nunit")
let newtonsoft = Package.Load("https://www.nuget.org/packages/newtonsoft.json")

[ ef; nunit; newtonsoft ]
|> Seq.collect(fun package -> package.Tables.``Version History``.Rows)
|> Seq.sortByDescending(fun versionHistory -> versionHistory.Downloads)
|> Seq.take 10
|> Seq.map(fun vh -> vh.Version, vh.Downloads)
|> Chart.Column
|> Chart.Show