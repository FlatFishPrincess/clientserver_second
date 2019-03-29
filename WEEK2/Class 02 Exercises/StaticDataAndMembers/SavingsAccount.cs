using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StaticDataAndMembers
{
    // A simple savings account class.
    class SavingsAccount
    {
        // Instance level data. 
        public double currentBalance;

        // A static point of data. Once set, this doesn't change across objects.
        private static double currentInterestRate;

        // Static constructor is used to initialize static data members as soon as the 
        // class is referenced first time, whereas an instance constructor 
        // is used to create an instance of that class with keyword.
        //
        // A static constructor! As it only sets default interest rate
        static SavingsAccount()
        {
            Console.WriteLine("In static constructor!");
            currentInterestRate = 0.04;
        }

        // instance constructors

        public SavingsAccount(double balance)
        {
            currentBalance = balance;
        }

        public SavingsAccount()
        {
            currentBalance = 0;
        }

        #region Get / Set methods for interest rate
        // Static members to get/set interest rate.
        public static void SetInterestRate(double newRate)
        {
            currentInterestRate = newRate;
        }

        public static double GetInterestRate()
        {
            return currentInterestRate;
        }
        #endregion

        // A static property.
        public static double InterestRate
        {
            get { return currentInterestRate; }
            set { currentInterestRate = value; }
        }

        // public static double InterestRate { get; set; }
    }
}
