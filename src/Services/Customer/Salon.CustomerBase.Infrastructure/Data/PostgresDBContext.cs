using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Salon.CustomerBase.Core.Entities;

namespace Salon.CustomerBase.Infrastructure.Data
{
    public class PostgresDBContext : DbContext
    {
        public PostgresDBContext(DbContextOptions<PostgresDBContext> options) : base(options)
        {
        }

        public DbSet<Customer> Customers { get; set; }

        public DbSet<Booking> Bookings { get; set; }
        public DbSet<Favorite> Favorites { get; set; }

        public DbSet<Rating> Ratings { get; set; }
        public DbSet<SalonChoice> SalonChoices { get; set; }
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
