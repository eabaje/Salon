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
        Task<UserLocation> GetNearestLocationAsync(double Longitude, double Latitude, double distance,string userip);
    }
}
