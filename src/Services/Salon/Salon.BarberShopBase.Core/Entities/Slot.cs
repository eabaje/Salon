using System;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Salon.BarberShopBase.Core.Entities
{
   public class Slot : BaseEntity
    {
        // [Key]

        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string SlotId { get; set; }
        public string SlotName { get; set; }
        public string SalonId { get; set; }
        public string StylerId { get; set; }
       
       
    }
}
