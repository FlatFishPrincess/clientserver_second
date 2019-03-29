using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleClassExample
{
    class SimpleClassExampleProgram
    {
        static void Main(string[] args)
        {
            Console.WriteLine("***** Simple Class Example *****\n");

            Console.WriteLine("-- Motorcycles --");

            // Make a Motorcycle with a rider named Tiny
            Motorcycle myMotorCycle = new Motorcycle(5);

            Console.WriteLine(myMotorCycle); // blank name

            myMotorCycle.SetDriverName("Harley");

            Console.WriteLine($"motorcycle name now set, {myMotorCycle}");
            Console.WriteLine("PopAWheely()");
            myMotorCycle.PopAWheely();

            Console.WriteLine("MakeSomeBikes()");
            MakeSomeBikes();

            Console.WriteLine();
            Console.WriteLine("-- Car Example --");

            // Allocate and configure a Car object.
            Car myCar = new Car();
            myCar.carName = "BMW i3";
            myCar.currentSpeed = 10;

            // Speed up the car a few times and print out the
            // new state.
            for (int i = 0; i <= 10; i++)
            {
                myCar.SpeedUp(5);
                myCar.PrintState();
            }
            Console.ReadLine();
        }

        #region Helper function to make some motor bikes...
        static void MakeSomeBikes()
        {
            // driverName = "", driverMaxIntensity = 0  
            Motorcycle firstMotorCycle = new Motorcycle();
            Console.WriteLine($"firstMotorCycle {firstMotorCycle}");

            // driverName = "Tiny", driverMaxIntensity = 10 
            Motorcycle secondMotorCycle = new Motorcycle(name: "Tiny", driverMaxIntensity: 10);
            Console.WriteLine($"secondMotorCycle {secondMotorCycle}");

            // driverName = "", driverMaxIntensity = 7  
            Motorcycle thirdMotorCycle = new Motorcycle(7);
            Console.WriteLine($"thirdMotorCycle {thirdMotorCycle}");
        }
        #endregion
    }
}
