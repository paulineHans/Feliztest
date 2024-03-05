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
            
            let Recordtypeliste = [
                {Aufgaben =  "Welche Aufgabe musst du heute erledigen?"; Erledigt = "Yay! du hast diese Aufgabe erledigt"}  
            ]

            let blub = Browser.WebStorage.localStorage.getItem ("c") //Daten aus LocalStorage werden abgerufen
            let backfromString = Json.tryParseAs<Komponenten list> (blub) //String back to Recordtypeliste
            let fallback =
                match backfromString with
                | Result.Ok l -> printfn "ok"; l
                | Result.Error e -> printfn "not ok"; []
            
            let (table: Komponenten list), settable = React.useState (fallback)
            Browser.Dom.console.log (backfromString)
            
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

                        Browser.Dom.console.log (blub)
                        Browser.WebStorage.localStorage.setItem("Heutige Aufgabe","Awesome eine Aufgabe weniger!")
                        Browser.WebStorage.sessionStorage.setItem ("Heutige Aufgabe","Awesome eine Aufgabe weniger!")                    
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
                    prop.style []   
                    prop.onClick (fun _ -> (
                        {Aufgaben = "Welche Aufgabe musst du erledigen?"; Erledigt = "Wuhu eine Aufgabe weniger"} :: table |>settable;
                        //Recordtypelist -> JSONString
                        let JSONString  = Json.stringify table
                        Browser.Dom.console.log (JSONString) 
                        Browser.Dom.console.log (backfromString)
                        Browser.WebStorage.localStorage.setItem("Heutige Aufgabe","Welche Aufgabe machst du heute noch :)")
                        Browser.WebStorage.sessionStorage.setItem ("Heutige Aufgabe" ,"Welche Aufgabe machst du heute noch :)")                       
                    ))
                ]                               
            ]
        ]


      
        

    
                             
                
                
            

                