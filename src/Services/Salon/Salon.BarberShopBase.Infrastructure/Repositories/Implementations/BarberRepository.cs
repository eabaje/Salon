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

namespace Salon.BarberShopBase.Infrastructure.Repositories.Implementations
{
    public class BarberRepository : IBarberRepository
    {
        private readonly IBeautySalonContext _context;
        private readonly PostgresDBContext _contextPostgres;
        private readonly IBarberDatabaseSettings _setting;
        public BarberRepository(IBeautySalonContext BarberContext, IBarberDatabaseSettings setting, PostgresDBContext contextPostgres)
        {
            _context = BarberContext ?? throw new ArgumentNullException(nameof(BarberContext));

            _setting = setting ?? throw new ArgumentNullException(nameof(setting));

            _contextPostgres = contextPostgres ?? throw new ArgumentNullException(nameof(contextPostgres));
        }

        public async Task<IEnumerable<Barber>> GetBarber()
        {
            List<Barber> BarberList = new List<Barber>();

            return BarberList = (_setting.IsMongoDb) ? await _context
                            .Barbers
                            .Find(p => true)
                            .ToListAsync()
                            : await _contextPostgres
                            .Barbers
                            .ToListAsync();

           
        }

        public async Task<Barber> GetBarber(string id)
        {
            var barber = new Barber();

            return barber = (_setting.IsMongoDb) ? await _context
                            .Barbers
                            .Find(p => p.BarberId == Guid.Parse(id))
                            .FirstOrDefaultAsync()
                            : await _contextPostgres
                            .Barbers
                            .Where(p => p.BarberId == Guid.Parse(id))
                            .FirstOrDefaultAsync();


         
        }

        public async Task<IEnumerable<Barber>> GetBarberBySalon(string salonId)
        {
            
            List<Barber> BarberList = new List<Barber>();
            if (!_setting.IsMongoDb)
            {



                return await _contextPostgres
                              .Barbers
                              .Where(p => p.SalonId == salonId)
                              .ToListAsync();
            }

            FilterDefinition<Barber> filter = Builders<Barber>.Filter.Eq(p => p.SalonId, salonId);

            return await _context
                          .Barbers
                          .Find(filter)
                          .ToListAsync();
        }

        public async Task<IEnumerable<Barber>> GetBarberByName(string barberName)
        {

            List<Barber> BarberList = new List<Barber>();
            if (!_setting.IsMongoDb)
            {



                return await _contextPostgres
                              .Barbers
                              .Where(p => p.BarberName == barberName)
                              .ToListAsync();
            }



            FilterDefinition<Barber> filter = Builders<Barber>.Filter.ElemMatch(p => p.BarberName, barberName);

            return await _context
                          .Barbers
                          .Find(filter)
                          .ToListAsync();
        }

       

        public async Task<IEnumerable<Barber>> GetBarberByDate(DateTime fromDate, DateTime ToDate)
        {
            List<Barber> BarberList = new List<Barber>();
            if (!_setting.IsMongoDb)
            {



                return await _contextPostgres
                              .Barbers
                              .Where(p => p.CreatedOn >= fromDate && p.CreatedOn <= ToDate)
                              .ToListAsync();
            }

            FilterDefinition<Barber> filter = Builders<Barber>.Filter.Where(p => p.CreatedOn >= fromDate && p.CreatedOn <= ToDate);

            return await _context
                          .Barbers
                          .Find(filter)
                          .ToListAsync();
        }
        public async Task<bool> Create(Barber barber)
        {
            if (!_setting.IsMongoDb)
            {

                _contextPostgres
                            .Barbers
                            .Add(barber);

                /* return*/
                return await _contextPostgres.SaveChangesAsync() > 0;
            }
           
            try
            {
                await _context.Barbers.InsertOneAsync(barber);

                return true;
            }
            catch (Exception exc) { return false; }

        }

        public async Task<bool> Update(Barber barber)
        {
            if (!_setting.IsMongoDb)
            {

                _contextPostgres
                            .Barbers
                            .Update(barber);

                return await _contextPostgres.SaveChangesAsync() > 0;
            }
            var updateResult = await _context
                                        .Barbers
                                        .ReplaceOneAsync(filter: g => g.BarberId == barber.BarberId, replacement: barber);

            return updateResult.IsAcknowledged
                    && updateResult.ModifiedCount > 0;
        }

        public async Task<bool> Delete(string id)
        {
            if (!_setting.IsMongoDb)
            {
                var entity = _contextPostgres
                            .Barbers
                            .FirstOrDefault(t => t.BarberId == Guid.Parse(id));

                _contextPostgres.Barbers.Remove(entity);



                /* return*/
                return await _contextPostgres.SaveChangesAsync() > 0;
            }



            FilterDefinition<Barber> filter = Builders<Barber>.Filter.Eq(m => m.BarberId, Guid.Parse(id));
            DeleteResult deleteResult = await _context
                                                .Barbers
                                                .DeleteOneAsync(filter);

            return deleteResult.IsAcknowledged
                && deleteResult.DeletedCount > 0;
        }


    }
}
