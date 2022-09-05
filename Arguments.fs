namespace gapic

open Argu

module Arguments =

    [<DisableHelpFlags>]
    type CliArguments =
        | [<CliPrefix(CliPrefix.None);AltCommandLine("-p")>] Profile of string

        interface IArgParserTemplate with
            member this.Usage =
                match this with 
                | Profile _ -> "Profile of specific user."

