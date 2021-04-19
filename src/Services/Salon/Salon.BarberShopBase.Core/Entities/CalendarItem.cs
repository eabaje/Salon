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

        public WorkDayFormat WorkDayStyle { get; set; }

       
        public TimeSpan? WorkStartTime { get; set; }

        public int DurationInMinutes { get; set; }

        public TimeSpan? WorkEndTime { get; set; }
        public string Comment { get; set; }
       public string SalonId { get; set; }
       public string BarberId { get; set; }


        public string AppointmentTime
        {
            get
            {
                return WorkStartTime.Value.ToString("hh:mm tt") + "-" + WorkEndTime.Value.ToString("hh:mm tt");
            }
        }

    }
    



    public enum WorkDayFormat
    {
        AllWeek = 1,
        WeekDay = 2,
        WeekEnd = 3,
        Saturday = 4,
        Sunday = 5,

    }
}
