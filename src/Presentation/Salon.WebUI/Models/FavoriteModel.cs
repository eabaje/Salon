using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Salon.WebUI.Models
{
    public class FavoriteModel
    {
       
        public Guid FavoriteId { get; set; }
        public string ServiceTypeId { get; set; }

        public string SalonId { get; set; }

        public string CategoryId { get; set; }

        public string CustomerId { get; set; }

        public bool IsActive { get; set; }

       

        

    }
}
