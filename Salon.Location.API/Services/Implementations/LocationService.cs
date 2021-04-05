using Salon.LocationBase.API.Models;
using Salon.LocationBase.API.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Http;

namespace Salon.LocationBase.API.Services.Implementations
{
    public class LocationService:ILocationService
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly ILogger<LocationService> _logger;
        private readonly HttpClient _httpClient;
        public LocationService(IHttpClientFactory httpClientfactory, ILogger<LocationService> logger)
        {
            _httpClientFactory = httpClientfactory;
            _logger = logger;
        }

        //public async Task<IPAddress> GetUserIPAsync()
        //{
        //    var client = _httpClientFactory.CreateClient("IP");
        //    return await client.GetAsync<IPAddress>("/");
        //}


        public async Task<UserLocation> GetLocationAsync(string userIp)
        {
            string path = $"{userIp}?access_key=Your_Secured_Key";
            var client = _httpClientFactory.CreateClient("Location");
            //return await client.GetAsync<UserLocation>(path);
            try
            {
                var response = await client.GetAsync(path);

            if (response.IsSuccessStatusCode)
            {
                var json = await response.Content.ReadAsStringAsync();

                return JsonConvert.DeserializeObject<UserLocation>(json);
            }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Failed to retrieve geo info");
            }

            return null;

        }


        public async Task<UserLocation> GetNearestLocationAsync(double Longitude, double Latitude, double distance)
        {
            string path = $"{userIp}?access_key=Your_Secured_Key";
            var client = _httpClientFactory.CreateClient("Location");
            //return await client.GetAsync<UserLocation>(path);
            try
            {
                var response = await client.GetAsync(path);

                if (response.IsSuccessStatusCode)
                {
                    var json = await response.Content.ReadAsStringAsync();

                    return JsonConvert.DeserializeObject<UserLocation>(json);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Failed to retrieve geo info");
            }

            return null;

        }

        double degreesToRadians(double degrees)
        {
            return degrees * Math.PI / 180;
        }
        double distanceInKmBetweenEarthCoordinates(double lat1, double lon1, double lat2, double lon2)
        {
            var earthRadiusKm = 6371;

            var dLat = degreesToRadians(lat2 - lat1);
            var dLon = degreesToRadians(lon2 - lon1);

            lat1 = degreesToRadians(lat1);
            lat2 = degreesToRadians(lat2);

            var a = Math.Sin(dLat / 2) * Math.Sin(dLat / 2) +
                    Math.Sin(dLon / 2) * Math.Sin(dLon / 2) * Math.Cos(lat1) * Math.Cos(lat2);
            var c = 2 * Math.Atan2(Math.Sqrt(a), Math.Sqrt(1 - a));
            return earthRadiusKm * c;
        }

        static double _eQuatorialEarthRadius = 6378.1370D;
        static double _d2r = (Math.PI / 180D);

        private static int HaversineInM(double lat1, double long1, double lat2, double long2)
        {
            return (int)(1000D * HaversineInKM(lat1, long1, lat2, long2));
        }

        private static double HaversineInKM(double lat1, double long1, double lat2, double long2)
        {
            double dlong = (long2 - long1) * _d2r;
            double dlat = (lat2 - lat1) * _d2r;
            double a = Math.Pow(Math.Sin(dlat / 2D), 2D) + Math.Cos(lat1 * _d2r) * Math.Cos(lat2 * _d2r) * Math.Pow(Math.Sin(dlong / 2D), 2D);
            double c = 2D * Math.Atan2(Math.Sqrt(a), Math.Sqrt(1D - a));
            double d = _eQuatorialEarthRadius * c;

            return d;
        }
    }
}

//SELECT latitude, longitude, SQRT(

//    POW(69.1 * (latitude - [startlat]), 2) +

//    POW(69.1 * ([startlng] - longitude) * COS(latitude / 57.3), 2)) AS distance

//FROM TableName HAVING distance < 25 ORDER BY distance;