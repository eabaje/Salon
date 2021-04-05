using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Salon.BarberShop.API.Entities;
using Salon.BarberShop.API.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Salon.BarberShop.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PriceListController : ControllerBase
    {
        private readonly IPriceListRepository _repository;
        private readonly ILogger<PriceListController> _logger;



        public PriceListController(IPriceListRepository repository, ILogger<PriceListController> logger)
        {
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<PriceList>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<IEnumerable<PriceList>>> GetPriceList()
        {
            try
            {
                var price = await _repository.GetPriceList();
                return Ok(price);

            }
            catch (Exception exc)
            {
                _logger.LogError($"Error: {exc}");
                // transaction.Rollback();
                return NotFound();
            }
        }




        // GET api/<BarberController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<IEnumerable<PriceList>>> GetPriceList(string id)
        {
            try
            {
                var price = await _repository.GetPriceList(id);
                return Ok(price);

            }
            catch (Exception exc)
            {
                _logger.LogError($"Error: {exc}");
                // transaction.Rollback();
                return NotFound();
            }
        }


        [HttpPost]
        public async Task<ActionResult<PriceList>> CreatePrice([FromBody] PriceList price)
        {
            try
            {
                await _repository.Create(price);

                return CreatedAtRoute("GetPrice", new { id = price.PriceListId }, price);
            }
            catch (Exception exc)
            {
                _logger.LogError($"Error: {exc}");
                // transaction.Rollback();
                return NotFound();
            }
        }

        [HttpPut]
        [ProducesResponseType(typeof(PriceList), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> UpdatePrice([FromBody] PriceList price)
        {
            try
            {
                return Ok(await _repository.Update(price));
            }
            catch (Exception exc)
            {
                _logger.LogError($"Error: {exc}");
                // transaction.Rollback();
                return NotFound();
            }
        }



        // DELETE api/<BarberController>/5
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
