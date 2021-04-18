using Salon.CustomerBase.Core.Events;
using Salon.CustomerBase.Core.Interfaces;
using System.Linq;

namespace Salon.CustomerBase.Core.Handlers
{
    public class BookingNotificationHandler : IHandle<BookingAddedEvent>
    {
        private IRepository _repository;
        private IMessageSender _messageSender;

        public BookingNotificationHandler(IRepository repository, IMessageSender messageSender)
        {
            _repository = repository;
            _messageSender = messageSender;
        }

        public void Handle(BookingAddedEvent entryAddedEvent)
        {
            var notificationPolicy = new BookingNotificationPolicy(entryAddedEvent.Entry.CustomerId);

            //Send updates to previous entries made in the last day
            var emailsToNotify = _repository.List(notificationPolicy).Select(e => e.customer.Email).SingleOrDefault();

            string messageBody = "Message Sent";
            _messageSender.SendNotificationEmail(emailsToNotify, "You made a booking Prequest", messageBody);
            //foreach (var emailAddress in emailsToNotify)
            //{
            //    string messageBody = $"{entryAddedEvent.Entry.EmailAddress} left a message {entryAddedEvent.Entry.Message}";
            //    _messageSender.SendNotificationEmail(emailAddress, "Added favorite", messageBody);
            //}
        }
    }
}
