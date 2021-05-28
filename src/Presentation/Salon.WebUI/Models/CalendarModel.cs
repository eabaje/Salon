using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;


namespace Salon.WebUI.Models
{
    public class CalendarModel
    {
       
        public Guid CalenderId { get; set; }

        public DateTime? CalendarDate { get; set; } 
        
        public string SalonId { get; set; }
       
       
       
        public string Comment { get; set; }

        public ICollection<CalendarItemModel> calendarItems { get; set; }
    }
   
}
