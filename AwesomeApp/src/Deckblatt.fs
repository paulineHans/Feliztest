namespace Deckblatt 
open Feliz

type Components = 
    [<ReactComponent>]
    static member HelloWorld() = Html.h1 "Hello World"


    [<ReactComponent>]
    static member landingPage() =
            let (count, setCount) = React.useState(0)
            Html.div [
                    prop.href "AwesomeApp/src/Deckblatt.png"
            ]
