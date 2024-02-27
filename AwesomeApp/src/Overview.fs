namespace Overview 
open Feliz 


type OverView =
    [<ReactComponent>]
    static member Main() =
        let currentpage, setpage = React.useState (Nav.Types.Page.LandingPage) //Hier muss Deckblatt dann hin 
        printfn "%A" currentpage
        Html.div [
            prop.children [
                Html.nav [
                    Nav.Navigationsleiste.LandingPage (setpage)
                    Nav.Navigationsleiste.Todo (setpage)
                    Nav.Navigationsleiste.Counter (setpage)
                ]
                match currentpage with 
                |Nav.Types.Page.LandingPage -> Deckblatt.Components.landingPage ()
                |Nav.Types.Page.Counter -> App.Components.Counter ()
                |Nav. Types.Page.Todo -> Liste.ToDoListe.ToDo ()
            ]
        ]