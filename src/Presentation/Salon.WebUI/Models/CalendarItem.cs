using System;

using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;


namespace Salon.WebUI.Models
{
    public class CalendarItem
    {   
        public int CalenderItemId { get; set; }

        public Guid CalenderId { get; set; }

        public WorkDayFormat WorkDayStyle { get; set; }

       
        public TimeSpan? WorkStartTime { get; set; }

        public int DurationInMinutes { get; set; }

        public TimeSpan? WorkEndTime { get; set; }
        public string Comment { get; set; }
       public string SalonId { get; set; }
       public string BarberId { get; set; }


        public string AppointmentTime { get; set; }
       

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
