using System.Collections.Generic;
using AutoLotDAL.Models;

namespace AutoLotDAL.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<AutoLotDAL.EF.AutoLotEntities>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            ContextKey = "AutoLotDAL.EF.AutoLotEntities";
        }

        protected override void Seed(AutoLotDAL.EF.AutoLotEntities context)
        {
            var customers = new List<Customer>
            {
                new Customer {FirstName = "Dave", LastName = "Brenner"},
                new Customer {FirstName = "Matt", LastName = "Walton"},
                new Customer {FirstName = "Steve", LastName = "Hagen"},
                new Customer {FirstName = "Pat", LastName = "Walton"},
                new Customer {FirstName = "Bad", LastName = "Customer"},
            };

            context.Customers.AddRange(customers);

            var cars = new List<Inventory>
            {
                new Inventory {Make = "VW", Color = "Black", Name = "Zippy"},
                new Inventory {Make = "Ford", Color = "Rust", Name = "Rusty"},
                new Inventory {Make = "Saab", Color = "Black", Name = "Mel"},
                new Inventory {Make = "Yugo", Color = "Yellow", Name = "Clunker"},
                new Inventory {Make = "BMW", Color = "Black", Name = "Bimmer"},
                new Inventory {Make = "BMW", Color = "Green", Name = "Hank"},
                new Inventory {Make = "BMW", Color = "Pink", Name = "Pinky"},
                new Inventory {Make = "Pinto", Color = "Black", Name = "Pete"},
                new Inventory {Make = "Yugo", Color = "Brown", Name = "Brownie"},
            };

            context.Inventory.AddRange(cars);

            var orders = new List<Order>
            {
                new Order {Car = cars[0], Customer = customers[0]},
                new Order {Car = cars[1], Customer = customers[1]},
                new Order {Car = cars[2], Customer = customers[2]},
                new Order {Car = cars[3], Customer = customers[3]},
            };

            context.Orders.AddRange(orders);

            context.CreditRisks.AddOrUpdate(c => new { c.FirstName, c.LastName },
                new CreditRisk
                {
                    CustId = customers[4].CustId,
                    FirstName = customers[4].FirstName,
                    LastName = customers[4].LastName,
                });
        }
    }
}
