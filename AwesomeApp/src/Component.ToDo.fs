namespace Components
open Feliz 
open Feliz.Bulma
open Fable.SimpleJson

module Bestandteile = //Recordtype mit zwei Feldern
    type Komponenten = {
        Aufgaben: string
        Checkbox: bool   
    }

    let localStoragekey = "TODO"
    
    let setToDoLocalStorange (data: Komponenten list) = 
        let JSONString = Json.stringify data
        Browser.WebStorage.localStorage.setItem (localStoragekey, JSONString)

    let getToDoLocalStorage () = 
        let JSONString = Browser.WebStorage.localStorage.getItem (localStoragekey)
        Browser.Dom.console.log (isNull JSONString)
        let result = 
            if isNull JSONString then 
                [
                    {Aufgaben = ""; Checkbox = true}
                ] 
            else 
                Browser.Dom.console.log JSONString
                match Json.tryParseAs<Komponenten list> ( JSONString) with 
                | Ok (parsedData) -> 
                    parsedData
                | Error _ -> 
                    printfn "couldnt parse"
                    [
                        {Aufgaben = ""; Checkbox = true}
                    ]
        result 
    let updateListElement (table: Komponenten list) (i : int) (x : string) : Komponenten list = 
        table 
        |> List.mapi (fun (idx: int) (item: Komponenten) -> 
            if idx = i then
                //let Komponente1 = {item with Aufgaben = x}
                let test =   {Aufgaben = x; Checkbox =item.Checkbox} 
                test
            else 
                item
        )

open Bestandteile

type ToDo = 
    [<ReactComponent>]
    static member ToDoListe () =     
        let Recordtypeliste =  
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
                                            let nextTable = updateListElement table i x 
                                            nextTable |> settable 
                                            nextTable |> setToDoLocalStorange 
                                            //backfromString () |> settable    
                                        )
                                        if element.Checkbox = true then 
                                            prop.style [
                                                style.textDecorationLine.lineThrough
                                                style.color.gray
                                            ]
                                    ]
                                ]
                            ]
                            Html.td [
                                Bulma.control.div [
                                    Bulma.input.checkbox [
                                        prop.onCheckedChange (fun (isChecked:bool) ->
                                            log isChecked
                                            table 
                                            |> List.mapi (fun idx item ->
                                                if idx = i then 
                                                    log item 
                                                    {item with Checkbox=isChecked}
                                                    else item 
                                            )
                                            |> settable
                                        )
                                        prop.isChecked
                                            element.Checkbox
                                    ]
                                ]
                            ] 
                    ]
                ]
            ]
            Bulma.button.button [
                prop.text "Hinzufügen"   
                prop.onClick (fun _ -> (
                    {Aufgaben = input; Checkbox = false} :: table |>settable                       
                ))
            ]      
        ]
    ]
