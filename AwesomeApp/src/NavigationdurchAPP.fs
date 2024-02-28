namespace Nav
open Feliz 
open Feliz.Bulma

module Types = 
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

//Code für das Aussehen der Navigationsleiste 
    type NavBar  =
        static member private Subpagelink (setPage: Page -> unit, statepage: Page) = 
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
                            Bulma.navbarItem.a [ prop.text "Home" ]
                            Bulma.navbarItem.a [ prop.text "Documentation" ]
                            Bulma.navbarItem.a [ prop.text "Jobs" ]
                            Bulma.navbarItem.a [ prop.text "Contact" ]
                            Bulma.navbarItem.a [ prop.text "About" ]
                        ]
                    ]
                ]
            ]
    

