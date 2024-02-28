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

//Code für das Skelett der Navigationsleiste 
    type NavBar  =
        static member private Subpagelink (setPage: Page -> unit, statepage: Page) = //Navigation zu den Unterseiten
            Bulma.navbar [
                Bulma.color.isWhite
                prop.children [
                    Bulma.navbarBrand.div [
                        Bulma.navbarItem.a [
                            Html.img [ prop.src "https://bulma.io/images/bulma-logo-black.png"; prop.height 28; prop.width 112; ]
                        ]
                    ]
                    Bulma.navbarMenu [
                        Bulma.navbarStart.div [
                            Bulma.navbarItem.a [
                                 prop.text "Start"]
                                // prop.onClick (fun _ -> setPage ())] Hier muss die verlinkte Seite hin 
                            Bulma.navbarItem.a [ prop.text "Counter" ]
                            Bulma.navbarItem.a [ prop.text "To-Do-Liste" ]
                            //Bulma.navbarItem.a [ prop.text "Contact" ]
                            //Bulma.navbarItem.a [ prop.text "About" ]
                        ]
                    ]
                ]
            ]
        static member Allofit (setPage, currentpage) = 
            NavBar.Subpagelink (setPage, currentpage)
        // SetPage ist für den Übergang zwischen Pages verantwortlich und currentPage zeigt die aktuelle Seite an. Übergang soll einfach werden