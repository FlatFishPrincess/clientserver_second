using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StaticDataAndMembers
{
    /// <summary>
    /// create three savings accounts, with three balances. Reset the interest rate.
    /// note that there are three objects, but each has the same interest rate!
    /// note that one can only change the interest rate by using the utility class, SavingsAccount
    /// </summary>
    class StaticDataAndMembersProgram
    {
        static void Main(string[] args)
        {
            Console.WriteLine("***** Fun with Static Data *****\n");

            Console.WriteLine($"Before account set up, Interest Rate is {SavingsAccount.GetInterestRate()}");
            SavingsAccount[] accounts = new SavingsAccount[3];
            
            accounts[0] = new SavingsAccount(50);
            accounts[1] = new SavingsAccount(100);

            // Print the current interest rate.
            Console.WriteLine("2 accounts set up, Interest Rate is: {0}", SavingsAccount.GetInterestRate());

            // Make new object, this does NOT 'reset' the interest rate.
            accounts[2] = new SavingsAccount(10000.75);
            Console.WriteLine("3 new accounts, Interest Rate is: {0}", SavingsAccount.GetInterestRate());
            SavingsAccount.InterestRate = .05;
            Console.WriteLine("Interest Rate is now: {0}", SavingsAccount.InterestRate);

            for(int i = 0; i < accounts.Length; i++)
                Console.WriteLine("Balance for account {1} is {0}, interest rate is {2}", 
                    accounts[i].currentBalance, i, SavingsAccount.GetInterestRate());

            Console.ReadLine();
        }
    }
}
