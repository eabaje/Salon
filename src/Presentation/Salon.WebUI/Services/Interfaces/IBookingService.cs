
using Salon.CustomerBase.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Salon.CustomerBase.Infrastructure.Repositories.Interfaces
{
    public interface IBookingService
    {
      
        Task<Booking> GetBookingById(string id);
        Task<List<Booking>> GetBooking();
        Task<List<Booking>> GetBookingBySalon(string salonId);
        Task<List<Booking>> GetBookingByCustomerSalon(string salonId, string customerId);
        Task<bool> AddBooking(Booking booking);
        Task<bool> UpdateBooking(Booking booking);
        Task<bool> Delete(string id);
    }
}
