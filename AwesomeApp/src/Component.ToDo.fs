namespace Components
open Feliz 
open Feliz.Bulma
open Fable.SimpleJson


module Bestandteile = //Recordtype mit zwei Feldern

    type Komponenten = {
        Aufgaben: string
        Erledigt: string  
    }
    let localStoragekey = "TODO"
    type ToDo = 
        [<ReactComponent>]
        static member ToDoListe () = 

            let backfromString () = 
                let JSONString = Browser.WebStorage.localStorage.getItem (localStoragekey)
                Browser.Dom.console.log JSONString
                Json.parseAs<Komponenten list> ( JSONString)
                
            let Recordtypeliste =  
                //[{Aufgaben =  "Welche Aufgabe musst du heute erledigen?"; Erledigt = "Yay! du hast diese Aufgabe erledigt"} ]
                backfromString () 
            
            
            let (input, setinput) = React.useState ("") 

            let setLocalStorange (data: Komponenten list) = 
                let JSONString = Json.stringify data
                Browser.WebStorage.localStorage.setItem (  localStoragekey, JSONString)
            
            
            let (table: Komponenten list), settable = React.useState (Recordtypeliste)
            
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
                                          //  prop.text input
                                            prop.placeholder element.Aufgaben
                                            //prop.text element.Aufgaben
                                            prop.onChange (fun (x: string) -> 
                                                setinput (x))
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
                        {Aufgaben = input; Erledigt = "Wuhu eine Aufgabe weniger"} :: table |>settable;                       
                    ))
                ]
                Html.button [
                    prop.text "Speichern"
                    prop.onClick (fun _ ->
                    setLocalStorange table)
                ]
                Html.button [
                    prop.text "Speicher Abrufen"
                    color.isDanger
                    prop.onClick (fun _ -> (
                        backfromString () |> settable
                    ))    
                ]                              
            ]
        ]

// ZIEL: ich möchte das wenn ich auf Speicher klicke das er mir das zurückgibt was vorher im InputFeld stand aber wie erkennt er das ich da was reingeschrieben habe...............