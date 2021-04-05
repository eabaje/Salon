using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Salon.BarberShopBase.Core.Entities
{
    public class PriceList : BaseEntity
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string PriceListId { get; set; }
        public decimal Price { get; set; }
        public decimal Discount { get; set; }
        public string SalonId { get; set; }
        public string ServiceTypeId { get; set; }
        public string Description { get; set; }
    }
}
