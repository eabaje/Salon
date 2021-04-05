using MongoDB.Driver;
using Salon.BarberShopBase.Infrastructure.Data.Interfaces;
using Salon.BarberShopBase.Core.Entities;
using Salon.BarberShopBase.Infrastructure.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Salon.BarberShopBase.Infrastructure.Settings;
using Salon.BarberShopBase.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Salon.BarberShopBase.Infrastructure.Repositories.Implementations
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly IBeautySalonContext _context;
        private readonly PostgresDBContext _contextPostgres;
        private readonly IBarberDatabaseSettings _setting;

        public CategoryRepository(IBeautySalonContext BarberContext, IBarberDatabaseSettings setting, PostgresDBContext contextPostgres)
        {
            _context = BarberContext ?? throw new ArgumentNullException(nameof(BarberContext));

            _setting = setting ?? throw new ArgumentNullException(nameof(setting));

            _contextPostgres = contextPostgres ?? throw new ArgumentNullException(nameof(contextPostgres));
        }


        public async Task<IEnumerable<Category>> GetCategory()
        {
            List<Category> CategoryList = new List<Category>();

            return CategoryList = (_setting.IsMongoDb) ? await _context
                            .Categorys
                            .Find(p => true)
                            .ToListAsync()
                            : await _contextPostgres
                            .Categorys
                            .ToListAsync();

          
        }

        public async Task<Category> GetCategory(string id)
        {

            var Category = new Category();

            return Category = (_setting.IsMongoDb) ? await _context
                            .Categorys
                            .Find(p => p.CategoryId == id)
                            .FirstOrDefaultAsync()
                            : await _contextPostgres
                            .Categorys
                            .Where(p => p.CategoryId == id)
                            .FirstOrDefaultAsync();
          
        }

       
        public async Task<IEnumerable<Category>> GetCategoryByName(string categoryName)
        {

            List<Category> CategoryList = new List<Category>();
            if (!_setting.IsMongoDb)
            {



                return await _contextPostgres
                              .Categorys
                              .Where(p => p.CategoryName.StartsWith(categoryName))
                              .ToListAsync();
            }




            FilterDefinition<Category> filter = Builders<Category>.Filter.Where(p => p.CategoryName.StartsWith(categoryName));

            return await _context
                          .Categorys
                          .Find(filter)
                          .ToListAsync();
        }



        public async Task<IEnumerable<Category>> GetCategoryByDate(DateTime fromDate, DateTime ToDate)
        {

            List<Category> CategoryList = new List<Category>();
            if (!_setting.IsMongoDb)
            {



                return await _contextPostgres
                              .Categorys
                              .Where(p => p.CreatedOn >= fromDate && p.CreatedOn <= ToDate)
                              .ToListAsync();
            }



            FilterDefinition<Category> filter = Builders<Category>.Filter.Where(p => p.CreatedOn >= fromDate && p.CreatedOn <= ToDate);

            return await _context
                          .Categorys
                          .Find(filter)
                          .ToListAsync();
        }
        public async Task<bool> Create(Category category)
        {
            if (!_setting.IsMongoDb)
            {

                _contextPostgres
                            .Categorys
                            .Add(category);

                /* return*/
                return await _contextPostgres.SaveChangesAsync() > 0;
            }

            try
            {
                await _context.Categorys.InsertOneAsync(category);

                return true;
            }
            catch (Exception exc) { return false; }


          

        }

        public async Task<bool> Update(Category category)
        {
            if (!_setting.IsMongoDb)
            {

                _contextPostgres
                            .Categorys
                            .Update(category);

                return await _contextPostgres.SaveChangesAsync() > 0;
            }

            var updateResult = await _context
                                        .Categorys
                                        .ReplaceOneAsync(filter: g => g.CategoryId == category.CategoryId, replacement: category);

            return updateResult.IsAcknowledged
                    && updateResult.ModifiedCount > 0;
        }

        public async Task<bool> Delete(string id)
        {
            if (!_setting.IsMongoDb)
            {
                var entity = _contextPostgres
                            .Categorys
                            .FirstOrDefault(t => t.CategoryId == id);

                _contextPostgres.Categorys.Remove(entity);



                /* return*/
                return await _contextPostgres.SaveChangesAsync() > 0;
            }


            FilterDefinition<Category> filter = Builders<Category>.Filter.Eq(m => m.CategoryId, id);
            DeleteResult deleteResult = await _context
                                                .Categorys
                                                .DeleteOneAsync(filter);

            return deleteResult.IsAcknowledged
                && deleteResult.DeletedCount > 0;
        }


    }
}
