using Salon.Application.Interfaces;
using Salon.Domain.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Salon.Application.Services
{
    public class RoleService : IRoleService
    {
        private readonly IRepository<AppRole> _roleRepository;

        public RoleService(IRepository<AppRole> roleRepository)
        {
            _roleRepository = roleRepository;
        }

        public async Task<IList<AppRole>> GetAllRoles()
        {
            var query = _roleRepository.Entities;

            return await query.ToListAsync();
        }

        public async Task<IList<AppRole>> GetRolesForUser(string userId)
        {
            var query = _roleRepository.Entities
                .Where(r => r.Id == userId)
                .Select(r => r)
                .OrderBy(r => r.Name);

            return await query.ToListAsync();
        }
    }
}
