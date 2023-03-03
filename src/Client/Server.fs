module Server

open Fable.Remoting.Client
open Shared
open Fable.SimpleJson


let baseUrl =
        "http://localhost:8080"

let private exnToError (e:exn) : ServerError =
    match e with
    | :? ProxyRequestException as ex ->
        try
            let serverError = Json.parseAs<{| error: ServerError |}>(ex.Response.ResponseBody)
            serverError.error
        with _ -> ServerError.Exception(e.Message)
    | _ -> ServerError.Exception(e.Message)

type ServerResult<'a> = Result<'a,ServerError>

module Cmd =
    open Elmish

    module OfAsync =
        let eitherAsResult fn resultMsg =
            Cmd.OfAsync.either fn () (Result.Ok >> resultMsg) (exnToError >> Result.Error >> resultMsg)


let mutable api =
        Remoting.createApi()
        |> Remoting.withBaseUrl baseUrl
        |> Remoting.withRouteBuilder Service.RouteBuilder
        |> Remoting.buildProxy<Service>
