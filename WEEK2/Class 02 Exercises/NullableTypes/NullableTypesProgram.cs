using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NullableTypes
{
    #region Helper class for this example. 
    class DatabaseReader
    {
        // Nullable data field.
        public int? numericValue = null; // so let's set this to null
        public bool? boolValue = true; // test this with null as well

        // Note the nullable return type.
        public int? GetIntFromDatabase()
        {
            return numericValue;
        }

        // Note the nullable return type.
        public bool? GetBoolFromDatabase()
        {
            return boolValue;
        }
    }
    #endregion

    class NullableTypesProgram
    {
        static void Main(string[] args)
        {        
            Console.WriteLine("***** Fun with Nullable Data *****\n");
            DatabaseReader demoDbReader = new DatabaseReader();

            // Get int from "database".
            int? dbIntValue = demoDbReader.GetIntFromDatabase();
            if (dbIntValue.HasValue)
                Console.WriteLine("Value of 'dbIntValue' is: {0}", dbIntValue.Value);
            else
                Console.WriteLine("Value of 'dbIntValue' is undefined.");

            // Get bool from "database".
            bool? dbBoolValue = demoDbReader.GetBoolFromDatabase();
            if (dbBoolValue != null)
                Console.WriteLine("Value of 'dbBoolValue' is: {0}", dbBoolValue.Value);
            else
                Console.WriteLine("Value of 'dbBoolValue' is undefined.");

            // If the value from GetIntFromDatabase() is null,
            // assign local variable to 100.
            int myData = demoDbReader.GetIntFromDatabase() ?? 100;
            Console.WriteLine("Value of myData: {0}", myData);

            // Long hand version of using ? : ?? syntax.
            int? moreData = demoDbReader.GetIntFromDatabase();
            if (!moreData.HasValue)
                moreData = 100;
            Console.WriteLine("Value of moreData: {0}", moreData);

            // Using TesterMethod

            string[] someStrings = { "x", "y" };

            TesterMethod(null);
            TesterMethod(someStrings);


            Console.ReadLine();
        }

        #region Declaring nullable data types.
        static void LocalNullableVariables()
        {
            // Define some local nullable types.
            int? nullableInt = 10;
            double? nullableDouble = 3.14;
            bool? nullableBool = null;
            char? nullableChar = 'a';
            int?[] arrayOfNullableInts = new int?[10];

            // Error! Strings are reference types!
            // string? s = "oops";
        }

        // can also use Nullable<type> generic

        static void LocalNullableVariablesUsingNullable()
        {
            // Define some local nullable types using Nullable<T>.
            Nullable<int> nullableInt = 10;
            Nullable<double> nullableDouble = 3.14;
            Nullable<bool> nullableBool = null;
            Nullable<char> nullableChar = 'a';
            Nullable<int>[] arrayOfNullableInts = new Nullable<int>[10];
        }
        #endregion

        static void TesterMethod(string[] args)
        {
            // We should check for null before accessing the array data!


            // ?? operator 
            // It returns the left-hand operand if the operand is not null; 
            // otherwise it returns the right hand operand

            // int? x = null;
            // Set y to the value of x if x is NOT null; otherwise,
            // if x == null, set y to -1.
            // int y = x ?? -1;


            Console.WriteLine($"You sent me {args?.Length ?? 0} arguments.");
        }
    }
}
