using Microsoft.EntityFrameworkCore;
using Salon.CustomerBase.Core.Entities;
using Salon.CustomerBase.Infrastructure.Data;
using Salon.CustomerBase.Infrastructure.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Salon.CustomerBase.Infrastructure.Repositories.Implementations
{
   public class RatingRepository : IRatingRepository
    {
        private readonly PostgresDBContext _context;
        public RatingRepository(PostgresDBContext context)
        {
            _context = context;
        }

        public async Task<bool> AddRating(Rating Rating)
        {
            _context.Ratings.Add(Rating);
            return await _context.SaveChangesAsync() > 0;

        }

        public async Task<bool> UpdateRating(Rating Rating)
        {
            _context.Ratings.Update(Rating);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<bool> Delete(string id)
        {
            var entity = _context.Ratings.FirstOrDefault(t => t.RateId == Guid.Parse(id));
            _context.Ratings.Remove(entity);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<Rating> GetRatingById(string id)
        {
            return await _context.Ratings.FirstOrDefaultAsync(t => t.RateId == Guid.Parse(id));
        }

        public async Task<List<Rating>> GetRatings()
        {
            return await _context.Ratings.ToListAsync();
        }

        public async Task<List<Rating>> GetRatingsBySalon(string salonId)
        {
            return await _context.Ratings.Where(p => p.SalonId == salonId).OrderByDescending(c => c.CustomerId).ToListAsync();
        }

        public async Task<List<Rating>> GetRatingsByCustomerSalon(string salonId, string customerId)
        {
            return await _context.Ratings.Where(p => p.SalonId == salonId && p.CustomerId == customerId).OrderByDescending(c => c.CustomerId).ToListAsync();
        }
    }
}
