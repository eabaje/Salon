using Salon.LocationBase.API.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Salon.LocationBase.API.Repositories.Interfaces
{
   public interface ILocationRepository
    {
        Task<bool> AddLocation(Location favorite);
        Task<bool> UpdateLocation(Location favorite);
        Task<bool> Delete(string id);
        Task<Location> GetLocationById(string id);
        Task<Location> GetLocationBySalon(string salonId);
        Task<List<Location>> GetLocation();
        Task<List<Location>> GetLocationByName(string searchName);
    }
}
