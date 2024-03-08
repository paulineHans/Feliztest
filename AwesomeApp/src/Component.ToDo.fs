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
    
    //Die Variable input enthält den aktuellen Wert dieses Zustands, 
    //während setinput eine Funktion ist, die verwendet wird, um diesen Wert zu aktualisieren 

    let setToDoLocalStorange (data: Komponenten list) = 
        let JSONString = Json.stringify data
        Browser.WebStorage.localStorage.setItem (localStoragekey, JSONString)

     /// backfromString dient dazu JSON.string Daten aus dem localstroage zu lesen und in der Console auszugeben und anschließend zu deserialisieren  
    let getToDoLocalStorage () = 
        let JSONString = Browser.WebStorage.localStorage.getItem (localStoragekey)
        Browser.Dom.console.log (isNull JSONString)
        if isNull JSONString then 
            [
                {Aufgaben = ""; Erledigt = "shdfsd"}
            ] 
        else 
            Browser.Dom.console.log JSONString
            Json.parseAs<Komponenten list> ( JSONString)
    
    let updateListElement (table: Komponenten list) (i : int) (x : string) : Komponenten list = 
        table 
        |> List.mapi (fun (idx: int) (item: Komponenten) -> 
            if idx = i then 
                let updatetString: Komponenten = {Aufgaben = x; Erledigt = "Yay! du hast diese Aufgabe erledigt"}
                updatetString
            else 
                item
        )
   

open Bestandteile

type ToDo = 
    [<ReactComponent>]
    static member ToDoListe () = 

//Die Funktion backfromString lädt JSON-Daten aus dem Local Storage,
//loggt sie in der Browser-Konsole und deserialisiert sie in eine Liste von Records, 
//wobei das Ergebnis der Deserialisierung in der Variable Recordtypeliste gespeichert wird.    
        let Recordtypeliste =  
            //[{Aufgaben =  "Welche Aufgabe musst du heute erledigen?"; Erledigt = "Yay! du hast diese Aufgabe erledigt"} ]
            getToDoLocalStorage () 
        

        let (input, setinput) = React.useState("")


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
                    for i in [0 .. (table.Length - 1)] do //jedes Element der Liste
                        let element = table |> List.item i
                        Html.tr [
                            Html.td [
                                Bulma.control.div [
                                    Bulma.input.text [
                                        prop.valueOrDefault element.Aufgaben
                                        prop.placeholder "Aufgabe Hinzufügen"
                                        prop.onChange (fun (x: string) -> // reagiert auf Veränderungen x ist der aktuelle Wert des Eingabe 
                                            let updateListElement (table: Komponenten list) (i : int) (x : string) : Komponenten list =
                                                table 
                                                |> List.mapi (fun (idx: int) (item: Komponenten) -> 
                                                    if idx = i then 
                                                        let updatetString: Komponenten = {Aufgaben = x; Erledigt = "Yay! du hast diese Aufgabe erledigt"}
                                                        updatetString
                                                    else 
                                                        item
                                                )
                                            let nextTable = updateListElement table i x 
                                            nextTable |> settable 
                                            nextTable |> setToDoLocalStorange 
                                            //backfromString () |> settable    
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
            Bulma.button.button [
                prop.text "Hinzufügen"   
                prop.onClick (fun _ -> (
                    {Aufgaben = input; Erledigt = "Wuhu eine Aufgabe weniger"} :: table |>settable;                       
                ))
            ]
            Html.button [
                prop.text "Speichern"
                prop.onClick (fun _ ->
                setToDoLocalStorange table)
            ]
            Html.button [
                prop.text "Speicher Abrufen"
                color.isDanger
                prop.onClick (fun _ -> (
                    getToDoLocalStorage () |> settable
                ))    
            ]                              
        ]
    ]
