using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Salon.WebUI.Models
{
   public  class CalendarSetUpModel
    {

       
        public Guid CalendarSetUpId { get; set; }

        public string SalonId { get; set; }
        public string ServiceTypeId { get; set; }


        public WorkDayFormat WorkDayStyle { get; set; }

        public bool IsManual ;

        public int WorkStartInHours ;
        public string OpeningTime  { get; set; }

         public int TotalWorkTimeInHours { get; set; }

        
        public string ClosingTime { get; set; }

        public int WorkTimeInMinutes { get; set; }

        public int BreakTimeInMinutes { get; set; }


       


        public enum WorkDayFormat
        {
            AllWeek = 1,
            WeekDay = 2,
            WeekEnd = 3,
            Saturday = 4,
            Sunday = 5,

        }


    }
   
}
