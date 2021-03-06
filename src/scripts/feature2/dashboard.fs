namespace FableTestSplitter

open SharedCode

module Counter  =

    (**
     - title: Counter
     - tagline: The famous Increment/Decrement ported from Elm
    *)

    open Fable.Core
    open Fable.Import
    open Elmish

    // MODEL

    type Model = int

    type Msg =
    | Increment
    | Decrement

    let init() : Model = 0

    // UPDATE

    let update (msg:Msg) (model:Model) =
        match msg with
        | Increment -> model + 1
        | Decrement -> model - 1

    open Fable.Core.JsInterop
    open Fable.Helpers.React.Props
    module R = Fable.Helpers.React

    // VIEW (rendered with React)

    let view model dispatch =
      
      printer "lol"
      R.div []
          [ R.button [ OnClick (fun _ -> dispatch Decrement) ] [ R.str "-" ]
            R.div [] [ R.str (sprintf "%A" model) ]
            R.button [ OnClick (fun _ -> dispatch Increment) ] [ R.str "+" ] ]

    open Elmish.React

    // App
    Program.mkSimple init update view
    |> Program.withConsoleTrace
    |> Program.withReact "elmish-app"
    |> Program.run

// module Helper

// open Fable.Import.Browser

// let private toList (nodeList:NodeListOf<Element>) =
//     let length = nodeList.length - 1.0
//     [0.0 .. length]
//     |> List.map (fun i -> nodeList.item i  :?> HTMLElement)

// let dollar selector (element:HTMLElement) =
//     element.querySelectorAll selector
//     |> toList