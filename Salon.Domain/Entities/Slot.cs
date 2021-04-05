using Salon.Domain.Enumerations;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Salon.Domain.Entities
{
   public class Slot : BaseEntity
    {
        [Key]
        public Guid SlotId { get; set; }
        public string SlotName { get; set; }
        public string SalonId { get; set; }
        public string StylerId { get; set; }
       
       
    }
}
