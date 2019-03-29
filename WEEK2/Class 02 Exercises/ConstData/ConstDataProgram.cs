using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConstData
{
    // demostrate that a const cannot be changed

    class MyMathClass
    {
        public static readonly double PI = 3.14;
    }

    class ConstDataProgram
    {
        static void Main(string[] args)
        {
            Console.WriteLine("***** Fun with Const *****\n");
            Console.WriteLine("The value of PI is: {0}, but Microsoft says it is {1}", MyMathClass.PI, Math.PI);
            // Error! Can't change a constant!
            // MyMathClass.PI = 3.1444;

            // Math.PI = 5;

            Console.ReadLine();
        }

        static void LocalConstStringVariable()
        {
            // A local constant data point can be directly accessed.
            const string fixedStr = "Fixed string Data";
            Console.WriteLine(fixedStr);

            // Error!Can’t change a constant after initial value assignment. 
            // fixedStr = "This will not work!";
        }
    }
}

