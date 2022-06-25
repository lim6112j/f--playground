// For more information see https://aka.ms/fsharp-console-apps
let prefix prefixStr baseStr = prefixStr + " , " + baseStr
let names = [ "David"; "Maria"; "Alex" ]
let prefixPartial = prefix "Hello"
let exclaim s = s + "!"

names
|> Seq.map prefixPartial
|> Seq.map exclaim
|> Seq.sort
