using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Salon.CustomerBase.Core.Entities
{
   public class SalonChoice:BaseEntity
    {
      
        [Key]
        public Guid SalonChoiceId { get; set; }

        public string SalonId { get; set; }
        public string SalonName { get; set; } 
        public string CustomerId { get; set; }
       
       
       
      
    }
}
