using Shipbob.Data.Entities;
using Shipbob.Data.Entities.Utility;

namespace Shipbob.Data.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using System.Collections.Generic;

    internal sealed class Configuration : DbMigrationsConfiguration<Shipbob.Data.Context.InventoryContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }
        //100 Red baseballs, 100 Blue Bats, and 100 White Hats.
        protected override void Seed(Shipbob.Data.Context.InventoryContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //

            //Entity Framework struggles with immutable design patterns.

            var inventory = new Dictionary<string, List<ItemEntity>>()
            {
                {"baseball", new List<ItemEntity>()},
                {"bat", new List<ItemEntity>()},
                {"hat", new List<ItemEntity>()}
            };

         
            for (int i = 0; i < 100; i++)
            {
                inventory["baseball"].Add(new ItemEntity()
                {
                    ItemId = 0,
                    ItemColor = ItemColors.Red,
                    ItemType = ItemTypes.Baseball,
                    IsSold = false
                   
                });
                inventory["bat"].Add(new ItemEntity()
                {
                    ItemId = 0,
                    ItemColor = ItemColors.Blue,
                    ItemType = ItemTypes.Bat,
                    IsSold = false
                });
                inventory["hat"].Add(new ItemEntity()
                {
                    ItemId = 0,
                    ItemColor = ItemColors.White,
                    ItemType = ItemTypes.Hat,
                    IsSold = false
                });

            }

            context.Items.AddRange(inventory["baseball"]);
            context.Items.AddRange(inventory["bat"]);
            context.Items.AddRange(inventory["hat"]);
            context.SaveChanges();

        }
    }
}
