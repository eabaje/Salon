using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System.Text;

namespace Salon.BarberShopBase.Core.Entities
{
   public class BeautySalon:BaseEntity
    {
      
      //  [Key]

        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string BeautySalonId { get; set; }
        public string SalonName { get; set; } 
        public string CategoryId { get; set; }

    //    [BsonRepresentation(BsonType.Double)]
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public string Description { get; set; }
        public string Comments { get; set; }
       
       
      
    }
}
