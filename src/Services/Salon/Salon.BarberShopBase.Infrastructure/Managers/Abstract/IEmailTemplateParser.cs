
using Salon.BarberShopBase.Core.Entities;
using Salon.BarberShopBase.Infrastructure.DTO;

namespace Salon.BarberShopBase.Infrastructure.Managers.Abstract
{
    public interface IEmailTemplateParser 
    {
        string PrepareAppointmentOkEmailAsync(Appointment entity , string stringTemplate);

        string PrepareActivateNewSalonEmail(BeautySalon salon, string stringTemplate);

        string PrepareNewSalonBarberEmail(BeautySalon salon,Barber barber, string stringTemplate);

        string PrepareAppointmentCancelEmail(Appointment entity, string stringTemplate);

        //  string PrepareResetPasswordEmail(LoginViewModel user, string stringTemplate);


    }
}