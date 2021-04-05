using Salon.BarberShopBase.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Salon.BarberShopBase.Infrastructure.Repositories.Interfaces
{
    public interface IPriceListRepository
    {

        Task<IEnumerable<PriceList>> GetPriceList();
        Task<PriceList> GetPriceList(string id);
        Task<bool> Create(PriceList price);
        Task<bool> Update(PriceList price);
        Task<bool> Delete(string id);

    }
}
