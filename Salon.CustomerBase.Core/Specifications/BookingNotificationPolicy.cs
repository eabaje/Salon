using Salon.CustomerBase.Core.Interfaces;
using Salon.CustomerBase.Core.Entities;
using System;
using System.Linq.Expressions;
namespace Salon.CustomerBase.Core.Handlers
{
    public class BookingNotificationPolicy : ISpecification<Booking>
    {
        private string customerId;

        public BookingNotificationPolicy(string customerId)
        {
            Criteria = e =>
                   e.CreatedOn == DateTime.UtcNow.Date
                   && e.CustomerId == customerId;
                 
        }


      

        public Expression<Func<Booking, bool>> Criteria { get; }
    }
}