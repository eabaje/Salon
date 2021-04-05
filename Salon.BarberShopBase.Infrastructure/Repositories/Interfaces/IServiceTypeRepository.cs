using Salon.BarberShopBase.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Salon.BarberShopBase.Infrastructure.Repositories.Interfaces
{
    public interface IServiceTypeRepository
    {
        Task<IEnumerable<ServiceType>> GetServiceType();
        Task<ServiceType> GetServiceType(string id);
        Task<IEnumerable<ServiceType>> GetServiceTypeByName(string name);
        Task<IEnumerable<ServiceType>> GetServiceTypeByCategory(string categoryName);

      

        Task<bool> Create(ServiceType servicetype);
        Task<bool> Update(ServiceType servicetype);
        Task<bool> Delete(string id);
    }
}
