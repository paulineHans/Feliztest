namespace Nav
open Feliz 
open Feliz.Bulma

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
        Bulma.navbar [
            Bulma.color.isPrimary
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
           
    static member Counter(setPage) = 
            Navigationsleiste.Subpagelink(Types.Page.Counter, setPage)
              //verlinkt den richten suppage link mit dem typen
     
    static member Todo(setPage) =   
        Navigationsleiste.Subpagelink(Types.Page.Todo, setPage)  //verlinkt den richten suppage link mit dem typen

    static member LandingPage (setPage ) = 
        Navigationsleiste.Subpagelink(Types.Page.LandingPage, setPage)
    