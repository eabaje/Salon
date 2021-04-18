using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Salon.CustomerBase.Core.Entities
{
    public class Favorite:BaseEntity
    {
        [Key]
        public Guid FavoriteId { get; set; }
        public string ServiceTypeId { get; set; }

        public string SalonId { get; set; }

        public string CategoryId { get; set; }

        public string CustomerId { get; set; }

        public bool IsActive { get; set; }

        public virtual Customer customer { get; set; }

        

    }
}
