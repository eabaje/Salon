
using Salon.BarberShopBase.Core.SharedKernel;

namespace Salon.BarberShopBase.Core.Interfaces
{
    public interface IHandle<T> where T : BaseDomainEvent
    {
        void Handle(T domainEvent);
    }
}