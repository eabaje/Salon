
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Salon.WebUI.Models
{
    public class PriceListModel 
    {
        
        public string PriceListId { get; set; }
        public decimal Price { get; set; }
        public decimal Discount { get; set; }
        public string SalonId { get; set; }
        public string ServiceTypeId { get; set; }
        public string Description { get; set; }
    }
}
