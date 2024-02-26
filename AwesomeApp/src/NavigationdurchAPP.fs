namespace Nav
open Feliz 

type Navigationsleiste =
    static member private Subpagelink (targetpage: Types.page, set)
        Html.div [
            Html.a [
                prop.text (targetpage.toStringReadable()); 
                prop.onClick (handler = fun _ -> setPage ())
                if targetpage = statepage then 
                        prop.className "HelleSeite"
                else    prop.className ""
            ]
        ]