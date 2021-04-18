using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Salon.LocationBase.API.Models
{
    public class Security
    {
        public bool is_proxy { get; set; }
        public object proxy_type { get; set; }
        public bool is_crawler { get; set; }
        public object crawler_name { get; set; }
        public object crawler_type { get; set; }
        public bool is_tor { get; set; }
        public string threat_level { get; set; }
        public object threat_types { get; set; }
    }
}
