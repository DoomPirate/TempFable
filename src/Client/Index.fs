module Index

open Feliz
open Elmish
open FSharp.Core
open Feliz.Bulma
open Fable.Import
open FSharp.Collections
open Fable.Core


type Model =
    { Active: bool
     }

type Msg =
    | Test

let init () : Model * Cmd<Msg> =

    let model: Model =
        { Active = true
        }

    model, Cmd.none

let update (msg: Msg) (model: Model) : Model * Cmd<Msg> =
    match msg with
    | Test ->
       model, Cmd.none

let view (model: Model) (dispatch: Msg -> unit) =
    Html.div "hello world"