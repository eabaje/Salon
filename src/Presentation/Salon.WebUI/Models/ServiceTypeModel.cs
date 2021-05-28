using System;

using System.Collections.Generic;
using System.Text;

namespace Salon.WebUI.Models
{
   public class ServiceTypeModel
    {
        // [Key]

        
        public string ServiceTypeId { get; set; }
        public string ServiceTypeName { get; set; }
        public string ServiceTypeDesc { get; set; }
        public string CategoryId { get; set; }
    }
}
