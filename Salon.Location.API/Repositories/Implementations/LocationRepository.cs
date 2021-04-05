using Microsoft.EntityFrameworkCore;
using Salon.LocationBase.API.Data;
using Salon.LocationBase.API.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Salon.LocationBase.API.Repositories.Implementations
{
    public class LocationRepository
    {

        private readonly SalonDBContext _context;
        public LocationRepository(SalonDBContext context)
        {
            _context = context;
        }

        public async Task<bool> AddLocation(Location Location)
        {
            _context.Locations.Add(Location);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<bool> UpdateLocation(Location Location)
        {
            _context.Locations.Update(Location);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<bool> Delete(string id)
        {
            var entity = _context.Locations.FirstOrDefault(t => t.LocationId == Guid.Parse(id));
            _context.Locations.Remove(entity);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<Location> GetLocationById(string id)
        {
            return await _context.Locations.FirstOrDefaultAsync(t => t.LocationId == Guid.Parse(id));
        }

        public async Task<List<Location>> GetLocationByName(string searchName)
        {
            return await _context.Locations.Where(t => t.LocationName == searchName).ToListAsync();
        }

        public async Task<List<Location>> GetLocation()
        {
            return await _context.Locations.ToListAsync();
        }

    }
}
