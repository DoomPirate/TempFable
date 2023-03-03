namespace Shared

open System

open FSharp.Data


module Route =
    let builder typeName methodName =
        sprintf "/api/%s/%s" typeName methodName

type ServerError =
    | Exception of string
    | Authentication of string

exception ServerException of ServerError

module ServerError =
    let failwith (er:ServerError) = raise (ServerException er)

    let ofResult<'a> (v:Result<'a,ServerError>) =
        match v with
        | Ok v -> v
        | Error e -> e |> failwith

type Service = {
    Test : unit -> Async<bool>
    }
with
    static member RouteBuilder s m = sprintf "/api/%s/%s"  s m

