using System;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Salon.BarberShopBase.Core.Entities
{
   public class Rating : BaseEntity
    {
        // [Key]

       // [BsonId]
       // [BsonRepresentation(BsonType.ObjectId)]
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
