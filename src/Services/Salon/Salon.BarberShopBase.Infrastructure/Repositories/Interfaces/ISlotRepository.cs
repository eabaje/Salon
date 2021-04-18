using Salon.BarberShopBase.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Salon.BarberShopBase.Infrastructure.Repositories.Interfaces
{
    public interface ISlotRepository
    {
        Task<IEnumerable<Slot>> GetSlot();
        Task<Slot> GetSlot(string id);
        Task<IEnumerable<Slot>> GetSlotByName(string name);
        Task<IEnumerable<Slot>> GetSlotByCategory(string categoryName);

        Task<IEnumerable<Slot>> GetSlotByLocation(string LocationName);

        Task Create(Slot slot);
        Task<bool> Update(Slot slot);
        Task<bool> Delete(string id);
    }
}
