using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeApp
{
    // demonstrates use of get/set properties with a class (Employee)

    class EmployeeAppProgram
    {
        static void Main(string[] args)
        {
            Console.WriteLine("***** Employee App *****\n");
            Employee employee1 = new Employee("Marvin", 456, 30000);
            employee1.GiveBonus(1000);
            employee1.DisplayStats();
            Console.WriteLine("Employee ID : " + employee1.ID);

            Employee employee2 = new Employee("Karth", 25, 22, 40000);
            employee2.DisplayStats();

            // Set and get the Name property.
            employee1.Name = "Okashi";
            Console.WriteLine("Employee1 is now named: {0}", employee1.Name);
            Console.ReadLine();
        }
    }
}
