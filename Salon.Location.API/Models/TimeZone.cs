using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Salon.LocationBase.API.Models
{
    public class TimeZone
    {
        public string id { get; set; }
        public DateTime current_time { get; set; }
        public int? gmt_offset { get; set; }
        public string code { get; set; }
        public bool is_daylight_saving { get; set; }
    }
}
