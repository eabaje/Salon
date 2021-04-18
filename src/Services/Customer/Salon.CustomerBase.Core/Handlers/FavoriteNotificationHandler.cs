using Salon.CustomerBase.Core.Events;
using Salon.CustomerBase.Core.Interfaces;
using Salon.CustomerBase.Core.Specifications;
using System.Linq;

namespace Salon.CustomerBase.Core.Handlers
{
    public class FavoriteNotificationHandler : IHandle<FavoriteAddedEvent>
    {
        private IRepository _repository;
        private IMessageSender _messageSender;

        public FavoriteNotificationHandler(IRepository repository, IMessageSender messageSender)
        {
            _repository = repository;
            _messageSender = messageSender;
        }

        public void Handle(FavoriteAddedEvent entryAddedEvent)
        {
            var notificationPolicy = new FavoriteNotificationPolicy(entryAddedEvent.Entry.CustomerId);

            //Send updates to previous entries made in the last day
            var emailsToNotify = _repository.List(notificationPolicy).Select(e => e.customer.Email).SingleOrDefault();

            string messageBody = "Message";
            _messageSender.SendNotificationEmail(emailsToNotify, "Added favorite", messageBody);

            //foreach (var emailAddress in emailsToNotify)
            //{
            //    string messageBody = $"{entryAddedEvent.Entry.EmailAddress} left a message {entryAddedEvent.Entry.Message}";
            //    _messageSender.SendNotificationEmail(emailAddress, "Added favorite", messageBody) ;
            //}
        }
    }
}
