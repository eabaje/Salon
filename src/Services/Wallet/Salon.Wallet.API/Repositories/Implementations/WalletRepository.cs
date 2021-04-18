using Salon.WalletBase.API.Data;
using Salon.WalletBase.API.Entities;
using Salon.WalletBase.API.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MongoDB.Driver;

namespace Salon.WalletBase.API.Repositories.Implementations
{
    public class WalletRepository : IWalletRepository
    {
        private readonly SalonDBContext _context;
        public WalletRepository(SalonDBContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }


        public async Task<IEnumerable<Wallet>> GetWallet()
        {
            return await _context
                            .Wallets
                            .Find(p => true)
                            .ToListAsync();
        }

        public async Task<Wallet> GetWalletById(string id)
        {
            return await _context
                            .Wallets
                            .Find(p => p.Id == Guid.Parse(id))
                            .FirstOrDefaultAsync();
        }

      

        public async Task<IEnumerable<Wallet>> GetWalletByCustomer(string customerId)
        {
            FilterDefinition<Wallet> filter = Builders<Wallet>.Filter.Eq(p => p.CustomerId, customerId);

            return await _context
                          .Wallets
                          .Find(filter)
                          .ToListAsync();
        }

       

        public async Task<IEnumerable<Wallet>> GetWalletByDate(DateTime fromDate, DateTime ToDate, string customerId)
        {
            FilterDefinition<Wallet> filter = string.IsNullOrEmpty(customerId) ? Builders<Wallet>.Filter.Where(p => p.CreatedOn >= fromDate && p.CreatedOn <= ToDate) :
                Builders<Wallet>.Filter.Where(p => p.CreatedOn >= fromDate && p.CreatedOn <= ToDate && p.CustomerId == customerId)
                ;

            return await _context
                          .Wallets
                          .Find(filter)
                          .ToListAsync();
        }
        public async Task AddWallet(Wallet Wallet)
        {
            await _context.Wallets.InsertOneAsync(Wallet);

        }

        public async Task<bool> UpdateWallet(Wallet Wallet)
        {
            var updateResult = await _context
                                        .Wallets
                                        .ReplaceOneAsync(filter: g => g.Id == Wallet.Id, replacement: Wallet);

            return updateResult.IsAcknowledged
                    && updateResult.ModifiedCount > 0;
        }

        public async Task<bool> Delete(string id)
        {
            FilterDefinition<Wallet> filter = Builders<Wallet>.Filter.Eq(m => m.Id, Guid.Parse(id));
            DeleteResult deleteResult = await _context
                                                .Wallets
                                                .DeleteOneAsync(filter);

            return deleteResult.IsAcknowledged
                && deleteResult.DeletedCount > 0;
        }


    }
}
