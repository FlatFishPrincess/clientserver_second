
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoLotConsoleApp.EF;
using static System.Console;

namespace AutoLotConsoleApp
{
    class AutoLotConsoleAppProgram
    {
        /// <summary>
        /// Demo code to show how to use EF Code First From Database
        /// 
        /// Assumes AutoLot DB has been created already, and EF classes 
        /// have been created.
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {

            WriteLine("***** Fun with ADO.NET EF *****\n");
            int carId = AddNewRecord();
            RemoveRecord(carId);
            WriteLine(carId + " added then deleted");
            PrintAllInventory();
            UpdateRecord(2);
            WriteLine("******* After UpdateRecord ************\n");
            PrintAllInventory();
            FilterWithLINQ();
            ReadLine();

        }

        /// <summary>
        /// Add an arbitrary record to AutoLot
        /// </summary>
        /// <returns></returns>
        private static int AddNewRecord()
        {

            using (var context = new AutoLotEntities())
            {
                try
                {
                    var car = new Inventory()
                    { Make = "Yugo", Color = "Brown", Name = "Brownie" };
                    context.Inventories.Add(car);
                    context.SaveChanges();
                    return car.CarId;
                }
                catch (Exception ex)
                {
                    WriteLine(ex.InnerException.Message);
                    return 0;
                }
            }
        }
        private static void PrintAllInventory()
        {
            // Select all items from the Inventory table of AutoLot,
            // and print out the data using our custom ToString()
            // of the Inventory entity class. 
            using (var context = new AutoLotEntities())
            {
                WriteLine("*** PrintAllInventory ***");
                WriteLine("Using context");
                foreach (Inventory c in context.Inventories)
                {
                    WriteLine(c);
                }

                WriteLine("Using a sql command");

                foreach (Inventory c in context.Inventories.SqlQuery("Select CarId,Make,Color,Name from Inventory where Make=@p0", "BMW"))
                {
                    WriteLine(c);
                }

                WriteLine("Using LINQ filter Only BMWs");

                foreach (Inventory c in context.Inventories.Where(c => c.Make == "BMW"))
                {
                    WriteLine(c);
                }

                WriteLine("Using orders in inventories - nested object from EF");

                foreach (Inventory c in context.Inventories)
                {
                    foreach (Order o in c.Orders)
                    {
                        WriteLine(o);
                    }
                }

                WriteLine("Using any orders for those in inventory using LINQ include");

                foreach (Inventory c in context.Inventories.Include(c => c.Orders))
                {
                    foreach (Order o in c.Orders)
                    {
                        WriteLine(o);
                    }
                }

                WriteLine("Using no lazy loading and direct using Entry()");

                context.Configuration.LazyLoadingEnabled = false;
                foreach (Inventory c in context.Inventories)
                {
                    context.Entry(c).Collection(x => x.Orders).Load();
                    foreach (Order o in c.Orders)
                    {
                        WriteLine(o);
                    }
                }
            }
        }
        private static void FilterWithLINQ()
        {
            using (var context = new AutoLotEntities())
            {

                WriteLine("FilterWithLINQ()");

                // Get all data from the Inventory table.
                // could also write:
                // var allData = (from item in context.Inventories select item).ToArray();
                var allData = context.Inventories.ToArray();

                // Get a projection of new data. 
                var colorsMakes = from item in allData select new { item.Color, item.Make };

                WriteLine("LINQ only colors and makes");
                foreach (var item in colorsMakes)
                {
                    WriteLine(item);
                }

                // Get only items where Color == "Black"

                WriteLine("LINQ only black cars");
                var blackCars = from item in allData
                                where item.Color == "Black"
                                select item;

                foreach (var item in blackCars)
                {
                    WriteLine(item);
                }
            }
        }
        private static void RemoveRecord(int carId)
        {
            // Find a car to delete by primary key.
            using (var context = new AutoLotEntities())
            {
                // See if we have it.
                Inventory carToDelete = context.Inventories.Find(carId);
                if (carToDelete != null)
                {
                    context.Inventories.Remove(carToDelete);
                    context.SaveChanges();
                }
            }
        }

        /// <summary>
        /// Interesting way to delete a car by changing its state to deleted
        /// </summary>
        /// <param name="carId"></param>
        private static void RemoveRecordUsingEntityState(int carId)
        {
            using (var context = new AutoLotEntities())
            {

                Inventory carToDelete = new Inventory() { CarId = carId };
                context.Entry(carToDelete).State = EntityState.Deleted;
                try
                {
                    context.SaveChanges();
                }
                catch (DbUpdateConcurrencyException ex)
                {
                    WriteLine(ex);
                }
            }
        }

        /// <summary>
        /// Find a car by carId and then update it.
        /// </summary>
        /// <param name="carId"></param>
        private static void UpdateRecord(int carId)
        {
            using (var context = new AutoLotEntities())
            {
                // Grab the car, change it, save! 
                Inventory carToUpdate = context.Inventories.Find(carId);

                WriteLine("UpdateRecord: Found " + carToUpdate);
                if (carToUpdate != null)
                {
                    WriteLine("Prior to update " + context.Entry(carToUpdate).State);
                    carToUpdate.Color = "Metallic Blue";
                    WriteLine("After update " + context.Entry(carToUpdate).State);
                    context.SaveChanges();
                }
            }
        }


    }

}
