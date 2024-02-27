namespace Nav
open Feliz 

module Types = 
    [<RequireQualifiedAccess>]
    type Page =
        |LandingPage
        |Counter
        |Todo
        member this.toStringReadable () =
            match this with
            |LandingPage -> "Start"
            |Counter -> "Counter" 
            |Todo -> "Todo-Liste" //zu einem lesbaren string umwandeln (wird angezeigt auf der website) 

type Navigationsleiste =
    static member private Subpagelink (targetpage: Types.Page, setPage: Types.Page -> unit) =
        Html.div [
            Html.a [
                prop.text (targetpage.toStringReadable()); 
                prop.onClick (fun _ -> setPage (targetpage))
            ]
        ]   
    static member Counter(setPage) = 
            Navigationsleiste.Subpagelink(Types.Page.Counter, setPage)
              //verlinkt den richten suppage link mit dem typen
     
    static member Todo(setPage) =   
        Navigationsleiste.Subpagelink(Types.Page.Todo, setPage)  //verlinkt den richten suppage link mit dem typen

    static member LandingPage (setPage ) = 
        Navigationsleiste.Subpagelink(Types.Page.LandingPage, setPage)
    