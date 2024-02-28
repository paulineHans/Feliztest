module Main

open Feliz
open Components
open Browser.Dom
open Fable.Core.JsInterop

importSideEffects "./sytlehover.css"

let root = ReactDOM.createRoot(document.getElementById "feliz-app")
root.render (App.View.Main ())





