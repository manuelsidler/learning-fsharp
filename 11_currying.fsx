open System

// function in curried form
// tupled function would be: let add (first, second) = ...
let add first second = first + second
let addFive = add 5 // returns a function 
let fifteen = addFive 10

// useful for wrapping
let buildDt year month day = DateTime(year, month, day)
let buildDtThisYear = buildDt DateTime.Now.Year // let buildDtThisYear month day
let buildDtThisMonth = buildDtThisYear DateTime.Now.Month // let buildDtThisMonth day
let date = buildDtThisMonth 5