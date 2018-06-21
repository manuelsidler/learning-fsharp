open System.Collections.Generic

let inventory : IDictionary<string, float> =
    [ "Apples", 0.33; "Oranges", 0.23; "Bananas", 0.45 ]
    |> dict // make it immutable

let bananas = inventory.["Bananas"]

// throws "NotSupportedException" because dictionary is immutable
inventory.Add("Pineapples", 0.85)
inventory.Remove("Bananas")