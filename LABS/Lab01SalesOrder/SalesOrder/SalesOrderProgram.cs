using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console; // To provide shortcut naming for WriteLine

namespace SalesOrder
{
    class Program
    {
        static void Main(string[] args)
        {
            // set console title 
            Title = "Sales Order";
          
            // stringbuilder to store all items 
            StringBuilder receipt = new StringBuilder("", 200);

            // ititialize total, subtotal, tax and tax rate  
            double itemSubTotal = 0;
            double TAX_RATE = 0.12;
            double tax = 0;
            double total = 0;

            // String format 
            const string reciptFormat = "{0,-25}{1,8:c}";
            const decimal salesTaxRate = .12m; // It means it's a decimal literal,

      
            // userInput is the empty string, so first interation makes it through the loop 
            string command = ""; 

           
            while (command != "q")
            {
                Write("Enter Command (i,p,q)");
                command = ReadLine().ToLower();

                switch (command)
                {
                    // add item and its cost into receipt string builder 
                    case "i":
                        Write("Enter item name: ");
                        string item = ReadLine();
                        Write("Enter item price: ");
                        double cost = Double.Parse(ReadLine());
                        itemSubTotal += cost;
                        // the first arugment should be replaced with reciptFormat
                        receipt.AppendFormat("{0,-25}{1,8:c}\n", item, cost); 
                        break;
                    // dispaly receipt 
                    case "p":
                        BackgroundColor = ConsoleColor.Blue;
                        tax = TAX_RATE * itemSubTotal;
                        total = itemSubTotal + tax;
                        WriteLine("Recipt");
                        Write(receipt);
                        WriteLine("\n{0,-25}{1,8:c}", "SubTotal Items", itemSubTotal);
                        WriteLine("{0,-4}{1:p}{2,22:c}", "Tax", TAX_RATE, tax);
                        WriteLine("{0,-25}{1,8:c}", "Total", total);
                        // WriteLine(reciptFormat, "Tax: " + String.format("{0:p}", SalesTaxRate), total ... ) 
                        ResetColor();
                        break;
                    default:
                        WriteLine("Please Enter (i,p,q)");
                        break;
                }
                Write("Enter Command (i,p,q)");
                command = ReadLine();
            }
        }
    }
}
