namespace Nav
open Feliz 
open Feliz.Bulma

module Types = 
    [<RequireQualifiedAccess>]
    type Page =
        |Counter
        |Todo
        member this.toStringReadable () =
            match this with
            |Counter -> "Counter" 
            |Todo -> "Todo-Liste" //zu einem lesbaren string umwandeln (wird angezeigt auf der website) 

type Navigationsleiste =
    static member private Subpagelink (targetpage: Types.Page, setPage: Types.Page -> unit) =
        Bulma.navbar [
            Bulma.color.isPrimary
            prop.children [
        Bulma.navbarBrand.div [
            Bulma.navbarItem.a [
                Html.img [ prop.src "AwesomeApp/src/DD.jpg"; prop.height 28; prop.width 112; ]
            ]
        ]
        Bulma.navbarMenu [
            Bulma.navbarStart.div [
                Bulma.navbarItem.a [
                     prop.text "To-Do-Liste" 
                     ]
                Bulma.navbarItem.a [ 
                    prop.text "Counter" 
                    ]
                ]
         ]
        ]
    ]
           
    static member Counter(setPage) = 
            Navigationsleiste.Subpagelink(Types.Page.Counter, setPage)
              //verlinkt den richten suppage link mit dem typen
     
    static member Todo(setPage) =   
        Navigationsleiste.Subpagelink(Types.Page.Todo, setPage)  //verlinkt den richten suppage link mit dem typen
    