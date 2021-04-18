using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System.Linq;
using System.Threading.Tasks;

namespace Salon.BarberShopBase.Core.Entities
{
    public class Barber:BaseEntity
    {
        [Key]

        //[BsonId]
        //[BsonRepresentation(BsonType.ObjectId)]
        public Guid BarberId { get; set; }
        public string BarberName { get; set; }
        public string SalonId { get; set; }

        public string Email { get; set; }

        public DateTime? DOB { get; set; }
        public string Age 
        {
            get
            {
                return DOB.HasValue  ? Convert.ToString(GetAge(DOB.Value)) : "";
                //&& DateTime.TryParse(DOB.Value)
            }


        }
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

