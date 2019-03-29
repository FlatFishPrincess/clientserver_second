using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OptionalParams
{
    class OptionalParamsProgram
    {
        static void Main(string[] args)
        {
            Console.WriteLine(Add(5, 7));        // normal use
            Console.WriteLine(Add(5));           // use default for 2nd param
            Console.WriteLine(Add(y: 3, x: 8));  // note reverse order, but params are specified
            Console.WriteLine(Add(1, 2, 4));
            Console.ReadLine();
        }
        /// <summary>
        /// add two numbers together
        /// </summary>
        /// <param name="x">first addend</param>
        /// <param name="y">second addend</param>
        /// <returns>sum of x and y</returns>
        static int Add(int x, int y = 10)
        {
            Console.WriteLine("In Add(x, y)");
            Console.WriteLine("In Add(x, y)" +  x + " " + y);
            return x + y;
        }

        /// <summary>
        /// add a list of arguments together
        /// </summary>
        /// <param name="args">comma separated list of int arguments</param>
        /// <returns>sum of the arguments</returns>
        static int Add(params int[] args)
        {
            Console.WriteLine("In Add(params)");
            int sum = 0;

            foreach (int arg in args)
                sum += arg;
            return sum;
        }
    }
}
