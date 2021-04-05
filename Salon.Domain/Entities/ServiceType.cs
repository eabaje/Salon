using System;
using System.Collections.Generic;
using System.Text;

namespace Salon.Domain.Entities
{
   public class ServiceType : BaseEntity
    {

        public Guid ServiceTypeId { get; set; }
        public string ServiceTypeName { get; set; }
        public string ServiceTypeDesc { get; set; }
    }
}
