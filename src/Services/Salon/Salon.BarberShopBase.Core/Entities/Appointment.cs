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
        public string CalendarId { get; set; }
        public string ServiceTypeId { get; set; }
        public DateTime? AppointDate { get; set; }
        public string AppointTime { get; set; }
       
        public AppointmentStatus Status { get; set; }
   
        public Customer customer { get; set; }
        public BeautySalon salon { get; set; }
        public Barber barber { get; set; }
        public ServiceType serviceType { get; set; }
        public Calendar calender { get; set; }

      

    } 
    public enum AppointmentStatus
        {
            Free = 1,
            Booked = 2,
            Confirmed = 3,
            Successfull=4
        }
}
