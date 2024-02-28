namespace Bildergalrie 
// Code für eine Tabelle, auch benutzbar für ToDoListe 
open Feliz
open Feliz.Bulma
open Fable.React

module Main =

    type TableData = {Name: string; Age: int; Country: string}
    let initialData : TableData list = 
        [
            {Name= "Pauline"; Age = 22; Country = "Germany"}
            {Name= "Annika"; Age = 21; Country = "Germany"}
        ]

    let view (model:TableData list) = 
        Html.table [
            Html.thead [
                Html.tr  [
                    Html.th  [prop.text "Name"]
                    Html.th  [prop.text "Age"]
                    Html.th  [prop.text "Country"]
                ]
            ]
            Html.tbody (List.map (fun data -> 
                Html.tr  [
                    Html.td  [prop.text data.Name]
                    Html.td  [prop.text (string data.Age)]
                    Html.td  [prop.text data.Country ]
                ]) model)
        ]
    

// Code für Bildergalerie 
// Model
type ImageData = { LargeUrl: string; SmallUrl: string; Description: string }

// Initialer Zustand der Bildergalerie
module blub =
    let initialImages : ImageData list =
        [
            { LargeUrl = "bild1-gross.jpg"; SmallUrl = "bild1-klein.jpg"; Description = "Bild 1 Beschreibung" }
            { LargeUrl = "bild2-gross.jpg"; SmallUrl = "bild2-klein.jpg"; Description = "Bild 2 Beschreibung" }
            { LargeUrl = "bild3-gross.jpg"; SmallUrl = "bild3-klein.jpg"; Description = "Bild 3 Beschreibung" } //Insgesamt sind es 16 Bilder 
            { LargeUrl = "bild4-gross.jpg"; SmallUrl = "bild4-klein.jpg"; Description = "Bild 4 Beschreibung" }
            { LargeUrl = "bild5-gross.jpg"; SmallUrl = "bild5-klein.jpg"; Description = "Bild 5 Beschreibung" }
            { LargeUrl = "bild6-gross.jpg"; SmallUrl = "bild6-klein.jpg"; Description = "Bild 6 Beschreibung" }
            // Weitere Bilder hier...
        ]

// module ananas = 

//     let view (model: ImageData list) =
//         Bulma.table  [
//             //Html.tbody [] (model |> List.map (fun imageData ->
//                 tr [] [
//                     td [] [
//                         a [ Bulma.image; Props.href imageData.LargeUrl ] [
//                             img [ Bulma.imageIs64x64; Props.src imageData.SmallUrl; Props.alt imageData.Description ] []
//                         ]
//                     ]
//                 ]))
//         ]


