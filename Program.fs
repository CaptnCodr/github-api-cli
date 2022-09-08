namespace gapic

open System
open System.Reflection
open Argu
open Arguments

module Program =

    let runCommands (parser: ArgumentParser<CliArguments>) (args: string array) =
        match (parser.Parse args).GetAllResults() with 
        | [ User p ] ->  
            p |> Users.getUser

        | [ Version ] -> 
            Assembly.GetExecutingAssembly().GetName().Version |> string

        | [ Help ] -> 
            parser.PrintUsage()

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