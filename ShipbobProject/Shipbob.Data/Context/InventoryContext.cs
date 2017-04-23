using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Shipbob.Data.Configuration;
using Shipbob.Data.Entities;

namespace Shipbob.Data.Context
{
    internal class InventoryContext : DbContext
    { 
        public InventoryContext()
           :base(DataConfiguration.DatabaseConnectionString)
        {
           // Database.SetInitializer<InventoryContext>(new DropCreateDatabaseAlways<InventoryContext>());
           Database.SetInitializer<InventoryContext>(new CreateDatabaseIfNotExists<InventoryContext>());
        }

        public DbSet<OrderEntity>  Orders { get; set; }

        public DbSet<ItemEntity>  Items { get; set; }

        public DbSet<AddressEntity> Addresses { get; set; }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
