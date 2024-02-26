namespace App

open Feliz
open Feliz.Router
[<AutoOpen>]
module Help = 
    let log = fun o -> Browser.Dom.console.log o

type Components =
    /// <summary>
    /// The simplest possible React component.
    /// Shows a header with the text Hello World
    /// </summary>
    [<ReactComponent>]
    static member HelloWorld() = Html.h1 "Hello World"

    /// <summary>
    /// A stateful React component that maintains a counter
    /// </summary>
    [<ReactComponent>]
    static member Counter() =
        let (count, setCount) = React.useState(0)
        Help.log count
        Html.div [
            Html.h1 [
                prop.text count

                prop.style [
                    style.textAlign.center
                    style.color.gray
                ]
            ]
            Html.button [
                prop.onClick (fun _ -> setCount(count + 1))
                prop.text "Helle Seite der Macht"
                prop.className "HelleSeite m-1"
                //prop.style [
                    //style.backgroundColor.beige
                    //style.color.black
                    //style.padding (length.rem 10)
                    //style.margin(10, 10, 10, 20)
                    //style.boxShadow(10, 10, color.beige)
                    //style.borderBottomColor color.white
                    //style.borderBottomWidth 20
            ]
            Html.button [
                prop.text "Hier To-Do App finden du wirst"
                prop.className "ToDoApp"
            ]
            Html.button [
                prop.onClick (fun _ -> setCount(count + 1))
                prop.text "Dunkle Seite der Macht"
                prop.className "DunkleSeite m-1"
                //prop.style [
                    //style.backgroundColor.black
                    //style.color.black
                    //style.padding (length.rem 10)
                    //style.borderRadius (px(5))
                    //style.cursor "lightsaber"
                    //style.padding (length.rem 10)
                    //style.margin(10, 10, 10, 20)
                    //style.boxShadow(10, 10, color.black)
                    //style.borderBottomColor color.gray
                    //style.borderBottomWidth 20
                ]
 // das isr ein Kommentar 
            ]
     /// <summary>
    /// A React component that uses Feliz.Router
    /// to determine what to show based on the current URL
    /// </summary>
    [<ReactComponent>]
    static member Router() =
        let (currentUrl, updateUrl) = React.useState(Router.currentUrl())
        React.router [
            router.onUrlChanged updateUrl
            router.children [
                match currentUrl with
                | [ ] -> Html.h1 "Index"
                | [ "hello" ] -> Components.HelloWorld()
                | [ "counter" ] -> Components.Counter()
                | otherwise -> Html.h1 "Not found"
            ]
        ]
