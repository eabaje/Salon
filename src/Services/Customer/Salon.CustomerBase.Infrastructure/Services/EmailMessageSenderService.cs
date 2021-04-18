using Salon.CustomerBase.Core.Interfaces;
using System.Net.Mail;

namespace Salon.CustomerBase.Infrastructure.Services
{
    public class EmailMessageSenderService : IMessageSender
    {
        public string GetMessageTypeTemplate(string messageType)
        {
            throw new System.NotImplementedException();
        }

        public void SendNotificationEmail(string toAddress,string subject, string messageBody)
        {
            var message = new MailMessage();
            message.To.Add(new MailAddress(toAddress));
            message.From = new MailAddress("donotreply@SalonBase.com");
            message.Subject = string.IsNullOrEmpty(subject) ? " New Message " : subject ;
            message.Body = messageBody;
            using (var client = new SmtpClient("localhost", 25))
            {
                client.Send(message);
            }
        }
    }
}
