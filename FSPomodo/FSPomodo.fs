namespace FSPomodo

type PmdTimer (durationMin)=
    member this.Duration = System.TimeSpan.FromMinutes(durationMin)
    [<DefaultValue>]val mutable StartTime : System.DateTime
    member this.TimerStart() = 
        this.StartTime <- System.DateTime.Now
    member this.GetRemainingTime() =
        this.Duration - (System.DateTime.Now - this.StartTime)    


    