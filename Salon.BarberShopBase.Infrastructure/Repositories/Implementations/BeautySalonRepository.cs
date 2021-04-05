using MongoDB.Driver;
using Salon.BarberShopBase.Infrastructure.Data.Interfaces;
using Salon.BarberShopBase.Core.Entities;
using Salon.BarberShopBase.Infrastructure.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Salon.BarberShopBase.Infrastructure.Data;
using Salon.BarberShopBase.Infrastructure.Settings;
using Microsoft.EntityFrameworkCore;


namespace Salon.BeautySalonShopBase.Infrastructure.Repositories.Implementations
{
  
    public class BeautySalonRepository : IBeautySalonRepository
    {
        private readonly IBeautySalonContext _context;
        private readonly PostgresDBContext _contextPostgres;
        private readonly IBarberDatabaseSettings _setting;

        public BeautySalonRepository(IBeautySalonContext BeautySalonContext, IBarberDatabaseSettings setting, PostgresDBContext contextPostgres)
        {
            _context = BeautySalonContext ?? throw new ArgumentNullException(nameof(BeautySalonContext));

            _setting = setting ?? throw new ArgumentNullException(nameof(setting));

            _contextPostgres = contextPostgres ?? throw new ArgumentNullException(nameof(contextPostgres));
        }

        public async Task<IEnumerable<BeautySalon>> GetBeautySalon()
        {
            List<BeautySalon> BeautySalonList = new List<BeautySalon>();

            return BeautySalonList = (_setting.IsMongoDb) ? await _context
                            .BeautySalons
                            .Find(p => true)
                            .ToListAsync()
                            : await _contextPostgres
                            .BeautySalons
                            .ToListAsync();

          
        }

        public async Task<BeautySalon> GetBeautySalon(string id)
        {
            var beautySalon = new BeautySalon();

            return beautySalon = (_setting.IsMongoDb) ? await _context
                            .BeautySalons
                            .Find(p => p.BeautySalonId == id)
                            .FirstOrDefaultAsync()
                            : await _contextPostgres
                            .BeautySalons
                            .Where(p => p.BeautySalonId == id)
                            .FirstOrDefaultAsync();
            
        }

        public async Task<IEnumerable<BeautySalon>> GetBeautySalonByName(string name)
        {

            List<BeautySalon> BeautySalonList = new List<BeautySalon>();
            if (!_setting.IsMongoDb)
            {



                return await _contextPostgres
                              .BeautySalons
                              .Where(p => p.SalonName.StartsWith(name))
                              .ToListAsync();
            }




            FilterDefinition<BeautySalon> filter = Builders<BeautySalon>.Filter.Where(p => p.SalonName.StartsWith(name));

            return await _context
                          .BeautySalons
                          .Find(filter)
                          .ToListAsync();
        }

        public async Task<IEnumerable<BeautySalon>> GetBeautySalonByCategory(string CategoryId)
        {

            List<BeautySalon> BeautySalonList = new List<BeautySalon>();
            if (!_setting.IsMongoDb)
            {



                return await _contextPostgres
                              .BeautySalons
                              .Where(p => p.CategoryId == CategoryId)
                              .ToListAsync();
            }


            FilterDefinition<BeautySalon> filter = Builders<BeautySalon>.Filter.Eq(p => p.CategoryId, CategoryId);

            return await _context
                          .BeautySalons
                          .Find(filter)
                          .ToListAsync();
        }

        public async Task<IEnumerable<BeautySalon>> GetBeautySalonByDate(DateTime fromDate, DateTime ToDate)
        {

            List<BeautySalon> ServiceTypeList = new List<BeautySalon>();
            if (!_setting.IsMongoDb)
            {



                return await _contextPostgres
                              .BeautySalons
                              .Where(p => p.CreatedOn >= fromDate && p.CreatedOn <= ToDate)
                              .ToListAsync();
            }


            FilterDefinition<BeautySalon> filter = Builders<BeautySalon>.Filter.Where(p => p.CreatedOn >= fromDate && p.CreatedOn <= ToDate);

            return await _context
                          .BeautySalons
                          .Find(filter)
                          .ToListAsync();
        }


        public async Task<IEnumerable<BeautySalon>> GetBeautySalonByNearestLocation(double Latitude,double Longitude,double radius)
        {
            List<BeautySalon> BeautySalonList = new List<BeautySalon>();
            if (!_setting.IsMongoDb)
            {



                return await _contextPostgres
                              .BeautySalons
                              .Where(p => p.Latitude == Latitude && p.Longitude== Longitude)
                              .ToListAsync();
            }


            FilterDefinition<BeautySalon> filter = Builders<BeautySalon>.Filter.Where(p => p.Latitude == Latitude && p.Longitude == Longitude);

            return await _context
                          .BeautySalons
                          .Find(filter)
                          .ToListAsync();
        }
        public async Task<bool> Create(BeautySalon beautysalon)
        {
            if (!_setting.IsMongoDb)
            {

                _contextPostgres
                            .BeautySalons
                            .Add(beautysalon);

                /* return*/
                return await _contextPostgres.SaveChangesAsync() > 0;
            }

            try
            {
                await _context.BeautySalons.InsertOneAsync(beautysalon);

                return true;
            }
            catch (Exception exc) { return false; }

           

        }

        public async Task<bool> Update(BeautySalon beautysalon)
        {
            if (!_setting.IsMongoDb)
            {

                _contextPostgres
                            .BeautySalons
                            .Update(beautysalon);

                return await _contextPostgres.SaveChangesAsync() > 0;
            }
            var updateResult = await _context
                                        .BeautySalons
                                        .ReplaceOneAsync(filter: g => g.BeautySalonId == beautysalon.BeautySalonId, replacement: beautysalon);

            return updateResult.IsAcknowledged
                    && updateResult.ModifiedCount > 0;
        }

        public async Task<bool> Delete(string id)
        {
            if (!_setting.IsMongoDb)
            {
                var entity = _contextPostgres
                            .BeautySalons
                            .FirstOrDefault(t => t.BeautySalonId == id);

                _contextPostgres.BeautySalons.Remove(entity);



                /* return*/
                return await _contextPostgres.SaveChangesAsync() > 0;
            }

            FilterDefinition<BeautySalon> filter = Builders<BeautySalon>.Filter.Eq(m => m.BeautySalonId, id);
            DeleteResult deleteResult = await _context
                                                .BeautySalons
                                                .DeleteOneAsync(filter);

            return deleteResult.IsAcknowledged
                && deleteResult.DeletedCount > 0;
        }

     
    }
}
