using Salon.Application.DTO;
using Salon.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Salon.Application.Interfaces
{
    public interface IUserRepository
    {
        Task<UserResponce> CreateUser(AppUser user, string password);
        Task<AppUser> FindByName(string userName);
        Task<bool> CheckPassword(AppUser user, string password);
        Task<IPagedList<AppUser>> GetUsersAsync(UserPagedDataRequest request);
    }
}
