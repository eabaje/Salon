using Salon.BarberShopBase.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Salon.BarberShopBase.Infrastructure.Repositories.Interfaces
{
   public  interface ICategoryRepository
    {
        Task<IEnumerable<Category>> GetCategory();
        Task<Category> GetCategory(string id);
        Task<IEnumerable<Category>> GetCategoryByName(string name);
      

        Task<bool> Create(Category category);
        Task<bool> Update(Category category);
        Task<bool> Delete(string id);
    }
}
