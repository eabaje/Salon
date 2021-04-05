using System;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Salon.BarberShopBase.Core.Entities
{
    public class Appointment : BaseEntity
    {
        // [Key]

        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string AppointmentId { get; set; }
        public string BarberId { get; set; }
        public string SalonId { get; set; }
        public string CustomerId { get; set; }
        public string CalendarId { get; set; }
        public string ServiceTypeId { get; set; }
        public DateTime? AppointDate { get; set; }
        public string AppointTime { get; set; }

        public Customer customer { get; set; }


    }
}
