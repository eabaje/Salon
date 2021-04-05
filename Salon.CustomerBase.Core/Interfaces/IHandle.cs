
using Salon.CustomerBase.Core.SharedKernel;

namespace Salon.CustomerBase.Core.Interfaces
{
    public interface IHandle<T> where T : BaseDomainEvent
    {
        void Handle(T domainEvent);
    }
}