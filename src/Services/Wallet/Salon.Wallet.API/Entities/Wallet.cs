using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Salon.WalletBase.API.Entities
{
   public class Wallet:BaseEntity
    {

        [BsonId]
       // [BsonRepresentation(BsonType.ObjectId)]
        public Guid Id { get; set; }
        
        [BsonRepresentation(BsonType.Double)]
        public decimal WalletFund { get; set; }
        public string CustomerId { get; set; }
        public string Description { get; set; }
        public string Comments { get; set; }
       
       
      
    }
}
