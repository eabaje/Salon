using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Salon.WalletBase.API.Entities
{
    public class Transaction: BaseEntity
    {

            [BsonId]
            [BsonRepresentation(BsonType.ObjectId)]
            public Guid Id { get; set; }
            public DateTime TransactionDate { get; set; }
            public string PaymentId { get; set; }
           public string CustomerId { get; set; }

           public bool IsWallet { get; set; }


    }
}
