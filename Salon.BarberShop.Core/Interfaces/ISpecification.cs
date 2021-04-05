using System;
using System.Linq.Expressions;

namespace Salon.BarberShopBase.Core.Interfaces
{
    public interface ISpecification<T>
    {
        Expression<Func<T, bool>> Criteria { get; }
    }
}
