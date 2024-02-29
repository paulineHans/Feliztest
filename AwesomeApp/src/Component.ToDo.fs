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
            let (table: Komponenten list), addtableslot = React.useState (Recordtypeliste)
            Html.div [
                    Bulma.tag [
                        color.isWhite 
                        prop.text "Liste-To-Do"
                        prop.style [
                            style.margin (length.rem 2)
                            style.fontSize 15
                        ]
                    ]
                    // Bulma.control.div [
                    //     Bulma.input.text [
                    //         //prop.className "input is priary" Hover Button 
                    //         prop.placeholder "Aufgaben die erledigen du musst kommen rein hier"
                    //         prop.style [
                    //             style.width 700
                    //             style.margin 32
                    //         ] 
                    //     ]
                    // ] 
                    // Bulma.control.div [
                    //     Bulma.input.checkbox [
                    //         prop.placeholder "Erledigt"
                    //         prop.style[
                    //             style.width 100   
                    //         ]
                    //     ]
                    // ]
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
                                                prop.placeholder "Aufgabe hinzufügen du musst hier"
                                            ]
                                        ]
                                    ]
                                    Html.td [
                                        Bulma.control.div [
                                            Bulma.input.checkbox [
                                                prop.placeholder "Erledigt deine Aufgabe sein?"
                                            ]
                                        ]
                                    ] 
                                ]
                        ]
                    ]
                        ]
                    
            


         
          