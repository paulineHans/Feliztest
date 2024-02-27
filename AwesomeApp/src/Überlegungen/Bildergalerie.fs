namespace Bildergalrie 
// Code für eine Tabelle, auch benutzbar für ToDoListe 
open Feliz
open Feliz.Bulma
open Fable.React

module Main 

type TableData = {Name: string; Age: int; Country: string}
let initialData : TableData list = 
    [
        {Name= "Pauline"; Age = 22; Country = "Germany"}
        {Name= "Annika"; Age = 21; Country = "Germany"}
    ]
type Message = 
    |NoOp 

let update (msg:Message) (model: TableData list) : TableData list = 
    match msg with 
    |NoOp -> modle 
let view (model:TableData list) dispatch = 
    table [] [
            thead [] [
                tr [] [
                    th [] [str "Pauline"]
                    th [] [str 22]
                    th [] [str "Germany"]
                ]
            ]
    ]
    tbody [](List.map (fun data -> 
        tr [] [
            td [] [str data.navbarMenu]
            td [] [str [string data.Age]]
            td [] [str data.Country ]
        ]) model)
let main = 
    App.simple {
        init = initialData
        update = update
        view = view 
    }

// Html Code für ein Hintergrundbild - wahrscheinlich die bessere Option 

open Feliz
open Feliz.Bulma

let html =
    Html.html [
        Html.lang "de"
        Html.head [
            Html.meta [ Html.charset "UTF-8" ]
            Html.meta [ Html.name "viewport"; Html.content "width=device-width, initial-scale=1.0" ]
            Html.title "Meine Webseite mit Hintergrundbild"
            Html.link [ Html.rel "stylesheet"; Html.href "style.css" ]
        ]
        Html.body [
            h1 [ Bulma.title ] [ str "Willkommen auf meiner Webseite!" ]
        ]
    ]

Program.mkSimple html
|> Program.runBrowser



// Code für Bildergalerie 
// Model
type ImageData = { LargeUrl: string; SmallUrl: string; Description: string }

// Initialer Zustand der Bildergalerie
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

// Message-Typ für Aktualisierungen
type message =
    | NoOp
    // Füge hier weitere Nachrichten für Aktualisierungen hinzu, z.B. Bild hinzufügen, löschen usw.

// Update-Funktion für Nachrichten
let update (msg: Message) (model: ImageData list) : ImageData list =
    match msg with
    | NoOp -> model
    // Implementiere hier andere Aktualisierungen

// View-Funktion für die Bildergalerie
let view (model: ImageData list) dispatch =
    table [ Bulma.table ] [
        tbody [] (model |> List.map (fun imageData ->
            tr [] [
                td [] [
                    a [ Bulma.image; Props.href imageData.LargeUrl ] [
                        img [ Bulma.imageIs64x64; Props.src imageData.SmallUrl; Props.alt imageData.Description ] []
                    ]
                ]
            ]))
    ]

// Hauptfunktion für das Rendern der Bildergalerie
let main =
    Program.mkSimple initialImages update view

// Hier wird die Hauptkomponente gerendert
Program.runBrowser main

