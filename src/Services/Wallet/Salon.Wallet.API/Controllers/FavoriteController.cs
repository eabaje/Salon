using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Salon.WalletBase.API.Entities;
using Salon.WalletBase.API.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;



namespace Salon.FavoriteBase.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FavoriteController : ControllerBase
    {
        private readonly ITransactionRepository _repository;
        private readonly ILogger<FavoriteController> _logger;

        public FavoriteController(ITransactionRepository repository, ILogger<FavoriteController> logger)
        {
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }



        // GET: api/<FavoriteController>

        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<Favorite>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<IEnumerable<Favorite>>> GetFavorite()
        {
            try
            {
                var Favorite = await _repository.GetFavorite();
                return Ok(Favorite);
            }
            catch (Exception exc)
            {
                _logger.LogError($"Error: {exc}");
                // transaction.Rollback();
                return NotFound();
            }
        }




      
        [HttpGet("{id}")]
        public async Task<ActionResult<Favorite>> GetFavoriteById(string id)
        {
            try
            {
                var Favorite = await _repository.GetFavoriteById(id);
                return Ok(Favorite);
            }
            catch (Exception exc)
            {
                _logger.LogError($"Error: {exc}");
                // transaction.Rollback();
                return NotFound();
            }
        }


        [HttpGet("{salonId}")]
        public async Task<ActionResult<Favorite>> GetFavoriteBySalon(string salonId)
        {
            try
            {
                var Favorite = await _repository.GetFavoriteBySalon(salonId);
                return Ok(Favorite);
            }
            catch (Exception exc)
            {
                _logger.LogError($"Error: {exc}");
                // transaction.Rollback();
                return NotFound();
            }
        }


        [HttpGet("{isActive}")]
        public async Task<ActionResult<IEnumerable<Favorite>>> GetFavoriteByIsActive(bool isActive)
        {
            try
            {
                var Favorite = await _repository.GetFavoriteByIsActive(isActive);
                return Ok(Favorite);
            }
            catch (Exception exc)
            {
                _logger.LogError($"Error: {exc}");
                // transaction.Rollback();
                return NotFound();
            }
        }

        [HttpGet("{customerId}")]
        public async Task<ActionResult<IEnumerable<Favorite>>> GetFavoriteByCustomer(string customerId)
        {
            try
            {
                var Favorite = await _repository.GetFavoriteByCustomer(customerId);
                return Ok(Favorite);
            }
            catch (Exception exc)
            {
                _logger.LogError($"Error: {exc}");
                // transaction.Rollback();
                return NotFound();
            }
        }


        [HttpPost]
        public async Task<ActionResult<Favorite>> AddFavorite([FromBody] Favorite favorite)
        {
            try
            {
                return Ok(await _repository.AddFavorite(favorite));

            }
            catch (Exception exc)
            {
                _logger.LogError($"Error: {exc}");
                // transaction.Rollback();
                return NotFound();
            }
        }

        [HttpPut]
        [ProducesResponseType(typeof(Favorite), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> UpdateFavorite([FromBody] Favorite favorite)
        {
            try
            {
                return Ok(await _repository.UpdateFavorite(favorite));


            }
            catch (Exception exc)
            {
                _logger.LogError($"Error: {exc}");
                // transaction.Rollback();
                return NotFound();
            }
        }



        // DELETE api/<FavoriteController>/5
        [HttpDelete("{id}")]

        [ProducesResponseType(typeof(void), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> Delete(string id)
        {
            try
            {
                return Ok(await _repository.Delete(id));

            }
            catch (Exception exc)
            {
                _logger.LogError($"Error: {exc}");
                // transaction.Rollback();
                return NotFound();
            }
        }
    }
}
