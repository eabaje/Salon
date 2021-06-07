using MongoDB.Driver;

using Salon.BarberShopBase.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Salon.BarberShopBase.Infrastructure.Repositories.Interfaces;
using Salon.BarberShopBase.Infrastructure.Data.Interfaces;
using Salon.BarberShopBase.Infrastructure.Data;
using Salon.BarberShopBase.Infrastructure.Settings;
using Microsoft.EntityFrameworkCore;

namespace Salon.BarberShopBase.Infrastructure.Repositories.Implementations
{
    public class PriceListRepository:IPriceListRepository
    {
        private readonly IBeautySalonContext _context;
        private readonly PostgresDBContext _contextPostgres;
        private readonly IBarberDatabaseSettings _setting;

        public PriceListRepository(IBeautySalonContext databaseContext, IBarberDatabaseSettings setting, PostgresDBContext contextPostgres)
        {
            _context = databaseContext ?? throw new ArgumentNullException(nameof(databaseContext));

            _setting = setting ?? throw new ArgumentNullException(nameof(setting));

            _contextPostgres = contextPostgres ?? throw new ArgumentNullException(nameof(contextPostgres));
        }
       
        public async Task<IEnumerable<PriceList>> GetPriceList()
        {
            List<PriceList> PriceListList = new List<PriceList>();

            return PriceListList = (_setting.IsMongoDb) ? await _context
                            .PriceLists
                            .Find(p => true)
                            .ToListAsync()
                            : await _contextPostgres
                            .PriceLists
                            .ToListAsync();


          
        }
        public async Task<IEnumerable<PriceList>> GetPriceListBySalon(string salonId)
        {
            List<PriceList> PriceListList = new List<PriceList>();

            return PriceListList = (_setting.IsMongoDb) ? await _context
                            .PriceLists
                            .Find(p => p.SalonId == salonId)
                             .ToListAsync()
                            : await _contextPostgres
                            .PriceLists
                            .Where(p => p.SalonId == salonId)
                             .ToListAsync();


        }


        public async Task<PriceList> GetPriceList(string id)
        {
            var PriceList = new PriceList();

            return PriceList = (_setting.IsMongoDb) ? await _context
                            .PriceLists
                            .Find(p => p.PriceListId == id)
                            .FirstOrDefaultAsync()
                            : await _contextPostgres
                            .PriceLists
                            .Where(p => p.PriceListId == id)
                            .FirstOrDefaultAsync();

            
        }



        public async Task<bool> Create(PriceList price)
        {
            if (!_setting.IsMongoDb)
            {

                _contextPostgres
                            .PriceLists
                            .Add(price);

                /* return*/
                return await _contextPostgres.SaveChangesAsync() > 0;
            }

            try
            {
                await _context.PriceLists.InsertOneAsync(price);

                return true;
            }
            catch (Exception exc) { return false; }


          

        }

        public async Task<bool> Update(PriceList price)
        {
            if (!_setting.IsMongoDb)
            {

                _contextPostgres
                            .PriceLists
                            .Update(price);

                return await _contextPostgres.SaveChangesAsync() > 0;
            }

            var updateResult = await _context
                                        .PriceLists
                                        .ReplaceOneAsync(filter: g => g.PriceListId == price.PriceListId, replacement: price);

            return updateResult.IsAcknowledged
                    && updateResult.ModifiedCount > 0;
        }

        public async Task<bool> Delete(string id)
        {
            if (!_setting.IsMongoDb)
            {
                var entity = _contextPostgres
                            .PriceLists
                            .FirstOrDefault(t => t.PriceListId == id);

                _contextPostgres.PriceLists.Remove(entity);



                /* return*/
                return await _contextPostgres.SaveChangesAsync() > 0;
            }


            FilterDefinition<PriceList> filter = Builders<PriceList>.Filter.Eq(m => m.PriceListId, id);
            DeleteResult deleteResult = await _context
                                                .PriceLists
                                                .DeleteOneAsync(filter);

            return deleteResult.IsAcknowledged
                && deleteResult.DeletedCount > 0;
        }


    }
}