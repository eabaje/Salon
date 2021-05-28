

using Salon.CustomerBase.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Salon.CustomerBase.Infrastructure.Repositories.Interfaces
{
   public interface IFavoriteServices
    {
        Task<bool> AddFavorite(Favorite favorite);
        Task<bool> UpdateFavorite(Favorite favorite);
        Task<bool> Delete(string id);
        Task<Favorite> GetFavoriteById(string id);
        Task<Favorite> GetFavoriteBySalon(string salonId);
        Task<List<Favorite>> GetFavorite();
        Task<List<Favorite>> GetFavoriteByIsActive(bool isActive);
        Task<List<Favorite>> GetFavoriteByCustomer(string customerId);
    }
}
