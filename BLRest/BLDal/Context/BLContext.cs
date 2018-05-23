using BLDal.DomainModel;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLDal.Context
{
    public class BLContext : DbContext
    {
        public BLContext() : base("BlueLagoonDB")
        {
            Database.SetInitializer(new ContextInitializer());
            Configuration.ProxyCreationEnabled = false;
        }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Booking>().HasMany(c => c.Extras).WithMany();
        }

        public DbSet<Booking> Bookings { get; set; }

        public DbSet<Package> Packages { get; set; }

        public DbSet<Extra> Extras { get; set; }

    }
}
