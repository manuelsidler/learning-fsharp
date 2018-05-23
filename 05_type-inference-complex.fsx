let sayHello(someValue) =
    let innerFunction(number) =
        if number > 10 then "Mike"
        elif number > 20 then "Lorena"
        else "Sandra"
       
    let resultOfInner = 
        if someValue < 10.0 then innerFunction(5)
        else innerFunction(15)
    "Hello " + resultOfInner

let result = sayHello(10.5)