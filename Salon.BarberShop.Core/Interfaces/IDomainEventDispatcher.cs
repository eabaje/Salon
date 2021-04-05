
using Salon.BarberShopBase.Core.SharedKernel;

namespace Salon.BarberShopBase.Core.Interfaces
{
    public interface IDomainEventDispatcher
    {
        void Dispatch(BaseDomainEvent domainEvent);
    }
}