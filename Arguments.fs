namespace gapic

open Argu
open Resources

module Arguments =

    [<DisableHelpFlags>]
    type CliArguments =
        | [<CliPrefix(CliPrefix.None); AltCommandLine("-u")>] User of string
        | [<CliPrefix(CliPrefix.None); AltCommandLine("-r")>] Repo of string
        | [<CliPrefix(CliPrefix.None); AltCommandLine("-is")>] Issues of string
        | [<CliPrefix(CliPrefix.None); AltCommandLine("-v")>] Version
        | [<CliPrefix(CliPrefix.None); AltCommandLine("-h")>] Help

        interface IArgParserTemplate with
            member this.Usage =
                match this with
                | User _ -> Arguments_User.ResourceString

                | Repo _ -> "Repo"
                | Issues _ -> "Issues of specified repository."
                | Version -> Arguments_Version.ResourceString
                | Help -> Arguments_Help.ResourceString
