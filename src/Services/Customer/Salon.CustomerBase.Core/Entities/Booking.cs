using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Salon.CustomerBase.Core.Entities
{
    public class Booking: BaseEntity
    {
        
            [Key]
            public Guid BookingId { get; set; }

            public Guid AppointmentId { get; set; }
             public string CalendarId { get; set; }
            public string SalonId { get; set; }
            public string BarberId { get; set; }
            public string CustomerId { get; set; }
            public bool? Accepted { get; set; }
            public DateTime? AppointDate { get; set; }
           public string AppointTime { get; set; }

          public Customer customer { get; set; }
    }
}
