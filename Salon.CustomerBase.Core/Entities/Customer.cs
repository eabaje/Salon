﻿using System;
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
      

        [DisplayName("Company Name")]
        public string CompanyName { get; set; }

        [DisplayName("Contact Name")]
        public string ContactName { get; set; }

        [DisplayName("Contact Title")]
        public string ContactTitle { get; set; }

        [DisplayName("Fax")]
        public string Fax { get; set; }

        [DisplayName("Phone")]
        public string Phone { get; set; }

        [DisplayName("Email")]
        public string Email { get; set; }


        [DisplayName("WebSite")]
        public string WebSite { get; set; }

        [DisplayName("Address")]
        public string Address { get; set; }

        [DisplayName("City")]
        public string City { get; set; }

        [DisplayName("Country")]
        public string Country { get; set; }


        [DisplayName("Postal Code")]
        public string PostalCode { get; set; }

        [DisplayName("Region")]
        public string Region { get; set; }
    }
}
