using Salon.BarberShopBase.Core.Entities;
using Salon.BarberShopBase.Infrastructure.DTO;
using System.Threading.Tasks;


namespace Salon.BarberShopBase.Infrastructure.Services.Abstract
{
    public interface IEmailService
    {
        Task SendAppointmentOkEmailAsync(Appointment entity);

        Task SendAppointmentcancelEmailAsync(Appointment entity);

        //   Task SendNewUserEmailAsync(Customer user);

        Task SendNewSalonBarberEmailAsync(BeautySalon salon,Barber barber);
        
        Task SendNewSalonEmailAsync(BeautySalon salon);

        Task SendResetPasswordEmailAsync(LoginViewModel user);

     
    }
}
