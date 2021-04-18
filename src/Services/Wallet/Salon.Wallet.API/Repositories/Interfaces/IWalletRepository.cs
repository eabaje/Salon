using Salon.WalletBase.API.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Salon.WalletBase.API.Repositories.Interfaces
{
    public interface IWalletRepository
    {
      
        Task<Wallet> GetWalletById(string id);
        Task<IEnumerable<Wallet>> GetWallet();
       
        Task<IEnumerable<Wallet>> GetWalletByCustomer(string customerId);
        Task<IEnumerable<Wallet>> GetWalletByDate(DateTime fromDate, DateTime toDate,string customerId);
        Task AddWallet(Wallet wallet);
        Task<bool> UpdateWallet(Wallet wallet);
        Task<bool> Delete(string id);
    }
}
