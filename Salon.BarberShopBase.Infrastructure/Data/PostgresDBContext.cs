using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Salon.BarberShopBase.Core.Entities;
using Salon.BarberShopBase.Infrastructure.Data;
namespace Salon.BarberShopBase.Infrastructure.Data
{
    public class PostgresDBContext : DbContext
    {
        public PostgresDBContext(DbContextOptions<PostgresDBContext> options) : base(options)
        {
        }

        public DbSet<Customer> Customers { get; set; }
        public DbSet<BeautySalon> BeautySalons { get; }
        public DbSet<Barber> Barbers { get; }
        public DbSet<Appointment> Appointments { get; }
        public DbSet<Calendar> Calendars { get; }
        //  public DbSet<Location> Locations { get; }
        public DbSet<Category> Categorys { get; }
        public DbSet<ServiceType> ServiceTypes { get; }
        public DbSet<PriceList> PriceLists { get; }
       
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
