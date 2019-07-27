namespace FSharpCode

type Car =
    { 
        /// Number of wheels on the car. 
        Wheels : int

        /// Brand of the car
        Brand : string

        /// The x/y of the car in meters
        Dimensions: float * float
    }

type Vehicle =
    | Motorcar of Car
    | Motorbike of Name:string * EngineSize:float

module Functions =
    let CreateCar wheels brand x y =
        { Wheels = wheels; Brand = brand; Dimensions = x, y }

    let CreateFourWheeledCar = CreateCar 4