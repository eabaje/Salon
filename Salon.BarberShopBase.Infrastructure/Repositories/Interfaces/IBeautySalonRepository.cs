
using Salon.BarberShopBase.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Salon.BarberShopBase.Infrastructure.Repositories.Interfaces
{
   

    public interface IBeautySalonRepository
    {
        Task<IEnumerable<BeautySalon>> GetBeautySalon();
        Task<BeautySalon> GetBeautySalon(string id);
        Task<IEnumerable<BeautySalon>> GetBeautySalonByName(string name);
        Task<IEnumerable<BeautySalon>> GetBeautySalonByCategory(string categoryName);

        Task<IEnumerable<BeautySalon>> GetBeautySalonByNearestLocation(double Latitude, double Longitude, double radius);

        Task<bool> Create(BeautySalon beautysalon);
        Task<bool> Update(BeautySalon beautysalon);
        Task<bool> Delete(string id);
    }
}
