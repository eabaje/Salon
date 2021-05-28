

using Salon.WebUI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Salon.WebUI.Services.Interfaces
{
   public  interface IRatingService
    {
        Task<RatingModel> GetRatingById(string id);
        Task<List<RatingModel>> GetRatings();
        Task<List<RatingModel>> GetRatingsBySalon(string salonId);
        Task<List<RatingModel>> GetRatingsByCustomerSalon(string salonId, string customerId);
        Task<bool> AddRating(RatingModel ratiing);
        Task<bool> UpdateRating(RatingModel rating);
        Task<bool> Delete(string id);
    }
}
