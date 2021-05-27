using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

using System.Linq;
using System.Threading.Tasks;

namespace Salon.WebUI.Models
{
    public class Barber
    {
      
        public Guid BarberId { get; set; }
        public string BarberName { get; set; }
        public string SalonId { get; set; }

        public string Email { get; set; }

        public DateTime? DOB { get; set; }
        public string Age { get; set; }
       
        public string Address { get; set; }
        public string YearExperience { get; set; }
        public string PicUrl { get; set; }
        public string Comments { get; set; }




        public static int GetAge(DateTime birthDate)
        {
            DateTime n = DateTime.Now; // To avoid a race condition around midnight
            int age = n.Year - birthDate.Year;

            if (n.Month < birthDate.Month || (n.Month == birthDate.Month && n.Day < birthDate.Day))
                age--;

            return age;
        }

    }
}

