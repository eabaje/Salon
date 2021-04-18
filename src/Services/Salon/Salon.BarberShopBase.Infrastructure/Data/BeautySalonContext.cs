
using MongoDB.Driver;

using Salon.BarberShopBase.Infrastructure.Settings;

using Salon.BarberShopBase.Infrastructure.Data.Interfaces;
using Salon.BarberShopBase.Core.Entities;

namespace Salon.BarberShopBase.Infrastructure.Data
{
    public class BeautySalonContext : IBeautySalonContext
    {
        public BeautySalonContext(IBarberDatabaseSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);

            //Products = database.GetCollection<Product>(settings.CollectionName);
            //CatalogContextSeed.SeedData(Products);
        }

       

        public IMongoCollection<BeautySalon> BeautySalons { get; }
        public IMongoCollection<Barber> Barbers { get; }
       public IMongoCollection<Appointment> Appointments { get; }
        public IMongoCollection<Calendar> Calendars { get; }
        public IMongoCollection<CalendarItem> CalendarItems { get; }
        //  public IMongoCollection<Location> Locations { get; }
        public IMongoCollection<Category> Categorys { get; }
        public IMongoCollection<ServiceType> ServiceTypes { get; }
        public IMongoCollection<Slot> Slots { get; }
        public IMongoCollection<PriceList> PriceLists { get; }
        
    }
}
