using System.Globalization;
using System.Threading.Tasks;
using Microsoft.Extensions.Options;
using Salon.Common.Managers.Abstract;

using Salon.BarberShopBase.Services.Abstract;
using Salon.Common.Settings;
using Salon.BarberShopBase.Core.Entities;
using System;
using Salon.BarberShopBase.Infrastructure.DTO;
using Salon.BarberShopBase.Infrastructure.Managers.Implementations;
using Salon.BarberShopBase.Infrastructure.Managers.Abstract;

namespace Salon.BarberShopBase.Infrastructure.Services.Implementations
{
   public class EmailService : IEmailService
    {
        private readonly EmailTemplatesParser emailTemplateParser;
        private readonly IEmailTemplatesManager emailTemplatesManager;
        private readonly IEmailManager emailManager;
        private readonly EmailTemplateSettings emailTemplateSettings;

        public EmailService(
            IEmailTemplatesManager emailTemplatesManager,
            IEmailManager emailManager, IEmailTemplateParser emailTemplateParser,
            IOptions<EmailTemplateSettings> emailTemplatesOptions)
        {
            this.emailTemplatesManager = emailTemplatesManager;
            this.emailManager = emailManager;
            this.emailTemplateParser = emailTemplateParser;
            this.emailTemplateSettings = emailTemplatesOptions.Value;
        }

        public async Task SendNewSalonEmailAsync(BeautySalon beautySalon)
        {
            var template = await emailTemplatesManager.ReadTemplateAsync(emailTemplateSettings.NewOrder.TemplateName);
            template = emailTemplateParser.PrepareNewOrderEmailAsync(beautySalon, template);
            var subject = ParseSubjectId(emailTemplateSettings.NewOrder.Subject, beautySalon.BeautySalonId.ToString());
            await emailManager.SendAsync(beautySalon.Email, beautySalon.ContactName, subject, template);
        }


        public async Task SendNewSalonBarberEmailAsync(Barber barber)
        {
            var template = await emailTemplatesManager.ReadTemplateAsync(emailTemplateSettings.NewEntity.TemplateName);
            template = emailTemplateParser.PrepareNewOrderEmailAsync(barber, template);
            var subject = ParseSubjectId(emailTemplateSettings.NewEntity.Subject, barber.BarberId.ToString());
            await emailManager.SendAsync(barber.Email, barber.BarberName, subject, template);
        }
       

        //public async Task SendOrderWasShippedEmailAsync(Order order)
        //{
        //    var template = await emailTemplatesManager.ReadTemplateAsync(emailTemplateSettings.OrderWasShipped.TemplateName);
        //    template = emailTemplateParser.PrepareOrderWasShippedEmail(order, template);
        //    var subject = ParseSubjectOrderId(emailTemplateSettings.OrderWasShipped.Subject, order.Id);
        //    await emailManager.SendAsync(order.User.Email, order.User.FullName, subject, template);
        //}

        private static string ParseSubjectId(string subject, string IdentifiableId)
        {
            return subject.Replace("{{{OrderId}}}", IdentifiableId.ToString(CultureInfo.InvariantCulture));
        }

        Task IEmailService.SendAppointmentOkEmailAsync(Appointment entity)
        {
            throw new NotImplementedException();
        }

        Task IEmailService.SendNewUserEmailAsync(Customer user)
        {
            throw new NotImplementedException();
        }

        Task IEmailService.SendResetPasswordEmailAsync(LoginViewModel user)
        {
            throw new NotImplementedException();
        }
    }
}