namespace Liste
open Feliz

type ToDoListe = 
    [<ReactComponent>]
        static member ToDo () =
            Html.div [
                prop.text "Das hier To-Do-Liste sein"
            ]