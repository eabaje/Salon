﻿using Salon.Domain.Enumerations;
using System;
using System.Collections.Generic;
using System.Text;

namespace Salon.Domain.Entities
{
   public  class Company:BaseInfo
    {
        public int CompanyId { get; set; }
        public override int EntityId => CompanyId;
        public CompanyType Category { get; set; }
        public string CompanyName { get; set; }
        public string ContactTitle { get; set; }
        public string WebSite { get; set; }
        public bool AllowSearch { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string ContactName
        {
            get
            {
                return LastName + ", " + FirstName;
            }
        }
    }
}
