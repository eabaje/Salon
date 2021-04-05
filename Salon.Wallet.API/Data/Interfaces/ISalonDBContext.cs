
using MongoDB.Driver;
using Salon.WalletBase.API.Entities;

namespace Salon.WalletBase.API.Data.Interfaces
{
    public interface ISalonDBContext
    {
        IMongoCollection<Transaction> Transactions { get; }
        IMongoCollection<Wallet> Wallets { get; }
        
        
    }
}
