using System;
using System.Globalization;
using System.Linq;
using System.Text;
using Microsoft.Extensions.Options;
using Salon.Common.Settings;

using Salon.BarberShopBase.Core.Entities;
using Salon.BarberShopBase.Infrastructure.DTO;
using Salon.BarberShopBase.Infrastructure.Managers.Abstract;

namespace Salon.BarberShopBase.Infrastructure.Managers.Implementations
{ 
    public class EmailTemplatesParser : IEmailTemplateParser
    {
        private readonly ClientSettings clientSettings;

        public EmailTemplatesParser(IOptions<ClientSettings> clientOptions)
        {
            this.clientSettings = clientOptions.Value;
        }

        public string PrepareAppointmentOkEmailAsync(Appointment appointment, string stringTemplate)
        {
            var today = DateTime.Today.ToString("d", CultureInfo.InvariantCulture);
            stringTemplate = stringTemplate.Replace("{{{today}}}", today);

            var startIndex = stringTemplate.IndexOf("<!--starter-->", StringComparison.Ordinal) + 14;
            var endIndex = stringTemplate.IndexOf("<!--ender-->", startIndex, StringComparison.Ordinal);
            var template = stringTemplate.Substring(startIndex, endIndex - startIndex);
            var productsTemplate = new StringBuilder();

            //foreach (var appointment in order.appointments)
            //{
            //    var tempTemplate = template.Replace("{{{ProductName}}}", appointment.Product.Name);
            //    tempTemplate = tempTemplate.Replace("{{{ProductAmount}}}", appointment.Amount.ToString(CultureInfo.InvariantCulture));
            //    var charms = string.Empty;
            //    if (appointment.appointmentCharms.Any())
            //    {
            //        var charmsNames = appointment.appointmentCharms.Select(s => s.Charm.Name);
            //        charms = $"({string.Join(" | ", charmsNames)})";
            //    }

            //    tempTemplate = tempTemplate.Replace("{{{Charms}}}", charms);
            //    tempTemplate = tempTemplate.Replace("{{{Price}}}",
            //        (appointment.FinalPrice * appointment.Amount).ToString(CultureInfo.InvariantCulture));
            //    productsTemplate.Append(tempTemplate);
            //}

            stringTemplate = stringTemplate.Remove(startIndex, endIndex - startIndex);
            stringTemplate = stringTemplate.Insert(startIndex, productsTemplate.ToString());
        //    stringTemplate = stringTemplate.Replace("{{{TotalPrice}}}", order.FinalPrice.ToString(CultureInfo.InvariantCulture));
            stringTemplate = stringTemplate.Replace("{{{FullName}}}", appointment.customer.FullName);
            stringTemplate = stringTemplate.Replace("{{{Email}}}", appointment.customer.Email);
            stringTemplate = stringTemplate.Replace("{{{Salon}}}", appointment.salon.SalonName.ToString(CultureInfo.InvariantCulture));
            stringTemplate = stringTemplate.Replace("{{{Barber}}}", appointment.barber.BarberName);
           
          //  stringTemplate = stringTemplate.Replace("{{{OrderPrice}}}", (order.FinalPrice + order.OrderShipment.Price).ToString("F", CultureInfo.InvariantCulture));

            return stringTemplate;
        }

        public string PrepareActivateNewSalonEmail(BeautySalon salon, string stringTemplate)
        {
            var url = $"{clientSettings.Url}activate";
            var today = DateTime.Today.ToString("d", CultureInfo.InvariantCulture);
            stringTemplate = stringTemplate.Replace("{{{url}}}", url);
            stringTemplate = stringTemplate.Replace("{{{name}}}", salon.SalonName);
            stringTemplate = stringTemplate.Replace("{{{today}}}", today);
            return stringTemplate;
        }

        public string PrepareNewSalonBarberEmail(BeautySalon salon,Barber barber, string stringTemplate)
        {
            var url = $"{clientSettings.Url}activate";
            var today = DateTime.Today.ToString("d", CultureInfo.InvariantCulture);
            stringTemplate = stringTemplate.Replace("{{{url}}}", url);
            stringTemplate = stringTemplate.Replace("{{{salon}}}", salon.SalonName);
            stringTemplate = stringTemplate.Replace("{{{barber}}}", barber.BarberName);
            stringTemplate = stringTemplate.Replace("{{{today}}}", today);
            return stringTemplate;
        }

        public string PrepareAppointmentCancelEmail(Appointment appointment,string stringTemplate)
        {
            var url = $"{clientSettings.Url}activate";
            var today = DateTime.Today.ToString("d", CultureInfo.InvariantCulture);
            stringTemplate = stringTemplate.Replace("{{{url}}}", url);
            stringTemplate = stringTemplate.Replace("{{{salon}}}", appointment.salon.SalonName);
            stringTemplate = stringTemplate.Replace("{{{customer}}}", appointment.customer.FullName);
            stringTemplate = stringTemplate.Replace("{{{today}}}", today);
            return stringTemplate;
        }


       

        //public string PrepareResetPasswordEmail(LoginViewDTO user, string stringTemplate)
        //{
        //    var url = $"{clientSettings.Url}password/recovery?token={user.ChangePasswordToken}";
        //    var today = DateTime.Today.ToString("d", CultureInfo.InvariantCulture);
        //    stringTemplate = stringTemplate.Replace("{{{url}}}", url);
        //    stringTemplate = stringTemplate.Replace("{{{today}}}", today);
        //    return stringTemplate;
        //}

        //public string PrepareOrderWasShippedEmail(Order order, string stringTemplate)
        //{
        //    var url = $"{clientSettings.Url}profile/my-orders/{order.Id}";
        //    var today = DateTime.Today.ToString("d", CultureInfo.InvariantCulture);
        //    stringTemplate = stringTemplate.Replace("{{{today}}}", today);
        //    stringTemplate = stringTemplate.Replace("{{{name}}}", order.User.FirstName);
        //    stringTemplate = stringTemplate.Replace("{{{orderId}}}", order.Id.ToString(CultureInfo.InvariantCulture));
        //    stringTemplate = stringTemplate.Replace("{{{url}}}", url);
        //    return stringTemplate;
        //}
    }
}