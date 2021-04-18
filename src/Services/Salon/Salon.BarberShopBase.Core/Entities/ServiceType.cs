using System;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System.Collections.Generic;
using System.Text;

namespace Salon.BarberShopBase.Core.Entities
{
   public class ServiceType : BaseEntity
    {
        // [Key]

        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string ServiceTypeId { get; set; }
        public string ServiceTypeName { get; set; }
        public string ServiceTypeDesc { get; set; }
        public string CategoryId { get; set; }
    }
}
