using System;

namespace SimpleClassExampleFromScratch
{
    class SimpleSingleClassExampleProgram
    {
        static void Main(string[] args)
        {
            Car myCar = new Car();

            myCar.carName = "Corvette";

            for (int i = 0; i < 10; i++)
            {
                myCar.SpeedUp(i);
                myCar.PrintState();
            }
            Console.ReadLine();
        }
    }
}
