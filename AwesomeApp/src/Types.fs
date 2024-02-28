module Types

[<RequireQualifiedAccess>]
type Page =     //type Page repräsentiert verschiedene Fallalternativen 
    |LandingPage
    |Counter
    |Todo

// member this.toStrinReadable wandelt alles in einen String um, sodass es Lesbar wird auf Website 
    member this.toStringReadable () = 
        match this with
        |LandingPage -> "Start"
        |Counter -> "Counter" 
        |Todo -> "Todo-Liste" 