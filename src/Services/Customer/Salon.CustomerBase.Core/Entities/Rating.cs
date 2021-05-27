using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Salon.CustomerBase.Core.Entities
{
    public class Rating : BaseEntity
    {
         [Key]

        // [BsonId]
        // [BsonRepresentation(BsonType.ObjectId)]
        public Guid RateId { get; set; }
        public RateType Rate { get; set; }
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
