// For more information see https://aka.ms/fsharp-console-apps
open System.Net.Http
open System.Net.Http.Json

printfn "Starting Battle!"

type magicCard = {
    name: string
}

let client = new HttpClient()

client.DefaultRequestHeaders.Add(name = "User-Agent", value = "ConsolePokeVsMTG/1.0")
client.DefaultRequestHeaders.Add(name = "Accept", value = "application/json")

let scryfallURL = "https://api.scryfall.com/cards/random"

let main =
    task {
        try 
            let! responseBody = client.GetFromJsonAsync<magicCard>(requestUri = scryfallURL)

            printfn $"{responseBody.name}"
        with
        | :? HttpRequestException as (e: HttpRequestException) ->
            printfn "\nException Caught!"
            printfn $"Message :{e.Message}"
    }

main.Wait()