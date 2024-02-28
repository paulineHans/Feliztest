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


// von ChatGpt Code der den Startbutton enthält und wenn man auf ihn klickt dieser verschwindet und zwei neue buttons erscheinen
module Main

open Feliz
open Feliz.Bulma

let main () =
    Html.div [
        prop.style [ Style.marginTop (Rem 1.0) ]
        Bulma.button [
            prop.onClick (fun _ -> JS.Invokable.ofAsyncFunc (fun _ ->
                // Hier können Sie Server-seitige Aktionen durchführen
                // Zum Beispiel Dateisystemzugriff mit F# und Node.js
                async {
                    // Ihre Dateisystemmanipulationen hier
                    // Beachten Sie, dass Sie dazu ein Node.js-Modul wie 'fs' verwenden müssen
                    return ()
                }
            ))
        ] [ Bulma.text "Start" ]

        Html.div [
            prop.style [ Style.marginTop (Rem 1.0) ]
            Bulma.button [ ] [ Bulma.text "Button 1" ]

            Bulma.button [ ] [ Bulma.text "Button 2" ]
        ]
        |> prop.style [ Style.display Flexbox.Display.none ]
        |> prop.id "hiddenButtons"
    ]

// Dieser Code registriert die Hauptfunktion für die Ausführung auf der Clientseite
Feliz.RenderIntoBrowser.documentBrowser main
