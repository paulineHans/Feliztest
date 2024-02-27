namespace Startbutton 
// Muss mit Css Datein interagieren. Eigentlich Bestandteil von Components.fs 

open Feliz
open Feliz.Router

 static member StartButton() =
        let (count, setCount) = React.useState(0)
        Help.log count
        Html.div [
            Html.h1 [
                prop.text 

                prop.style [
                    style.textAlign.center
                    style.color.gray
                ]
            ]
        ]
         Html.button [
            prop.text "Start"
            prop.className "Startbutttonn" //Name der in Css Datei muss um hover effect etc. zu erstellen
        ]