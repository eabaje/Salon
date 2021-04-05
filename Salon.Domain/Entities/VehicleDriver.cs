using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Salon.Domain.Entities
{
   public class VehicleDriver
    {

        [Key]
        public int DriverId { get; set; }
        public string DriverName { get; set; }
        public string DriverLicense { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string Region { get; set; }
        public string PostalCode { get; set; }
        public string Country { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public byte[] Picture { get; set; }
        public virtual Company Company { get; set; }

        // public ICollection<Product> Products { get; private set; }
    }
}
