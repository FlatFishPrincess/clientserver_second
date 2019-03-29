using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employees
{
    // Demonstrates:
    //  Inheritance (Manager, SalesPerson, PT Sales are children of Employee
    //  nested class and "has a" relationship using BenefitPackage, and compare to standalone version of class
    //  enums for benefit package level
    //  casting, and use of as and is keywords

    class EmployeesProgram
    {
        static void Main(string[] args)
        {
            Console.WriteLine("***** The Employee Class Hierarchy *****\n");

            // A better bonus system!
            Manager chucky = new Manager("Chucky", 50, 92, 100000, "333-23-2322", 9000);
            chucky.GiveBonus(300);

            // use the nested class
            chucky.Benefits.benefitPackageLevel = Employee.BenefitPackage.BenefitPackageLevel.Platinum;

            // use the standalone class
            chucky.empBenefits2.benefitPackageLevel = BenefitPackage.BenefitPackageLevel.Platinum;
            chucky.DisplayStats();
 
            Console.WriteLine();

            SalesPerson fran = new SalesPerson("Fran", 43, 93, 3000, "932-32-3232", 31);
            fran.GiveBonus(200);
            fran.DisplayStats();
            Console.WriteLine();

            ArrayOfArbitraryObjects();  // a weird test of casting
            CastingExamples();

            Console.WriteLine();

            // Ack! You can't cast frank to a Hexagon, but this compiles fine!
            object frank = new Manager();
            Hexagon hex;
            try
            {
                hex = (Hexagon)frank;
            }
            catch (InvalidCastException ex)
            {
                Console.WriteLine(ex.Message);
            }

            Console.ReadLine();
        }

        // Silly empty class, just to demonstrate casting
        class Hexagon
        {
            public void Draw() { Console.WriteLine("Drawing a hexagon!"); }
        }

        #region Example of "as" keyword in action

        /// <summary>
        /// In an array of objects, store objects of arbitrary types, then look for anything that is a hexagon
        ///
        /// </summary>
        private static void ArrayOfArbitraryObjects()
        {
            object[] things = new object[4];
            things[0] = new Hexagon();
            things[1] = false;
            things[2] = new Manager();
            things[3] = "Last thing";

            foreach (object item in things)
            {
                Hexagon h = item as Hexagon;
                if (h == null)
                    Console.WriteLine("Item is not a hexagon");
                else
                {
                    h.Draw();
                }
            }
        }
        #endregion

        #region Casting examples
        static void CastingExamples()
        {
            // A Manager "is-a" System.Object, so we can
            // store a Manager reference in an object variable just fine.
            object frank = new Manager("Frank Zappa", 9, 3000, 40000, "111-11-1111", 5);

            // A Manager "is-an" Employee too.
            Employee moonUnit = new Manager("MoonUnit Zappa", 2, 3001, 20000, "101-11-1321", 1);
            GivePromotion(moonUnit);

            // A PTSalesPerson "is-a" SalesPerson.
            SalesPerson jill = new PTSalesPerson("Jill", 834, 3002, 100000, "111-12-1119", 90);
            GivePromotion(jill);
        }
        #endregion

        #region Example of "is" keyword in action
        static void GivePromotion(Employee emp)
        {
            Console.WriteLine("{0} was promoted!", emp.Name);

            // check to see what type of employee, and identify a property for that type

            if (emp is SalesPerson)
            {
                Console.WriteLine("{0} made {1} sale(s)!", emp.Name,
                  ((SalesPerson)emp).SalesNumber);
                Console.WriteLine();
            }
            if (emp is Manager)
            {
                Console.WriteLine("{0} had {1} stock options...", emp.Name,
                  ((Manager)emp).StockOptions);
                Console.WriteLine();
            }
        }
        #endregion
    }
}
