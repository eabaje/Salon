
using MongoDB.Driver;
using Salon.WalletBase.API.Entities;
using Salon.WalletBase.API.Settings;
using Salon.WalletBase.API.Data.Interfaces;
namespace Salon.WalletBase.API.Data
{
    public class SalonDBContext : ISalonDBContext
    {
        public SalonDBContext(IBarberDatabaseSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);

            //Products = database.GetCollection<Product>(settings.CollectionName);
            //CatalogContextSeed.SeedData(Products);
        }

       

        public IMongoCollection<Wallet> Wallets { get; }
        public IMongoCollection<Transaction> Transactions { get; }
      
        
    }
}
