using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoProps
{
    class AutoPropsProgram
    {
        static void Main(string[] args)
        {
            Console.WriteLine("***** Fun with Automatic Properties *****\n");

            // Make a car.
            Car lonelyCar = new Car();
            lonelyCar.Name = "Ford";
            lonelyCar.Speed = 55;
            lonelyCar.Color = "Red";
            lonelyCar.DisplayStats();

            // here is another way using Automatic Properties (or AutoProps)
            Car anotherCar = new Car()
            {
                Name = "BMW",
                Speed = 60,
                Color = "Black",
            };

            anotherCar.DisplayStats();

            // Put car in the garage.
            Garage myGarage = new Garage(lonelyCar, 4);

            myGarage.MyAuto = anotherCar;
            Console.WriteLine("Number of Cars in garage: {0}", myGarage.NumberOfCars);
            Console.WriteLine("Your car is named: {0}", myGarage.MyAuto.Name);

            Console.ReadLine();
        }
    }
}
