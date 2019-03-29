using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleClassExample
{
    /// <summary>
    /// Car class with name and speed
    /// </summary>
    class Car
    {
        // The 'state' of the Car.
        public string carName;   // car name
        public int currentSpeed; // speed of the car

        #region Constructors
        /// <summary>
        /// default constructor
        /// </summary>
        public Car()
        {
            carName = "Chuck";
            currentSpeed = 10;
        }
        /// <summary>
        /// Overloading, set the name, and let speed be zero
        /// </summary>
        /// <param name="name"></param>
        public Car(string name)
        {
            carName = name;
        }

        /// <summary>
        /// Let the user specify speed and name
        /// </summary>
        /// <param name="name">name of the car</param>
        /// <param name="speed">current speed</param>
        public Car(string name, int speed)
        {
            carName = name;
            currentSpeed = speed;
        }
        #endregion

        // The functionality of the Car.
        /// <summary>
        /// Display the car's state
        /// </summary>
        public void PrintState()
        {
            Console.WriteLine("Car {0} is going {1} KPH.", carName, currentSpeed);
        }

        /// <summary>
        /// Increase speed of car
        /// </summary>
        /// <param name="delta">amount to increase speed</param>
        public void SpeedUp(int delta)
        {
            currentSpeed += delta;
        }
    }
}
