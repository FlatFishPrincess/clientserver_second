using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employees
{
  
    // This new type will function as a contained class as a part of Employee

    public class BenefitPackage
    {
        public BenefitPackage()
        {
            benefitPackageLevel = BenefitPackageLevel.Standard;
        }
        /// <summary>
        /// Enum, can be Standard, Gold, or Platinum
        /// Each level has an associated cost
        /// </summary>
        public enum BenefitPackageLevel
        {
            Standard = 100,
            Gold = 200,
            Platinum = 500,
        }

        /// <summary>
        /// The level of the benefit package
        /// </summary>
        public BenefitPackageLevel benefitPackageLevel;

        /// <summary>
        /// Show the deducation from the benefit package level
        ///     Using a cast to double for computing pay later.
        /// </summary>
        /// <returns></returns>
        public double ComputePayDeduction()
        {
            return (double)benefitPackageLevel;
        }
    }
 
}
