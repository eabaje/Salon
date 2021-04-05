using Salon.BarberShopBase.Core.Events;
using Salon.BarberShopBase.Core.Interfaces;
using Salon.BarberShopBase.Core.Specifications;
using System.Linq;

namespace Salon.BarberShopBase.Core.Handlers
{
    public class AppointmentNotificationHandler : IHandle<AppointmentAddedEvent>
    {
        private IRepository _repository;
        private IMessageSender _messageSender;

        public AppointmentNotificationHandler(IRepository repository, IMessageSender messageSender)
        {
            _repository = repository;
            _messageSender = messageSender;
        }

        public void Handle(AppointmentAddedEvent entryAddedEvent)
        {
            var notificationPolicy = new AppointmentNotificationPolicy(entryAddedEvent.Entry.CustomerId);

            //Send updates to previous entries made in the last day
            var emailsToNotify = _repository.List(notificationPolicy).Select(e => e.customer.Email).SingleOrDefault();

            string messageBody = "Message";
            _messageSender.SendNotificationEmail(emailsToNotify, "Welcome to our platform", messageBody);

            //foreach (var emailAddress in emailsToNotify)
            //{
            //    string messageBody = $"{entryAddedEvent.Entry.EmailAddress} left a message {entryAddedEvent.Entry.Message}";
            //    _messageSender.SendNotificationEmail(emailAddress,"Welcome to our platform", messageBody);
            //}
        }
    }

}
