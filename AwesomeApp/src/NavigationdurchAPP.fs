namespace Nav
open Feliz 

type Navigationsleiste 
    static member private Subpagelink (targetpage: Types.page, set)
        Html.div [
            Html.a [
                prop.text (targetpage.toStringReadable()); 
                prop.onClick ()
            ]
        ]