using Salon.Domain.Enumerations;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Salon.Domain.Entities
{
   public class Appointment : BaseEntity
    {
        [Key]
        public Guid AppointmentId { get; set; }
        public string SlotId { get; set; }
        public string SalonId { get; set; }
        public string CustomerId { get; set; }

        public DateTime? AppointDate { get; set; }
        public string? AppointTime { get; set; }
        public DateTime? AvailableTime { get; set; }
        public string ServiceTypeId { get; set; }
        
     
    }
}
