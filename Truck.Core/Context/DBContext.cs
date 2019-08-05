using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Truck.Core.Model;
namespace Truck.Core.Context
{
    public class DBContext : DbContext
    {
        public DBContext() : base("TruckInspection")
        {
            Database.SetInitializer(new CreateDatabaseIfNotExists<DBContext>());
        }

        public virtual DbSet<Model.Truck> Trucks { get; set; }
        public virtual DbSet<Model.Inspection> Inspections { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Properties<DateTime>().Configure(c => c.HasColumnType("datetime2"));
        }
    }
}
