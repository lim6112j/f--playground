namespace MyApp

module StringManipulation =
    let string1 = "Hello from module StringManipulation"
    let string2 = "world"
    /// usi @ to create a verbatim string literal
    let string3 = @"c:\program files\"
    /// using a triple-quote string literal
    let string4 = """He said "hello world" after you did """

    let helloworld = string1 + " " + string2

    /// A string formed by taking the first 7 characters of one of the result strings
    let substring = helloworld.[0..6]

module Tuples =
    let tuple1 = (1, 2, 3)
    let swapElems (a, b) = (b, a)
    let tuple2 = (1, "fred", 3.1415)

module Lists =
    let list1 = []
    let list2 = [ 1; 2; 3 ]
    let list3 = 43 :: list2
    let numberList = [ 1..1000 ]

    /// A List containing all the days of the year
    let dayList =
        [ for month in 1..12 do
              for day in 1 .. System.DateTime.DaysInMonth(2022, month) do
                  yield System.DateTime(2012, month, day) ]

    let blackSquares =
        [ for i in 0..7 do
              for j in 0..7 do
                  if (i + j) % 2 = 1 then
                      yield (i, j) ]

    let squares = numberList |> List.map (fun x -> x * x)

    let sumOfSquaresUpTo =
        numberList |> List.filter (fun x -> x % 3 = 0) |> List.sumBy (fun x -> x * x)

module DefiningClasses =
    type Vector2D(dx: float, dy: float) =
        let length = sqrt (dx * dx + dy * dy)
        member this.DX = dx
        member this.DY = dy
        member this.Length = length
        member this.Scale(k) = Vector2D(k * this.DX, k * this.DY)

    let vector1 = Vector2D(3.0, 4.0)
    let vector2 = vector1.Scale(10.0)

module DefiningGenericClasses =
    type StateTracker<'T>(initalElement: 'T) =
        let mutable states = [ initalElement ]
        member this.UpdateState newState = states <- newState :: states
        member this.History = states
