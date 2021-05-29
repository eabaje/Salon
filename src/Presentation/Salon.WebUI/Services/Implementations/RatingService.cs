
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Salon.WebUI.Models;
using Salon.WebUI.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace Salon.WebUI.Services.Implementations
{
   public class RatingService : IRatingService
    {
        private readonly HttpClient _client;

        public RatingService(HttpClient client, ILogger<RatingService> logger)
        {
            _client = client ?? throw new ArgumentNullException(nameof(client));
        }
      

        public async Task AddRatingModel(RatingModel model)
        {
           // var response = await _client.PostAsync($"/Catalog", model);

            var orderContent = new StringContent(JsonConvert.SerializeObject(model), System.Text.Encoding.UTF8, "application/json");

            var response = await _client.PostAsync($"/Catalog", orderContent);

            if (response.StatusCode == System.Net.HttpStatusCode.InternalServerError)
            {
                throw new Exception("Something went wrong when calling api.");
            }
            //  return await response.ReadContentAs<RatingModel>();
            
            response.EnsureSuccessStatusCode();



        }

        public async Task UpdateRating(RatingModel model)
        {
            var orderContent = new StringContent(JsonConvert.SerializeObject(model), System.Text.Encoding.UTF8, "application/json");

            var response = await _client.PutAsync($"/Catalog", orderContent);

            if (response.StatusCode == System.Net.HttpStatusCode.InternalServerError)
            {
                throw new Exception("Something went wrong when calling api.");
            }
            //  return await response.ReadContentAs<RatingModel>();

            response.EnsureSuccessStatusCode();
        }

        public async Task<bool> Delete(string id)
        {
            var orderContent = new StringContent(JsonConvert.SerializeObject(model), System.Text.Encoding.UTF8, "application/json");

            var response = await _client.PutAsync($"/Catalog", orderContent);

            if (response.StatusCode == System.Net.HttpStatusCode.InternalServerError)
            {
                throw new Exception("Something went wrong when calling api.");
            }
            //  return await response.ReadContentAs<RatingModel>();

            response.EnsureSuccessStatusCode();
        }

        public async Task<RatingModel> GetRatingModelById(string id)
        {
            return await _context.RatingModels.FirstOrDefaultAsync(t => t.RateId == Guid.Parse(id));
        }

        public async Task<List<RatingModel>> GetRatingModels()
        {
            return await _context.RatingModels.ToListAsync();
        }

        public async Task<List<RatingModel>> GetRatingModelsBySalon(string salonId)
        {
            return await _context.RatingModels.Where(p => p.SalonId == salonId).OrderByDescending(c => c.CustomerId).ToListAsync();
        }

        public async Task<List<RatingModel>> GetRatingModelsByCustomerSalon(string salonId, string customerId)
        {
            return await _context.RatingModels.Where(p => p.SalonId == salonId && p.CustomerId == customerId).OrderByDescending(c => c.CustomerId).ToListAsync();
        }
    }
}
