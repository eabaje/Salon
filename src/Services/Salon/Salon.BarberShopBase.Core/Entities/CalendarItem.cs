using System;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;


namespace Salon.BarberShopBase.Core.Entities
{
    public class CalendarItem:BaseEntity
    {
        //[BsonId]
        //[BsonRepresentation(BsonType.ObjectId)]

        [Key]
        public int CalenderItemId { get; set; }

        public Guid CalenderId { get; set; }
      
        public DateTime? WorkDate { get; set; }
        public TimeSpan? WorkStartTime { get; set; }

        public int DurationInMinutes { get; set; }

        public TimeSpan? workEndTime { get; set; }
       
        public string SalonId { get; set; }
        public string BarberId { get; set; }
       
        public BookedStatus booked { get; set; }
        public string Comment { get; set; }


    }
    public enum BookedStatus
    {
        NotBooked = 1,
        Booked = 2,
        DontBook = 3,
       
    }
}
