// For more information see https://aka.ms/fsharp-console-apps
let prefix (prefixStr: string) (baseStr: string) = prefixStr + " , " + baseStr
let names = [ "David"; "Maria"; "Alex" ]
let prefixPartial = prefix "Hello"
let exclaim s = s + "!"
let bigHello = prefixPartial >> exclaim

let hellos =
    //|> Seq.map prefixPartial
//|> Seq.map exclaim
    names
    |> Seq.map (fun x ->
        printfn "mapped over %s" x
        bigHello x)
    |> Seq.sort
    |> Seq.iter (printfn "%s")

hellos

// record type

type Room = { name: string; number: int }
let room = { name = "bang"; number = 12 }
