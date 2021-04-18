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
        //[BsonId]
        //[BsonRepresentation(BsonType.ObjectId)]

        [Key]
        public Guid CalenderId { get; set; }

        public DateTime? CalendarDate { get; set; } 
        
        public string SalonId { get; set; }
       
       
       
        public string Comment { get; set; }

        public ICollection<CalendarItem> calendarItems { get; set; }
    }
   
}
