using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoLotConsoleApp.EF
{
    public partial class Inventory
    {
        public override string ToString()
        {
            // Since the Name column could be empty, supply
            // the default name of **No Name**.
            return $"{this.Name ?? "**No Name**"} is a {this.Color} {this.Make} with ID {this.CarId}.";
        }
    }

    public partial class Order
    {
        public override string ToString()
        {
            return $"OrderId = {OrderId}, car #{CarId} {Inventory.Make} {Inventory.Name}, for {Customer.FirstName} {Customer.LastName} ";
        }
    }
}