using System;
using System.Collections.Generic;
using System.Text;

namespace Salon.Domain.Entities
{
   public class Broker: BaseCompany
    {
        public Guid BrokerId { get; set; }
        public override Guid EntityId => BrokerId;
        public string CompanyId { get; set; }
        public bool? Certified { get; set; }
        public String Experience { get; set; }
        public String JobScope { get; set; }
        public string SecondaryEmail { get; set; }
        public Company Company { get; set; }

    }
}
