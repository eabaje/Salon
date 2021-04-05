using Salon.BarberShopBase.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Salon.BarberShopBase.Infrastructure.Repositories.Interfaces
{
    public interface ICalendarRepository
    {
        Task<IEnumerable<Calendar>> GetCalendar();
        Task<Calendar> GetCalendar(string id);

        Task<IEnumerable<Calendar>> GetCalendarBySalon(string salonId);
        Task<IEnumerable<Calendar>> GetCalendarByBarber(string salonId,string barberId);
       Task<IEnumerable<Calendar>> GetCalendarByBooked(bool booked);
        Task<IEnumerable<Calendar>> GetCalendarByDate(DateTime fromDate, DateTime ToDate,string salonId);
        Task<bool> Create(Calendar calendar);
        Task<bool> Update(Calendar calendar);
        Task<bool> Delete(string id);
    }
}
