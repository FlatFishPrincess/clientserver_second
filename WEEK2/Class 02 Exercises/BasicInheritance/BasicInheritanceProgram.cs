using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasicInheritance
{
    class BasicInheritanceProgram
    {
        static void Main(string[] args)
        {
            Console.WriteLine("***** Basic Inheritance *****\n");
            // Make a Car object and set max speed.
            Car myCar = new Car(80);

            // Set the current speed, and print it.
            myCar.Speed = 50;
            Console.WriteLine($"My {myCar.kindOfCar} car is going {myCar.Speed} MPH");

            // Now make a MiniVan object.

            MiniVan myVan = new MiniVan();
            myVan.Speed = 10;
            Console.WriteLine($"My {myVan.kindOfCar} car is going {myVan.Speed} MPH");

            Console.ReadLine();
        }
    }

    // A simple base class.

    class Car
    {
        public readonly int maxSpeed;
        private int currentSpeed;

        public Car(int max)
        {
            maxSpeed = max;
        }
        public Car()
        {
            maxSpeed = 55;
        }

        // Speed property - do not exceed maxSpeed!

        public string kindOfCar = "Undefined";

        public int Speed
        {
            get { return currentSpeed; }
            set
            {
                currentSpeed = value;
                if (currentSpeed > maxSpeed)
                {
                    currentSpeed = maxSpeed;
                }
            }
        }
    }

    // Minivan is a simple derived class from Car

    class MiniVan : Car
    {
        public MiniVan()
        {
            // kindOfCar = "MiniVan";
            kindOfCar = this.GetType().Name;
        }
    }
}
