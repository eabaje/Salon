using Microsoft.EntityFrameworkCore;
using Salon.LocationBase.API.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace Salon.LocationBase.API.Data
{
    public class SalonDBContext : DbContext
    {
        public SalonDBContext(DbContextOptions<SalonDBContext> options) : base(options)
        {
        }

        public DbSet<Location> Locations { get; set; }

       
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }

        public override int SaveChanges()
        {
            ChangeTracker.DetectChanges();
            return base.SaveChanges();
        }
    }

}
