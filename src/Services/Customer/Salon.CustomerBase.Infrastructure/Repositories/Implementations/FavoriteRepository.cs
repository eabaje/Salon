
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
    public class FavoriteRepository:IFavoriteRepository
    {
        private readonly PostgresDBContext _context;
        public FavoriteRepository(PostgresDBContext context)
        {
            _context = context;
        }

        public async Task<bool> AddFavorite(Favorite favorite)
        {
            _context.Favorites.Add(favorite);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<bool> UpdateFavorite(Favorite favorite)
        {
            _context.Favorites.Update(favorite);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<bool> Delete(string id)
        {
            var entity = _context.Favorites.FirstOrDefault(t => t.FavoriteId == Guid.Parse(id));
            _context.Favorites.Remove(entity);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<Favorite> GetFavoriteById(string id)
        {
            return await _context.Favorites.FirstOrDefaultAsync(t => t.FavoriteId == Guid.Parse(id));
        }

        public async Task<List<Favorite>> GetFavoriteByCustomer(string customerId)
        {
            return await _context.Favorites.Where(t => t.CustomerId ==customerId).ToListAsync();
        }

        public async Task<Favorite> GetFavoriteBySalon(string salonId)
        {
            return await _context.Favorites.FirstOrDefaultAsync(t => t.SalonId == salonId);
        }

        public async Task<List<Favorite>> GetFavoriteByIsActive(bool isActive)
        { 
            return await _context.Favorites.Where(t => t.IsActive == isActive).ToListAsync();
        }
        public async Task<List<Favorite>> GetFavorite()
        {
            return await _context.Favorites.ToListAsync();
        }
    }
}
