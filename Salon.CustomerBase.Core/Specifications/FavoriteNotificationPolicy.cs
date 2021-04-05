using Salon.CustomerBase.Core.Interfaces;
using Salon.CustomerBase.Core.Entities;
using System;
using System.Linq.Expressions;

namespace Salon.CustomerBase.Core.Specifications
{
    public class FavoriteNotificationPolicy : ISpecification<Favorite>
    {
        public FavoriteNotificationPolicy(string CustomerId)
        {
            Criteria = e =>
                    e.CreatedOn == DateTime.UtcNow.Date
                    && e.CustomerId== CustomerId    // created after 1 day ago
                    && e.IsActive ==true; // don't notify the added entry
        }

        public Expression<Func<Favorite, bool>> Criteria { get; }
    }
}
