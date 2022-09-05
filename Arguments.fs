namespace gapic

open Argu

module Arguments =

    [<DisableHelpFlags>]
    type CliArguments =
        | [<CliPrefix(CliPrefix.None);AltCommandLine("-p")>] Profile of string
        | [<CliPrefix(CliPrefix.None);AltCommandLine("-v");>] Version
        | [<CliPrefix(CliPrefix.None);AltCommandLine("-h");>] Help

        interface IArgParserTemplate with
            member this.Usage =
                match this with 
                | Profile _ -> "Profile of specific user."

                | Version -> "Shows actual application version."
                | Help -> "Displays this help"

