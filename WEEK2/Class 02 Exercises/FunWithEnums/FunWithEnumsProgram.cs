using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FunWithEnums
{
    // This time, EmpType maps to an underlying byte.
    enum EmployeeType : byte
    {
        Manager = 10,
        Grunt = 1,
        Contractor = 100,
        VicePresident = 9
    }

    class FunWithEnumsProgram
    {
        static void Main(string[] args)
        {
            Console.WriteLine("**** Fun with Enums *****\n");
            EmployeeType employee = EmployeeType.Contractor;

            // These types are enums in the System namespace.
            DayOfWeek day = DayOfWeek.Monday;
            ConsoleColor consoleColor = ConsoleColor.Gray;

            EvaluateEnum(employee);
            EvaluateEnum(day);
            EvaluateEnum(consoleColor);
            AskForBonus(EmployeeType.VicePresident);
            Console.ReadLine();
        }

        #region Enum as parameter
        // Enums as parameters.
        static void AskForBonus(EmployeeType e)
        {
            switch (e)
            {
                case EmployeeType.Manager:
                    Console.WriteLine("How about stock options instead?");
                    break;
                case EmployeeType.Grunt:
                    Console.WriteLine("You have got to be kidding...");
                    break;
                case EmployeeType.Contractor:
                    Console.WriteLine("You already get enough cash...");
                    break;
                case EmployeeType.VicePresident:
                    Console.WriteLine("VERY GOOD, Sir!");
                    break;
            }
        } 
        #endregion

        #region Just a test.  Uncomment to verify.
        static void ThisMethodWillNotCompile()
        {
            //// Error! SalesManager is not in the EmpType enum!
           //  EmpType emp = EmpType.SalesManager;

            //// Error! Forgot to scope Grunt value to EmpType enum!
            // EmpType emp = Grunt;
        } 
        #endregion

        #region Examine enum!
        // This method will print out the details of any enum.
        static void EvaluateEnum(System.Enum e)
        {
            Console.WriteLine("=> Information about {0}", e.GetType().Name);

            Console.WriteLine("Underlying storage type: {0}",
              Enum.GetUnderlyingType(e.GetType()));

            // Get all name/value pairs for incoming parameter.
            Array enumData = Enum.GetValues(e.GetType());
            Console.WriteLine("This enum has {0} members.", enumData.Length);

            // Now show the string name and associated value.
            for (int i = 0; i < enumData.Length; i++)
            {
                Console.WriteLine("Name: {0}, Value: {1:D}",
                  enumData.GetValue(i), enumData.GetValue(i));
            }
            Console.WriteLine();
        } 
        #endregion

    }
}
