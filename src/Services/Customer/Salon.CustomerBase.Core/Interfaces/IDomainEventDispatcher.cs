
using Salon.CustomerBase.Core.SharedKernel;

namespace Salon.CustomerBase.Core.Interfaces
{
    public interface IDomainEventDispatcher
    {
        void Dispatch(BaseDomainEvent domainEvent);
    }
}