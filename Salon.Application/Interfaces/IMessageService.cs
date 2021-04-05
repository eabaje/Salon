using Salon.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Salon.Application.Interfaces
{
    public interface IMessageService
    {
        Task SendAddNewUserNotification(AppUser user);
    }
}
