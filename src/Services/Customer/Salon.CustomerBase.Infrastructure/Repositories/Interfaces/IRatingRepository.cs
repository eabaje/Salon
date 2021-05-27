
using Salon.CustomerBase.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Salon.CustomerBase.Infrastructure.Repositories.Interfaces
{
   public  interface IRatingRepository
    {
        Task<Rating> GetRatingById(string id);
        Task<List<Rating>> GetRatings();
        Task<List<Rating>> GetRatingsBySalon(string salonId);
        Task<List<Rating>> GetRatingsByCustomerSalon(string salonId, string customerId);
        Task<bool> AddRating(Rating booking);
        Task<bool> UpdateRating(Rating booking);
        Task<bool> Delete(string id);
    }
}
