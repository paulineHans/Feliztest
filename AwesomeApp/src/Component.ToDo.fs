namespace Components
open Feliz 
open Feliz.Bulma
open Fable.SimpleJson

module Bestandteile = 

    type Komponenten = { //Recordtype with two fields A. Aufgaben & Checkbox 
        Aufgaben: string
        Checkbox: bool   
    }

    let localStoragekey = "TODO" //LocalStorage Key to store and retrieve data under this key
    
    let setToDoLocalStorange (data: Komponenten list) =  // saves the list of tasks in the local storage as a JSON string
        let JSONString = Json.stringify data
        Browser.WebStorage.localStorage.setItem (localStoragekey, JSONString)

    let getToDoLocalStorage () = //Retrieves the data in LocalStorage and returns it; if no data is found, a new list is created
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
    let updateListElement (table: Komponenten list) (i : int) (x : string) : Komponenten list = //Updates an element in the input field using index i
        table 
        |> List.mapi (fun (idx: int) (item: Komponenten) -> 
            if idx = i then
                let test =   {Aufgaben = x; Checkbox =item.Checkbox} 
                test
            else 
                item
        )

open Bestandteile

type ToDo = 
    [<ReactComponent>]
    static member ToDoListe () = //Defines a React component for displaying and editing the to-do list 
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
                    let newlist = List.take (listlength - 1) table |> settable; //Function that deletes the last element from ToDo 
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
                    for i in [0 .. (table.Length - 1)] do //every element of the list
                        let element = table |> List.item i
                        Html.tr [
                            Html.td [
                                Bulma.control.div [
                                    Bulma.input.text [
                                        prop.valueOrDefault element.Aufgaben
                                        prop.placeholder "Aufgabe Hinzufügen"
                                        prop.onChange (fun (x: string) -> // reacts to changes x is the current value of the input 
                                            let nextTable = updateListElement table i x 
                                            nextTable |> settable 
                                            nextTable |> setToDoLocalStorange     
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
