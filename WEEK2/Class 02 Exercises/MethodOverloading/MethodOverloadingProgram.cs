using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MethodOverloading
{
    /// <summary>
    /// demonstrates method overloading. Note Add() methods have unique signatures (arguments).
    /// </summary>
    class MethodOverloadingProgram
    {
        static void Main(string[] args)
        {
            Console.WriteLine("***** Fun with Method Overloading *****\n");

            // Calls int version of Add()
            Console.WriteLine(Add(10, 10));

            // Calls long version of Add()
            Console.WriteLine(Add(900000000000, 900000000000));

            // Calls double version of Add()
            Console.WriteLine(Add(4.3, 4.4));

            Console.ReadLine();
        }

        #region Overloaded Add() methods
        // Overloaded Add() method.
        static int Add(int x, int y)
        {
            Console.WriteLine("Add int method");
            return x + y;
        }

        static double Add(double x, double y)
        {
            Console.WriteLine("Add double method");
            return x + y;
        }

        static long Add(long x, long y)
        {
            Console.WriteLine("Add long method");
            return x + y;
        }
        #endregion
    }
}
