using Salon.WalletBase.API.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Salon.WalletBase.API.Repositories.Interfaces
{
   public interface ITransactionRepository
    {
        Task<bool> AddTransaction(Transaction transaction);
        Task<bool> UpdateTransaction(Transaction transaction);
        Task<bool> Delete(string id);
        Task<Transaction> GetTransactionById(string id);
        Task<List<Transaction>> GetTransaction();
        Task<List<Transaction>> GetTransactionByDate(DateTime fromDate, DateTime toDate);
        Task<List<Transaction>> GetTransactionByCustomer(string customerId);
    }
}
