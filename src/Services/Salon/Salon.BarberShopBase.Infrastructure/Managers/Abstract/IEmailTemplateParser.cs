
using Salon.BarberShopBase.Core.Entities;
using Salon.BarberShopBase.Infrastructure.DTO;

namespace Salon.BarberShopBase.Infrastructure.Managers.Abstract
{
    public interface IEmailTemplateParser 
    {
        string PrepareAppointmentOkEmailAsync(Appointment entity , string stringTemplate);

        string PrepareActivateNewUserEmail(Customer user, string stringTemplate);

      //  string PrepareResetPasswordEmail(LoginViewModel user, string stringTemplate);

       
    }
}