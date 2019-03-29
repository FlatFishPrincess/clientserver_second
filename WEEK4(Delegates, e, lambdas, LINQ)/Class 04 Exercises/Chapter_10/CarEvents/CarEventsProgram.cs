﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommonCar;


namespace CarEvents
{
    class CarEventsProgram
    {
        static void Main( string[] args )
        {
            Console.WriteLine("***** Fun with Events *****\n");
            Car myCar = new Car("SlugBug", 100, 10);
            
            // Register event handlers. Two for AboutToBlow, one for Exploded
            myCar.AboutToBlow += CarIsAlmostDoomed;
            myCar.AboutToBlow += CarAboutToBlow;
            myCar.Exploded += CarExploded;
            
            Console.WriteLine("***** Speeding up *****");
            for (int i = 0; i < 6; i++)
                myCar.AccelerateUsingExplicitEvents(20);

            myCar.Exploded -= CarExploded;

            Console.WriteLine("\n***** Speeding up no CarExploded event registered *****");
            for (int i = 0; i < 6; i++)
                myCar.AccelerateUsingExplicitEvents(20);

            Console.ReadLine();
        }

        public static void CarAboutToBlow( string msg )
        { Console.WriteLine("CarAboutToBlow: " + msg); }

        public static void CarIsAlmostDoomed( string msg )
        { Console.WriteLine("CarIsAlmostDoomed: " + msg); }

        public static void CarExploded( string msg )
        { Console.WriteLine("CarExploded: " + msg); }


        // This isn't used, just a demo of now events can be registered

        public static void HookIntoEvents()
        {
            Car newCar = new Car();
            newCar.AboutToBlow += CarAboutToBlowHandler;
        }

        // generated by "bubble" To left if not defined

        static void CarAboutToBlowHandler(string msgForCaller)
        {
            throw new NotImplementedException();
        }
    }
}
