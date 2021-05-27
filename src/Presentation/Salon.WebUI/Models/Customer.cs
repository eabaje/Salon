
using System;

namespace Salon.WebUI.Models
{
    public class Customer 
    {
        // [Key]

        //[BsonId]
        //[BsonRepresentation(BsonType.ObjectId)]
       
        public Guid CustomerId { get; set; }
        public string Email { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }

        public string FullName { get; set; }

      


        public string Phone { get; set; }

    }
}
