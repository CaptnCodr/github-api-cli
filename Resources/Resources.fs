namespace gapic

open Extensions.ResourceExt

module Resources =

    [<Literal>]
    let private ResourceFile = "github-api-cli.Resources.Strings"

    type Resource =
        | Arguments_User
        | Arguments_Version
        | Arguments_Help

        member this.ResourceString = 
            ResourceFile |> resourceManager |> getResourceString this

        member this.FormattedString ([<System.ParamArray>] args) =
            ResourceFile |> resourceManager |> getFormattedString this args