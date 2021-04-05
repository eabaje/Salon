
using Salon.BarberShopBase.Core.Entities;
using Salon.BarberShopBase.Core.SharedKernel;

namespace Salon.BarberShopBase.Core.Events
{
    public class AppointmentAddedEvent : BaseDomainEvent
    {
        public string AppointmentId { get; }
        public Appointment Entry { get; }

        public AppointmentAddedEvent(string appointmentId, Appointment entry)
        {
            AppointmentId = appointmentId;
            Entry = entry;
        }
    }
}
