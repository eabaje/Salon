using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Salon.BarberShopBase.Core.Entities
{
   public  class CalendarSetUp
    {

        public string SalonId { get; set; }
        public string BarberId { get; set; }

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

        public Barber barber { get; set; }

      



    }
   
}
