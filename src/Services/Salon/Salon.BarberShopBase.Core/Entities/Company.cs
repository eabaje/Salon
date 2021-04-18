using System;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System.Collections.Generic;
using System.Text;

namespace Salon.BarberShopBase.Core.Entities
{
   public  class Company:BaseEntity
    {
        // [Key]

        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string CompanyId { get; set; }
     
        public string CompanyName { get; set; }
        public string ContactTitle { get; set; }
        public string WebSite { get; set; }
        public bool AllowSearch { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string ContactName
        {
            get
            {
                return LastName + ", " + FirstName;
            }
        }
    }
}
