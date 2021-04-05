using Salon.Application.DTO;
using System;
using System.Collections.Generic;
using System.Net.Mail;

namespace Salon.Application.Interfaces
{
    public interface IEmailSender
    {
        void SendEmail(EmailAccount emailAccount, string subject, string body, string fromAddress, IEnumerable<string> toAddresses, IEnumerable<string> replyToAddresses = null, IEnumerable<string> bccAddresses = null, IEnumerable<string> ccAddresses = null, string attachmentFilePath = null, string attachmentFileName = null);

        void SendEmail(EmailAccount emailAccount, string subject, string body, MailAddress fromAddress, IEnumerable<MailAddress> toAddresses, IEnumerable<MailAddress> replyToAddresses, IEnumerable<MailAddress> bccMailAddresses, IEnumerable<MailAddress> ccMailAddresses, string attachmentFilePath = null, string attachmentFileName = null);
    }
}
