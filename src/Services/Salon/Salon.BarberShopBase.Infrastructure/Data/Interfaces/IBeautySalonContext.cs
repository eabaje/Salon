
using MongoDB.Driver;
using Salon.BarberShopBase.Core.Entities;


namespace Salon.BarberShopBase.Infrastructure.Data.Interfaces
{
    public interface IBeautySalonContext
    {
        IMongoCollection<BeautySalon> BeautySalons { get; }
        IMongoCollection<Calendar> Calendars { get; }
        IMongoCollection<CalendarItem> CalendarItems { get; }
        IMongoCollection<Appointment> Appointments { get; }
        IMongoCollection<Barber> Barbers { get; }
        IMongoCollection<Category> Categorys { get; }
        IMongoCollection<ServiceType> ServiceTypes { get; }
        IMongoCollection<Slot> Slots { get; }
        IMongoCollection<PriceList> PriceLists { get; }
        
    }
}
