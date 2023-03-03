module Server

open Fable.Remoting.Server
open Fable.Remoting.Giraffe
open Saturn
open Npgsql
open Npgsql.FSharp
open Shared
open FSharp.Data
open ServerTypes
open Microsoft.CognitiveServices.Speech
open Microsoft.CognitiveServices.Speech.Audio
open System.Diagnostics
open System
open System.IO
open System.Net.Http

open System.Data
open System.IO  
open System.Net
open System.IO.Compression
open FSharp.Data.Sql
open System.Management.Automation


open System.IO

let service = {
     Test = fun () -> async {

        return true
     }




}







let webApp =
    Remoting.createApi ()
    |> Remoting.withRouteBuilder Route.builder
    |> Remoting.fromValue service
    |> Remoting.buildHttpHandler

let app =
    application {
        use_router webApp
        memory_cache
        use_static "public"
        use_gzip
    }

[<EntryPoint>]
let main _ =
    run app
    0