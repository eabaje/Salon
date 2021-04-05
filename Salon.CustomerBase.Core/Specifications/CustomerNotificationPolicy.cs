using Salon.CustomerBase.Core.Interfaces;
using Salon.CustomerBase.Core.Entities;
using System;
using System.Linq.Expressions;
namespace Salon.CustomerBase.Core.Handlers
{
    public class CustomerNotificationPolicy : ISpecification<Customer>
    {
        private string customerId;

        public CustomerNotificationPolicy(Guid customerId)
        {
            Criteria = e =>
                   e.CreatedOn == DateTime.UtcNow.Date
                   && e.CustomerId == customerId;

        }




        public Expression<Func<Customer, bool>> Criteria { get; }
    }
}