using Salon.CustomerBase.Core.Events;
using Salon.CustomerBase.Core.Interfaces;
using Salon.CustomerBase.Core.Specifications;
using System.Linq;

namespace Salon.CustomerBase.Core.Handlers
{
    public class CustomerNotificationHandler : IHandle<CustomerAddedEvent>
    {
        private IRepository _repository;
        private IMessageSender _messageSender;

        public CustomerNotificationHandler(IRepository repository, IMessageSender messageSender)
        {
            _repository = repository;
            _messageSender = messageSender;
        }

        public void Handle(CustomerAddedEvent entryAddedEvent)
        {
            var notificationPolicy = new CustomerNotificationPolicy(entryAddedEvent.Entry.CustomerId);

            //Send updates to previous entries made in the last day
            var emailsToNotify = _repository.List(notificationPolicy).Select(e => e.Email).SingleOrDefault();

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
