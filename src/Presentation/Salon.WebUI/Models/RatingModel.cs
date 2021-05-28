using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Salon.WebUI.Models
{
    public class RatingModel
    {
        public string SlotId { get; set; }
        public RateType rate { get; set; }
        public string SalonId { get; set; }
        public string CustomerId { get; set; }
        public string ServiceType { get; set; }


    }

    public enum RateType
    {
        OneStar = 1,
        TwoStar = 2,
        ThreeStar = 3,
        FourStar = 4
    }
}
