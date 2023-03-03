module View


open Feliz
open Feliz.UseElmish
open Router
open Elmish
open SharedView

open Feliz.Bulma

type private Msg =
    | UrlChanged of Page


type private State = {
    Page : Page
}

let private init () =
    let nextPage = Router.currentPath() |> Page.parseFromUrlSegments
    { Page = nextPage}, Cmd.navigatePage nextPage

let private update (msg:Msg) (state:State) : State * Cmd<Msg> =
    match msg with
    | UrlChanged page -> { state with Page = page }, Cmd.none

[<ReactComponent>]
let AppView () =

    let state,dispatch = React.useElmish(init, update)
    let render =
        match state.Page with
        | Page.Index ->
                                    Html.div "HEllo world"


    React.router [
        router.pathMode
        router.onUrlChanged (Page.parseFromUrlSegments >> UrlChanged >> dispatch)
        router.children [  render ]
    ]
