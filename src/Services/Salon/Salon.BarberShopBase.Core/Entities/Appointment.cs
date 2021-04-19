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
        //[BsonId]
        //[BsonRepresentation(BsonType.ObjectId)]

        [Key]

        public Guid AppointmentId { get; set; }
        public string BarberId { get; set; }
        public string SalonId { get; set; }
        public string CustomerId { get; set; }
      //  public string CalendarId { get; set; }
        public int CalenderItemId { get; set; }
        public string ServiceTypeId { get; set; }
        public DateTime? AppointmentDate { get; set; }

        public string AppointmentTime
        {
            get
            {
                return calender.WorkStartTime.Value.ToString("hh:mm tt") + "-" + calender.WorkEndTime.Value.ToString("hh:mm tt");
            }
        }


        public AppointmentStatus Status { get; set; }
   
        public Customer customer { get; set; }
        public BeautySalon salon { get; set; }
        public Barber barber { get; set; }
        public ServiceType serviceType { get; set; }
        public CalendarItem calender { get; set; }


       



    } 
    public enum AppointmentStatus
        {
            Free = 1,
            Booked = 2,
            Confirmed = 3,
            Successfull=4
        }
}
