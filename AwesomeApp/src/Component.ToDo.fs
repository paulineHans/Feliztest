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
                 {Aufgaben =  "HALLO"; Erledigt = "HUHU"}
                 {Aufgaben =  "HIHI"; Erledigt = "HAHA"}   
            ]
            let (table: Komponenten list), settable = React.useState (Recordtypeliste)
            Html.div [
                    Html.button [
                        prop.className "container"
                        prop.text "Löschen"
                        prop.onClick (fun _ ->
                            let listlength = List.length table
                            let newlist = List.take (listlength - 1) table |> settable
                            newlist)
                    ]
                    Bulma.table [ 
                        Html.thead [
                            Html.tr [
                                Html.th "Aufgaben"
                                Html.th "Erledigt"
                            ]
                        ]
                        Html.tbody [
                            for element in table do 
                                Html.tr [
                                    Html.td [
                                        Bulma.control.div[
                                            Bulma.input.text [
                                                prop.placeholder "Aufgabe hinzufügen"
                                            ]
                                        ]
                                    ]
                                    Html.td [
                                        Bulma.control.div [
                                            Bulma.input.checkbox [
                                                prop.placeholder "Erledigt?"
                                            ]
                                        ]
                                    ] 
                                ]
                        ]
                    ]
                    Html.h1 [
                        Bulma.button.button[
                            prop.text "Hinzufügen"
                            prop.style []   
                            prop.onClick (fun _ -> (
                                {Aufgaben = "duschen"; Erledigt = "ja"} :: table |>settable 
                            ))

                        ]
                    ]
                    
                                
                ]
                        
                    
                             
                
                
            

                