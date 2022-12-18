﻿// For more information see https://aka.ms/fsharp-console-apps
namespace MyApp
module Program =
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

    let rec iterate f value =
        seq {
            yield value
            yield! iterate f (f value)
        }

    let result = Seq.take 10 (iterate ((*) 2) 1)
    printfn "%A" result

    /// types
    /// tuple parse
    let tryParseTuple intStr =
        try
            let i = System.Int32.Parse intStr
            (true, i)
        with
        | _ -> (false, 0)

    type tryParseResult = { success: bool; value: int }

    let tryParseRecord intStr =
        try
            let i = System.Int32.Parse intStr
            { success = true; value = i }
        with
        | _ -> { success = false; value = 0 }

    let tryParseOption intStr =
        try
            let i = System.Int32.Parse intStr
            Some i
        with
        | _ -> None

    tryParseTuple "99" |> printfn ("%A")
    tryParseRecord "99" |> printfn ("%A")
    tryParseOption "99" |> printfn ("%A")

    tryParseTuple "abc" |> printfn ("%A")
    tryParseRecord "abc" |> printfn ("%A")
    tryParseOption "abc" |> printfn ("%A")

    type ColorUnion =
        | Red
        | Blue
        | Violet

    type ColorEnum =
        | Red = 0
        | Yellow = 1
        | Violet = 2

    let red = Red
    let blue = ColorEnum.Yellow // must qualified
    // yield vs yield!
    let withYieldBang =
        seq {
            for i in 0..10..100 do
                yield! seq { i..1 .. i + 9 }
        }

    let withYield =
        seq {
            for i in 0..10..100 do
                yield seq { i..1 .. i + 9 }
        }
    let result1 = withYieldBang |> Seq.take 20 |> Seq.toList
    let result2 = withYield |> Seq.take 3
    printfn "%A" result1
    printfn "%A" result2
