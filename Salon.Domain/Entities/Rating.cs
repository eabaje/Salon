﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Salon.Domain.Entities
{
   public  class Rating
    {
        [Key]
        public Guid RatingId { get; set; }
        public int Score { get; set; }
        public string Recipient { get; set; }
     

    }
}
