using System;

using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Salon.WebUI.Models
{
    public class Appointment 
    {
        
        public Guid AppointmentId { get; set; }
        public string BarberId { get; set; }
        public string SalonId { get; set; }
        public string CustomerId { get; set; }
      //  public string CalendarId { get; set; }
        public int CalenderItemId { get; set; }
        public string ServiceTypeId { get; set; }
        public DateTime? AppointmentDate { get; set; }

        public string AppointmentTime { get; set; }
        


        public AppointmentStatus Status { get; set; }
   
      //  public Customer customer { get; set; }
      


       



    } 
    public enum AppointmentStatus
        {
            Free = 1,
            Booked = 2,
            Confirmed = 3,
            Successfull=4
        }
}
