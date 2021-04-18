using Salon.BarberShopBase.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Salon.BarberShopBase.Infrastructure.Repositories.Interfaces
{
    public interface IBarberRepository
    {

        Task<IEnumerable<Barber>> GetBarber();
        Task<Barber> GetBarber(string id);
        Task<IEnumerable<Barber>> GetBarberByName(string name);
        Task<IEnumerable<Barber>> GetBarberBySalon(string salonId);

      //  Task<IEnumerable<Barber>> GetBarberByLocation(string LocationName);

        Task<bool> Create(Barber barber);
        Task<bool> Update(Barber barber);
        Task<bool> Delete(string id);
    }
}
