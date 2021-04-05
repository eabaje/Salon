using Salon.CustomerBase.Core.SharedKernel;
using Salon.CustomerBase.Core.Entities;

namespace Salon.CustomerBase.Core.Events
{
    public class BookingAddedEvent : BaseDomainEvent
    {
        public string CustomerId { get; }
        public Booking Entry { get; }

        public BookingAddedEvent(string customerId, Booking entry)
        {
            CustomerId = customerId;
            Entry = entry;
        }
    }
}
