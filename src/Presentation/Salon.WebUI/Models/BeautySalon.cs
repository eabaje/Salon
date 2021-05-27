using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

using System.Text;

namespace Salon.WebUI.Models
{
   public class BeautySalon
    {
      
       
        public Guid BeautySalonId { get; set; }
        public string SalonName { get; set; }
        public string Email { get; set; }

        public string ContactName { get; set; }

        public string Phone { get; set; }
        public string CategoryId { get; set; }

    //    [BsonRepresentation(BsonType.Double)]
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public string Description { get; set; }
        public string Comments { get; set; }


       
       
      
    }
}
