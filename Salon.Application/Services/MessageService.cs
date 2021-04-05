using Salon.Application.DTO;
using Salon.Application.Interfaces;
using Salon.Common;
using Salon.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Salon.Application.Services
{
    public class MessageService : IMessageService
    {
        private const string EmailFromAddress = "email.from.address";
        private const string EmailToAddresses = "email.to.addresses";
        private const string EmailSmtpHost = "email.smtp.host";
        private const string WebsiteUrl = "website.url";

        private readonly IEmailTemplateService _emailTemplateService;
        private readonly ISettingService _settingService;
        private readonly IEmailSender _emailSender;

        public MessageService(
            IEmailTemplateService emailTemplateService,
            ISettingService settingService,
            IEmailSender emailSender)
        {
            _emailTemplateService = emailTemplateService;
            _settingService = settingService;
            _emailSender = emailSender;
        }

        private string ReplaceMessageTemplateTokens(AppUser user, string websiteUrl, string template)
        {
            var tokens = new NameValueCollection
            {
                {"[[[User_FirstName]]]", HttpUtility.HtmlEncode(user.Othernames)},
                {"[[[User_LastName]]]", HttpUtility.HtmlEncode(user.LastName)},
                {"[[[User_FullName]]]", HttpUtility.HtmlEncode(user.FullName)},
                {"[[[User_EditLink]]]", $"<a href=\"{websiteUrl}/users/edit/{user.Id}\">here</a>"},
                {"[[[User_EditUrl]]]", $"{websiteUrl}/users/edit/{user.Id}"},
                {"[[[Website_Link]]]", $"<a href=\"{websiteUrl}\">Sample Application</a>"},
            };

            // Replaces tokens in the template with the values.
            foreach (string token in tokens.Keys)
                template = template.Replace(token, tokens[token]);

            return template;
        }

        public async Task SendAddNewUserNotification(AppUser user)
        {
            string fromAddress = _settingService.GetSettingByKey<string>(EmailFromAddress, ""),
                toAddresses = _settingService.GetSettingByKey<string>(EmailToAddresses, ""),
                smtpHost = _settingService.GetSettingByKey<string>(EmailSmtpHost, ""),
                websiteUrl = _settingService.GetSettingByKey<string>(WebsiteUrl, "");

            if (string.IsNullOrWhiteSpace(fromAddress) || string.IsNullOrWhiteSpace(toAddresses) ||
                string.IsNullOrWhiteSpace(smtpHost) || string.IsNullOrWhiteSpace(websiteUrl))
                throw new Exception("Email configuration hasn't been set up yet.");

            var toAddressCollection = toAddresses.Split(new[] { ",", ";" }, StringSplitOptions.RemoveEmptyEntries).ToList();
            var emailAccount = new EmailAccount { Host = smtpHost };

            var template = await _emailTemplateService.GetEmailTemplateByName(Constants.EmailTemplates.AddNewUserNotification);
            string subject = ReplaceMessageTemplateTokens(user, websiteUrl, template.Subject);
            string body = ReplaceMessageTemplateTokens(user, websiteUrl, template.Body);

            _emailSender.SendEmail(emailAccount, subject, body, fromAddress, toAddressCollection);
        }
    }
}
