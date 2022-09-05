namespace gapic

open System
open Argu
open Arguments
open Profile

module Program =

    let runCommands (parser: ArgumentParser<CliArguments>) (args: string array) =
        match (parser.Parse args).GetAllResults() with 
        | [ Profile p ] -> 
            p |> getUser

        | _ -> parser.PrintUsage()

    [<EntryPoint>]
    let main ([<ParamArray>] argv: string[]): int =

        try 
            (ArgumentParser.Create<CliArguments>(), argv)
            ||> runCommands 
            |> printfn "%s"
        with
        | ex -> eprintfn $"{ex.Message}"

        0