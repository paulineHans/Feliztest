namespace Components
open Feliz 
open Feliz.Bulma
open Fable.SimpleJson


module Bestandteile = //Recordtype mit zwei Feldern

    type Komponenten = {
        Aufgaben: string
        Erledigt: string  
    }

    type ToDo = 
        [<ReactComponent>]
        static member ToDoListe () = 
            
            // let Recordtypeliste = [
            //     {Aufgaben =  "Welche Aufgabe musst du heute erledigen?"; Erledigt = "Yay! du hast diese Aufgabe erledigt"}  
            // ]

            let blub = Browser.WebStorage.localStorage.getItem ("Heutige Aufgabe") //Daten aus LocalStorage werden abgerufen
            let backfromString = Json.tryParseAs<Komponenten list> (blub) //String back to Recordtypeliste
            let fallback =
                match backfromString with
                | Result.Ok l -> printfn "ok"; l
                | Result.Error e -> printfn "not ok"; []
            
            let (input, setinput) = React.useState ("")    
            let (table: Komponenten list), settable = React.useState (fallback)
            Browser.Dom.console.log (backfromString)
            
            // Wert wird im LocalStorage unter dem Schlüssel "c" abgerufen und in der 
            //Variable blub gespeichert. Danach wird versucht, den in blub gespeicherten JSON-String
            //in Komponenten list zurückzuschreiben. Das Resultat wird in backfromString gespeicher
            //Mit dem Pattern matching wird überprüft ob es geklappt hat. 

            Html.div [
                prop.className "space-children"
                prop.children [
                Html.button [
                    prop.text "Löschen"
                    prop.className "Löschenbutton"
                    prop.onClick (fun _ ->

                        let listlength = List.length table
                        let newlist = List.take (listlength - 1) table |> settable; //Funktion die das letzte Element aus ToDo löscht 
                        newlist

                        // Browser.Dom.console.log (blub)
                        // Browser.WebStorage.localStorage.setItem("Heutige Aufgabe","Awesome eine Aufgabe weniger!")
                        // Browser.WebStorage.sessionStorage.setItem ("Heutige Aufgabe","Awesome eine Aufgabe weniger!")                    
                        ) 
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
                                            prop.onChange (fun (x: string) -> 
                                            setinput x
                                            Browser.WebStorage.localStorage.setItem("Heutige Aufgabe",input) 
                                            )

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
                Bulma.button.button[
                    prop.text "Hinzufügen"   
                    prop.onClick (fun _ -> (
                        {Aufgaben = blub; Erledigt = "Wuhu eine Aufgabe weniger"} :: table |>settable;
                        // let JSONString  = Json.stringify table
                        // Browser.Dom.console.log (JSONString) 
                        // Browser.WebStorage.localStorage.setItem("Heutige Aufgabe",JSONString)                       
                    ))
                ] 
                Html.button [
                    prop.text "Speicher"
                    color.isDanger
                    prop.onClick (fun _ -> (
                        {Aufgaben = blub ; Erledigt = "Wuhu eine Aufgabe weniger"} :: table |>settable
                    ))    
                ]                              
            ]
        ]

// ZIEL: ich möchte das wenn ich auf Speicher klicke das er mir das zurückgibt was vorher im InputFeld stand aber wie erkennt er das ich da was reingeschrieben habe...............