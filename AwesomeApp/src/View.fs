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
                if currentpage = Page.LandingPage then 
                    Html.div "Hello"
                else 
                    Html.div "Plane"
               // match currentpage with 
                //|Nav.Types.NavBar.Allofit ->
                
            ]
        ]