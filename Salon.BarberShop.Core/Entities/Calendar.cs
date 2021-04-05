using System;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;


namespace Salon.BarberShopBase.Core.Entities
{
    public class Calendar:BaseEntity
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string CalenderId { get; set; }

        public DateTime? AvailableDate { get; set; }
        public DateTime? AvailableTime { get; set; }

        public int Duration { get; set; }
        public string SalonId { get; set; }
        public string BarberId { get; set; }
       
        public bool booked { get; set; }
        public string Comment { get; set; }
    }
}
