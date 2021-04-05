using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Salon.BarberShopBase.Core.Entities
{
    public class Customer : BaseEntity
    {
        // [Key]

        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
       
        public string CustomerId { get; set; }
        public string Email { get; set; }
       



    }
}
