using System;
using Microsoft.AspNetCore.Identity;

namespace Salon.Domain.Entities
{
    public class AppRole : IdentityRole
    {
        public string Description { get; set; }
        public DateTime CreatedDated { get; set; }
        public string IPAddress { get; set; }
    }
}
