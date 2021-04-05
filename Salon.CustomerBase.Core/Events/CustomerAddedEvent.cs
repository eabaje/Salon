using Salon.CustomerBase.Core.SharedKernel;
using Salon.CustomerBase.Core.Entities;

namespace Salon.CustomerBase.Core.Events
{
    public class CustomerAddedEvent : BaseDomainEvent
    {
        public int CustomerId { get; }
        public Customer Entry { get; }

        public CustomerAddedEvent(int customerId, Customer entry)
        {
            CustomerId = customerId;
            Entry = entry;
        }
    }
}
