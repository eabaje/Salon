using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Salon.CustomerBase.Core.Entities
{
    public class Customer:BaseEntity
    {
        [Key]
        public Guid CustomerId { get; set; }

        public string LastName { get; set; }
        public string FirstName { get; set; }

       
        public string FullName
        {
            get
            {
                return LastName + ", " + FirstName;
            }
        }

        [DisplayName("Phone")]
        public string Phone { get; set; }

        [DisplayName("Email")]
        public string Email { get; set; }   

        [DisplayName("Address")]
        public string Address { get; set; }

        [DisplayName("City")]
        public string City { get; set; }

        [DisplayName("Country")]
        public string Country { get; set; }


       
    }
}
