namespace gapic

open Argu
open Resources

module Arguments =

    [<DisableHelpFlags>]
    type CliArguments =
        | [<CliPrefix(CliPrefix.None);AltCommandLine("-u")>] User of string
        | [<CliPrefix(CliPrefix.None);AltCommandLine("-v")>] Version
        | [<CliPrefix(CliPrefix.None);AltCommandLine("-h")>] Help

        interface IArgParserTemplate with
            member this.Usage =
                match this with 
                | User _ -> Arguments_User.ResourceString

                | Version -> Arguments_Version.ResourceString
                | Help -> Arguments_Help.ResourceString
