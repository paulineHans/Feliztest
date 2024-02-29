namespace Components
open Feliz 
open Feliz.Bulma

open Types
//Code für das Skelett der Navigationsleiste 
type NavBar =
    static member Main (setPage: Page -> unit, statepage: Page) = //Navigation zu den Unterseiten
        Bulma.navbar [
            Bulma.color.isWhite
            prop.children [
                Bulma.navbarBrand.div [
                    Bulma.navbarItem.a [
                        Html.img [ prop.src "https://bulma.io/images/bulma-logo-white.png"; prop.height 28; prop.width 112; ]
                    ]
                ]
                Bulma.navbarMenu [
                    Bulma.navbarStart.div [
                        Bulma.navbarItem.a [
                            prop.text "Start"
                            prop.onClick (fun _ -> setPage Page.LandingPage)]  
                        Bulma.navbarItem.a [
                            prop.text "Counter" 
                            prop.onClick (fun _ -> setPage Page.Counter)]
                        Bulma.navbarItem.a [ 
                            prop.text "To-Do-Liste" 
                            prop.onClick (fun _ -> setPage Page.Todo)
                            if Components.Bestandteile.Komponenten = statepage then 
                                prop.className "Highligtheffekt"]
                    ]
                ]
            ]
        ]
    