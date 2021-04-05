using Salon.LocationBase.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Salon.LocationBase.API.Services.Interfaces
{
   public interface ILocationService
    {
        Task<UserLocation> GetLocationAsync(string userIp);
        Task<Location> GetNearestLocationAsync(double Longitude, double Latitude, double distance);
    }
}
