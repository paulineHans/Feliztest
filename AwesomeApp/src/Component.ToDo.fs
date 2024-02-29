namespace Components
open Feliz 
open Feliz.Bulma

module Bestandteile = //Recordtype mit zwei Boxen 

    type Komponenten = {
        Aufgaben: string
        Erledigt: string  
    }

    type ToDo = 
        [<ReactComponent>]
        static member ToDoListe () = 
            let Recordtypeliste = [
                 {Aufgaben =  "Kapitel 1-5 lesen"; Erledigt = "Nur bis Kapitel 4"}
            ]
            let (table: Komponenten), addtableslot = React.useState (Recordtypeliste)
            Html.div [
                    Bulma.tag [
                        color.isWhite 
                        prop.text "TODO"
                        ]
            ]