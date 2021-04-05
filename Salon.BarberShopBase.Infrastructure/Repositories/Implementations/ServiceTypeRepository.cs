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
    public class ServiceTypeRepository : IServiceTypeRepository
    {
        private readonly IBeautySalonContext _context;
        private readonly PostgresDBContext _contextPostgres;
        private readonly IBarberDatabaseSettings _setting;

        public ServiceTypeRepository(IBeautySalonContext databaseContext, IBarberDatabaseSettings setting, PostgresDBContext contextPostgres)
        {
            _context = databaseContext ?? throw new ArgumentNullException(nameof(databaseContext));

            _setting = setting ?? throw new ArgumentNullException(nameof(setting));

            _contextPostgres = contextPostgres ?? throw new ArgumentNullException(nameof(contextPostgres));
        }

        public async Task<IEnumerable<ServiceType>> GetServiceType()
        {
            List<ServiceType> ServiceTypeList = new List<ServiceType>();

            return ServiceTypeList = (_setting.IsMongoDb) ? await _context
                            .ServiceTypes
                            .Find(p => true)
                            .ToListAsync()
                            : await _contextPostgres
                            .ServiceTypes
                            .ToListAsync();

           
        }

        public async Task<ServiceType> GetServiceType(string id)
        {
            var ServiceType = new ServiceType();

            return ServiceType = (_setting.IsMongoDb) ? await _context
                            .ServiceTypes
                            .Find(p => p.ServiceTypeId == id)
                            .FirstOrDefaultAsync()
                            : await _contextPostgres
                            .ServiceTypes
                            .Where(p => p.ServiceTypeId == id)
                            .FirstOrDefaultAsync();



           
        }


        public async Task<IEnumerable<ServiceType>> GetServiceTypeByName(string serviceTypeName)
        {
            List<ServiceType> ServiceTypeList = new List<ServiceType>();
            if (!_setting.IsMongoDb)
            {



                return await _contextPostgres
                              .ServiceTypes
                              .Where(p => p.ServiceTypeName.StartsWith(serviceTypeName))
                              .ToListAsync();
            }



            FilterDefinition<ServiceType> filter = Builders<ServiceType>.Filter.Where(p => p.ServiceTypeName.StartsWith(serviceTypeName));

            return await _context
                          .ServiceTypes
                          .Find(filter)
                          .ToListAsync();
        }

        public async Task<IEnumerable<ServiceType>> GetServiceTypeByCategory(string categoryId)
        {
            List<ServiceType> ServiceTypeList = new List<ServiceType>();
            if (!_setting.IsMongoDb)
            {



                return await _contextPostgres
                              .ServiceTypes
                              .Where(p => p.CategoryId == categoryId)
                              .ToListAsync();
            }



            FilterDefinition<ServiceType> filter = Builders<ServiceType>.Filter.ElemMatch(p => p.CategoryId, categoryId);

            return await _context
                          .ServiceTypes
                          .Find(filter)
                          .ToListAsync();
        }


        public async Task<IEnumerable<ServiceType>> GetServiceTypeByDate(DateTime fromDate, DateTime ToDate)
        {

            List<ServiceType> ServiceTypeList = new List<ServiceType>();
            if (!_setting.IsMongoDb)
            {



                return await _contextPostgres
                              .ServiceTypes
                              .Where(p => p.CreatedOn >= fromDate && p.CreatedOn <= ToDate)
                              .ToListAsync();
            }


            FilterDefinition<ServiceType> filter = Builders<ServiceType>.Filter.Where(p => p.CreatedOn >= fromDate && p.CreatedOn <= ToDate);

            return await _context
                          .ServiceTypes
                          .Find(filter)
                          .ToListAsync();
        }
        public async Task<bool> Create(ServiceType serviceTypes)
        {
            if (!_setting.IsMongoDb)
            {

                _contextPostgres
                            .ServiceTypes
                            .Add(serviceTypes);

                /* return*/
                return await _contextPostgres.SaveChangesAsync() > 0;
            }

            try
            {
                await _context.ServiceTypes.InsertOneAsync(serviceTypes);

                return true;
            }
            catch (Exception exc) { return false; }


           

        }

        public async Task<bool> Update(ServiceType serviceType)
        {
            if (!_setting.IsMongoDb)
            {

                _contextPostgres
                            .ServiceTypes
                            .Update(serviceType);

                return await _contextPostgres.SaveChangesAsync() > 0;
            }


            var updateResult = await _context
                                        .ServiceTypes
                                        .ReplaceOneAsync(filter: g => g.ServiceTypeId == serviceType.ServiceTypeId, replacement: serviceType);

            return updateResult.IsAcknowledged
                    && updateResult.ModifiedCount > 0;
        }

        public async Task<bool> Delete(string id)
        {
            if (!_setting.IsMongoDb)
            {
                var entity = _contextPostgres
                            .ServiceTypes
                            .FirstOrDefault(t => t.ServiceTypeId == id);

                _contextPostgres.ServiceTypes.Remove(entity);



                /* return*/
                return await _contextPostgres.SaveChangesAsync() > 0;
            }

            FilterDefinition<ServiceType> filter = Builders<ServiceType>.Filter.Eq(m => m.ServiceTypeId, id);
            DeleteResult deleteResult = await _context
                                                .ServiceTypes
                                                .DeleteOneAsync(filter);

            return deleteResult.IsAcknowledged
                && deleteResult.DeletedCount > 0;
        }


    }
}
