using Salon.BarberShopBase.Core.Entities;
using Salon.BarberShopBase.Infrastructure.DTO;
using System.Threading.Tasks;


namespace Salon.BarberShopBase.Services.Abstract
{
    public interface IEmailService
    {
        Task SendAppointmentOkEmailAsync(Appointment entity);

        Task SendNewUserEmailAsync(Customer user);

        Task SendResetPasswordEmailAsync(LoginViewModel user);

     
    }
}
