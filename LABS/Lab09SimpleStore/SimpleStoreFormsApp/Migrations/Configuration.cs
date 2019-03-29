namespace SimpleStoreFormsApp.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<SimpleStoreFormsApp.EF_Classes.SimpleStoreEntities>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            ContextKey = "SimpleStoreFormsApp.EF_Classes.SimpleStoreEntities";
        }

        protected override void Seed(SimpleStoreFormsApp.EF_Classes.SimpleStoreEntities context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.
        }
    }
}
