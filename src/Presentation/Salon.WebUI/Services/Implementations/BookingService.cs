using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Salon.CustomerBase.Infrastructure.Repositories.Interfaces;
using Salon.CustomerBase.Infrastructure.Data;
using Salon.CustomerBase.Core.Entities;

namespace Salon.CustomerBase.Infrastructure.Repositories.Implementations
{
    public class BookingService : IBookingService
    {
        private readonly PostgresDBContext _context;
        public BookingService(PostgresDBContext context)
        {
            _context = context;
        }

        public async Task<bool> AddBooking(Booking booking)
        {
            _context.Bookings.Add(booking); 
           return  await  _context.SaveChangesAsync() >0 ;
          
        }

        public async Task<bool> UpdateBooking(Booking booking)
        {
            _context.Bookings.Update(booking);
          return  await _context.SaveChangesAsync() >0 ;
        }

        public async Task<bool> Delete(string id)
        {
            var entity = _context.Bookings.FirstOrDefault(t => t.BookingId == Guid.Parse(id));
            _context.Bookings.Remove(entity);
           return await _context.SaveChangesAsync() > 0;
        }

        public async Task<Booking> GetBookingById(string id)
        {
            return  await _context.Bookings.FirstOrDefaultAsync(t => t.BookingId == Guid.Parse(id));
        }

        public async Task<List<Booking>> GetBooking()
        {
            return await _context.Bookings.ToListAsync();
        }

        public async Task<List<Booking>> GetBookingBySalon(string salonId)
        {
            return await _context.Bookings.Where(p=>p.SalonId==salonId).OrderByDescending(c=>c.CustomerId).ToListAsync();
        }

        public async Task<List<Booking>> GetBookingByCustomerSalon(string salonId, string customerId)
        {
            return await _context.Bookings.Where(p => p.SalonId == salonId && p.CustomerId == customerId).OrderByDescending(c => c.CustomerId).ToListAsync();
        }

    }
}
