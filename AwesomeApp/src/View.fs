namespace App 
open Feliz 
open Feliz.Bulma


open Types

type View =
    [<ReactComponent>]
    static member Main() =
        let currentpage, setpage = React.useState (Page.LandingPage) //Hier muss Deckblatt dann hin 
        printfn "%A" currentpage
        Html.div [
            prop.children [
                Components.NavBar.Main (setpage, currentpage)
                match currentpage with 
                |Page.Counter -> 
                    Components.Components.Counter ()
                |Page.LandingPage -> Html.div "Start"
                |Page.Todo -> Html.div "To-Do-Liste"
            
            ]
        ]