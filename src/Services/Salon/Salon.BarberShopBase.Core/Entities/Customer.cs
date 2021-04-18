using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;

namespace Salon.BarberShopBase.Core.Entities
{
    public class Customer : BaseEntity
    {
        // [Key]

        //[BsonId]
        //[BsonRepresentation(BsonType.ObjectId)]
       
        public Guid CustomerId { get; set; }
        public string Email { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }


        public string FullName
        {
            get
            {
                return LastName + ", " + FirstName;
            }
        }

        public string Phone { get; set; }

    }
}
