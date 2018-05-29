// nested tuples
let nameAndAge = ("Chuck", "Norris"), 23 // in C# would be Tuple<Tuple<string, string>, Int32>
let name, age = nameAndAge
let (forename, surname), theAge = nameAndAge

// wildcards
let nameAndAge = "Chuck", "Norris", 50
let forename, surname, _ = nameAndAge // not interested in age

// TryParse: C# vs F#
// C#
string number = "123"
int result = 0;
bool parsed = Int32.TryParse(number, out result)

// F#
let result, parsed = Int32.TryParse(number);