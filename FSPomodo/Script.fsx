#load "FSPomodo.fs"
open FSPomodo

// Define your library scripting code here


let aho = FSPomodo.PmdTimer 1.
aho.TimerStart()
let hoge = 
    while (aho.GetRemainingTime() > System.TimeSpan.FromMinutes(0.)) do
        printfn "aho"
        do System.Threading.Thread.Sleep(1000)


let simulatedJob id time =
    let timestamp() = System.DateTime.Now.Ticks
    async {
       printfn "Job %d start" id
       let timestamp1 = timestamp()
       do! Async.Sleep(time * 1000)
       let timestamp2 = timestamp()
       let timespan = System.TimeSpan(timestamp2 - timestamp1)
       printfn "Job %d end %s" id (timespan.ToString("G"))
    }

[ 1 .. 10]
|> List.mapi (fun index time -> simulatedJob index time)
|> Async.Parallel
|> Async.RunSynchronously
|> ignore

open System.Windows.Forms
let form = new Form(Visible = true)
let textBox = new TextBox(ReadOnly = true, Text = "Hello world")
form.Controls.Add(textBox)
async {
    while true do
        do! Async.Sleep 1000
        textBox.Text <- System.DateTime.Now.ToString()
} |> Async.StartImmediate
[<System.STAThread>]
do Application.Run(form)
