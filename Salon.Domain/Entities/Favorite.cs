using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Salon.Domain.Entities
{
    public class Favorite:BaseEntity
    {
        [Key]
        public Guid FavoriteId { get; set; }
        public string ServiceTypeId { get; set; }
        public string CategoryId { get; set; }

        public string CustomerId { get; set; }

    }
}
