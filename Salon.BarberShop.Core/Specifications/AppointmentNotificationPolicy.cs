using Salon.BarberShopBase.Core.Interfaces;
using Salon.BarberShopBase.Core.Entities;
using System;
using System.Linq.Expressions;

namespace Salon.BarberShopBase.Core.Specifications
{
    public class AppointmentNotificationPolicy : ISpecification<Appointment>
    {
        public AppointmentNotificationPolicy(string CustomerId)
        {
            Criteria = e =>
                    e.CreatedOn == DateTime.UtcNow.Date
                    && e.CustomerId== CustomerId ;   // created after 1 day ago
                  // don't notify the added entry
        }

        public Expression<Func<Appointment, bool>> Criteria { get; }
    }
}
