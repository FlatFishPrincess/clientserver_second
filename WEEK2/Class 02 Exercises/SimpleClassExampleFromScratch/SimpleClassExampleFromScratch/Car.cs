using System;

namespace SimpleClassExampleFromScratch
{
    class Car
    {
        // The 'state' of the Car.
        public string carName;
        public int currentSpeed;

        // The functionality of the Car.
        public void PrintState()
        {
            Console.WriteLine("{0} is going {1} MPH.", carName, currentSpeed);
        }

        public void SpeedUp(int delta)
        {
            currentSpeed += delta;
        }
    }
}