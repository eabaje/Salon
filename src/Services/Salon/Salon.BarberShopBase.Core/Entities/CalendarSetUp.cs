using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Salon.BarberShopBase.Core.Entities
{
   public  class CalendarSetUp:BaseEntity
    {

        [Key]
        public Guid CalendarSetUpId { get; set; }
        public string SalonId { get; set; }
        public string ServiceTypeId { get; set; }
        public WorkDayFormat WorkDayStyle { get; set; }
        public bool IsManual => true;
        public int WorkStartInHours => 8;
        public TimeSpan OpeningTime =>  new TimeSpan(0, WorkStartInHours, 0,0);
        public int TotalWorkTimeInHours => 12;
        [DataType(DataType.Time)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = @"{0:hh\:mm}")]
        public TimeSpan ClosingTime => new TimeSpan(0, WorkStartInHours + TotalWorkTimeInHours, 0, 0);

        public int WorkTimeInMinutes => 30;

        public int BreakTimeInMinutes => 10;

      
        public BeautySalon salon { get; set; }

        public ServiceType serviceType { get; set; }


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
