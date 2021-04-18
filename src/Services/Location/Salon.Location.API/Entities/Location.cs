using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Salon.LocationBase.API.Entities
{
    public class Location
    {
        [Key]
        public Guid LocationId { get; set; }

        public string LocationName { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }

        public string SalonId { get; set; }

    }
}
