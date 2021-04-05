using Salon.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Salon.Application.Interfaces
{
    public interface IRoleService
    {
        Task<IList<AppRole>> GetAllRoles();

        Task<IList<AppRole>> GetRolesForUser(string userId);
    }
}
