namespace Components
open Feliz 
open Feliz.Bulma

open Types
//Code für das Skelett der Navigationsleiste 
type NavBar =
    static member Main (setPage: Page -> unit, statepage: Page) = //Navigation zu den Unterseiten
        Bulma.navbar [
            Bulma.color.isBlack
            prop.children [
                Bulma.navbarBrand.div [
                ]
                Bulma.navbarMenu [
                    Bulma.navbarStart.div [
                        Bulma.navbarItem.a [
                            prop.text "Hier deine Reise du muss starten"
                            prop.onClick (fun _ -> setPage Page.LandingPage)]  
                        Bulma.navbarItem.a [
                            prop.text "Counter" 
                            prop.onClick (fun _ -> setPage Page.Counter)
                            if Types.Page.Counter = statepage then
                                prop.className "Highligtheffekt"
                            else ()]
                        Bulma.navbarItem.a [ 
                            prop.text "To-Do-Liste" 
                            prop.onClick (fun _ -> setPage Page.Todo)
                            if Types.Page.Todo = statepage then 
                                prop.className "Highligtheffekt"
                            else ()]
                    ]
                ]
            ]
        ]
    