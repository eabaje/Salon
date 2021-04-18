using System;
using System.Collections.Generic;
using System.Text;

namespace Salon.Eventbus.RabbitMQ.Events
{
    public class AddBookingEvent
    {
        public Guid BookingId { get; set; }

        public Guid AppointmentId { get; set; }
        public string CalendarId { get; set; }
        public string SalonId { get; set; }
        public string BarberId { get; set; }
        public string CustomerId { get; set; }
        public bool? Accepted { get; set; }
        public DateTime? AppointDate { get; set; }
        public TimeSpan AppointTime { get; set; }

        public decimal TotalPrice { get; set; }
    }
}
