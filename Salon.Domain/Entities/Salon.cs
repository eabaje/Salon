using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Salon.Domain.Entities
{
   public class Salon:BaseEntity
    {
      
        [Key]
        public Guid SalonId { get; set; }
        public string SalonName { get; set; } 
        public string CategoryId { get; set; }
        public string LocationId { get; set; }
        public string Description { get; set; }
        public string Comments { get; set; }
       
       
      
    }
}
