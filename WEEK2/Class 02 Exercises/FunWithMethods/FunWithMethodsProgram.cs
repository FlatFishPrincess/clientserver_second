using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FunWithMethods
{
    class FunWithMethodsProgram
    {
        static void Main(string[] args)
        {
            Console.WriteLine("***** Fun with Methods *****\n");

            #region Pass by value

            // Pass two variables in by value.
            int x = 9, y = 10;

            Console.WriteLine($"Before call: X: {x}, Y: {y}");
            Console.WriteLine($"Answer is: {Add(x,y)}");
            Console.WriteLine($"After call: X: {x}, Y: {y}");
            Console.WriteLine();
            #endregion

            #region Output params
            // No need to assign initial value to local variables
            // used as output parameters.

            Add(90, 90, out int ans);

            Console.WriteLine("90 + 90 = {0}", ans);

            FillTheseValues(out int storedInteger, out string storedString, out bool storedBoolean);
            Console.WriteLine("Int is: {0}", storedInteger);
            Console.WriteLine("String is: {0}", storedString);
            Console.WriteLine("Boolean is: {0}", storedBoolean);
            Console.WriteLine();
            #endregion

            #region Ref params
            string s1 = "Flip";
            string s2 = "Flop";
            Console.WriteLine("Before: {0}, {1} ", s1, s2);
            SwapStrings(ref s1, ref s2);
            Console.WriteLine("After: {0}, {1} ", s1, s2);
            Console.WriteLine();
            #endregion

            #region Param array
            // Pass in a comma-delimited list of doubles...
            double average;
            average = CalculateAverage(4.0, 3.2, 5.7, 64.22, 87.2);
            Console.WriteLine("Average of data is: {0}", average);

            // ...or pass an array of doubles.
            double[] data = { 4.0, 3.2, 5.7 };
            average = CalculateAverage(data);
            Console.WriteLine("Average of data is: {0}", average);
            Console.WriteLine();

            // Average of 0 is 0!
            Console.WriteLine("Average of data is: {0}", CalculateAverage());
            Console.WriteLine();
            #endregion

            #region Optional arguments / Named arguments
            EnterLogData("Oh no! Grid can't find data");
            EnterLogData("Oh no! I can't find the payroll data", "CFO");
            Console.WriteLine();

            DisplayFancyMessage(message: "Wow!  Very Fancy indeed!",
                      textColor: ConsoleColor.DarkRed,
                      backgroundColor: ConsoleColor.White);

            DisplayFancyMessage(backgroundColor: ConsoleColor.Green,
                      message: "Testing...",
                      textColor: ConsoleColor.DarkBlue);

            // This is OK, as positional args are listed before named args.
            DisplayFancyMessage(ConsoleColor.Blue,
                        message: "Testing...",
                        backgroundColor: ConsoleColor.White);

            // These work only if all args are optional.
            DisplayFancyMessage(message: "Hello!");
            DisplayFancyMessage(backgroundColor: ConsoleColor.Green);
            #endregion

            Console.ReadLine();
        }

        #region Input paramerters
        
        /// <summary>
        /// Add two numbers, call by value
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns>Sum of the two arguments</returns>
        static int Add(int x, int y)
        {
            int ans = x + y;

            // Caller will not see these changes
            // as you are modifying a copy of the
            // original data.
            x = 10000;
            y = 88888;
            return ans;
        }
        #endregion

        #region Output parameters
        /// <summary>
        /// Add two numbers, and put output in third argument
        /// </summary>
        /// <param name="x">addend</param>
        /// <param name="y">addend</param>
        /// <param name="ans">Sum of the two arguments</param>
        static void Add(int x, int y, out int ans)
        {
            ans = x + y;
        }

        /// <summary>
        /// Example returning multiple output parameters.
        /// </summary>
        /// <param name="a">Set the argument to 9</param>
        /// <param name="b">Set the argument to a string</param>
        /// <param name="c">Set the argument to true</param>
        static void FillTheseValues(out int a, out string b, out bool c)
        {
            a = 9;
            b = "Enjoy your string.";
            c = true;
        }
        #endregion

        #region Ref parameters
        /// <summary>
        /// Provided two arguments, swap their references
        /// </summary>
        /// <param name="s1">reference to a string</param>
        /// <param name="s2">another reference to a string</param>
        public static void SwapStrings(ref string s1, ref string s2)
        {
            string tempStr = s1;
            s1 = s2;
            s2 = tempStr;
        }
        #endregion

        #region Params array
        // Return average of "some number" of doubles.
        static double CalculateAverage(params double[] values)
        {
            Console.WriteLine("You sent me {0} doubles.", values.Length);

            double sum = 0;
            if (values.Length == 0)
                return sum;

            for (int i = 0; i < values.Length; i++)
                sum += values[i];
            return (sum / values.Length);
        }
        #endregion

        #region Optional arguments
        static void EnterLogData(string message, string owner = "Programmer")
        {
            Console.Beep();
            Console.WriteLine("Error: {0}", message);
            Console.WriteLine("Owner of Error: {0}", owner);
        }

        static void DisplayFancyMessage(ConsoleColor textColor = ConsoleColor.Blue,
            ConsoleColor backgroundColor = ConsoleColor.White, string message = "Test Message")
        {
            // Store old colors to restore once message is printed. 
            ConsoleColor oldTextColor = Console.ForegroundColor;
            ConsoleColor oldbackgroundColor = Console.BackgroundColor;

            // Set new colors and print message.
            Console.ForegroundColor = textColor;
            Console.BackgroundColor = backgroundColor;

            Console.WriteLine(message);

            // Restore previous colors. 
            Console.ForegroundColor = oldTextColor;
            Console.BackgroundColor = oldbackgroundColor;
        }
        #endregion
    }
}
