using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Salon.LocationBase.API.Models
{
   
    public class UserLocation
    {
        public string ip { get; set; }
        public string hostname { get; set; }
        public string type { get; set; }
        public string continent_code { get; set; }
        public string continent_name { get; set; }
        public string country_code { get; set; }
        public string country_name { get; set; }
        public string region_code { get; set; }
        public string region_name { get; set; }
        public string city { get; set; }
        public string zip { get; set; }
        public double? latitude { get; set; }
        public double? longitude { get; set; }
        public Location location { get; set; }
        public TimeZone time_zone { get; set; }
        public Currency currency { get; set; }
        public Connection connection { get; set; }
        public Security security { get; set; }
    }
}
