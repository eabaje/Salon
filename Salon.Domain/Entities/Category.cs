using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Salon.Domain.Entities
{
    public class Category : BaseEntity
    {
        public Category()
        {
           // Products = new HashSet<Product>();
        }
        [Key]
        public Guid CategoryId { get; set; }
        public string CategoryName { get; set; }
        public string Description { get; set; }
      

      
    }
}


