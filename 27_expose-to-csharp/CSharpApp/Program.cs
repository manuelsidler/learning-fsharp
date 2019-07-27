using System;
using FSharpCode;

namespace CSharpApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var car = new Car(10, "Audi", Tuple.Create(2.5, 3.7)); // Go to definition will show implemented interfaces like IEquatable

            var motorbike = Vehicle.NewMotorbike("Harley", 4.0); // returns Vehicle, not Motorbike
            var isMotorbike = motorbike.IsMotorbike;

            // C# pattern matching
            switch (motorbike)
            {
                case Vehicle.Motorbike mb : break;
                case Vehicle.Motorcar mc: break;
                default:
                    break;
            }

            // Call F# functions
            // F# modules are renderes as static classes
            var car2 = Functions.CreateCar(2, "BMW", 4.0, 6.5);
            var car3 = Functions.CreateFourWheeledCar // curried function needs to be invoked for every parameter
                .Invoke("Mercedes")
                .Invoke(1.5)
                .Invoke(2.5);
        }
    }
}
