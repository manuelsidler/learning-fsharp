open System
open System.Net
open System.Windows.Forms

// before
(*
let webClient = new WebClient()
let fsharpOrg = webClient.DownloadString(Uri "http://fsharp.org")
let browser = new WebBrowser(ScriptErrorsSuppressed = true, Dock = DockStyle.Fill, DocumentText = fsharpOrg)
let form = new Form(Text = "Hello from F#!")
form.Controls.Add browser
form.Show()
*)

// after
let browse url = 
    let website =
        let webClient = new WebClient()
        webClient.DownloadString(Uri url)

    let browser = new WebBrowser(ScriptErrorsSuppressed = true, Dock = DockStyle.Fill, DocumentText = website)

    let form = new Form(Text = "Hello from F#!")
    form.Controls.Add browser
    form.Show()

browse "http://www.google.com"