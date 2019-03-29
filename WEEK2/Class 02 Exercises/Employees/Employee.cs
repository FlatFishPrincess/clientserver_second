using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace Employees
{
    // abstract because we have a few virtual methods that can be overridden.
    // note that we complete the class with accessor and mutator (set/get)

    abstract partial class Employee
    {
        // we have defined BenefitPackage elsewhere, but this takes precedence.
     
        #region Nested benefit package
        public class BenefitPackage
        {
            public BenefitPackage()
            {
                benefitPackageLevel = BenefitPackageLevel.Standard;
            }
            public enum BenefitPackageLevel
            {
                Standard = 50,
                Gold = 100,
                Platinum = 150,
            }

            public BenefitPackageLevel benefitPackageLevel;

            // Assume we have other members that represent
            // dental/health benefits, and so on.
            public double ComputePayDeduction()
            {
                return (double) benefitPackageLevel;
            }
        }
        #endregion

        #region Class methods 
        public virtual void GiveBonus(float amount)
        {
            Pay += amount;
        }

        public virtual void DisplayStats()
        {
            WriteLine($"Name: {Name}");
            WriteLine($"ID: {ID}");
            WriteLine($"Age: {Age}");
            WriteLine($"Pay: {Pay}");
            WriteLine($"Benefits: {empBenefits.benefitPackageLevel} {empBenefits.ComputePayDeduction()}");
            WriteLine($"SSN: {SocialSecurityNumber}");
        }
        #endregion

        #region Traditional Get / Set method
        // Accessor (get method)
        public string GetName()
        {
            return empName;
        }

        // Mutator (set method)
        public void SetName(string name)
        {
            // Do a check on incoming value
            // before making assignment.
            if (name.Length > 15)
                WriteLine("Error!  Name must be less than 15 characters!");
            else
                empName = name;
        }
        #endregion
    }
}
