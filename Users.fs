namespace gapic

open FsHttp
open FSharp.Data
open System

module Users =

    [<Literal>]
    let Url = "https://api.github.com/users"

    type ProfileResponse = JsonProvider<"./Data/Users.json", ResolutionFolder=__SOURCE_DIRECTORY__>

    let getUser (user: string) : string =
        http {
            GET $"{Url}/{user}"
            header ("Accept") ("application/vnd.github+json")
            UserAgent("GitHub API CLI")
        }
        |> Request.send
        |> Response.toText
        |> ProfileResponse.Parse
        |> fun p ->
            $"""{p.Type}: {p.Login} ({p.HtmlUrl}) since {p.CreatedAt |> fun c -> c.ToString("dd.MM.yyyy HH:mm")} {Environment.NewLine}Followers/Following: {p.Followers}/{p.Following}"""
