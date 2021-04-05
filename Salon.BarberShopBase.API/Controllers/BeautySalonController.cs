using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Salon.BarberShop.API.Entities;
using Salon.BarberShop.API.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;



namespace Salon.BarberShop.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BeautySalonController : ControllerBase
    {

        private readonly IBeautySalonRepository _repository;
        private readonly ILogger<BeautySalonController> _logger;


        public BeautySalonController(IBeautySalonRepository repository, ILogger<BeautySalonController> logger)
        {
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<BeautySalon>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<IEnumerable<BeautySalon>>> GetBeautySalon()
        {
            try
            {
                var price = await _repository.GetBeautySalon();
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
        public async Task<ActionResult<IEnumerable<BeautySalon>>> GetBeautySalon(string id)
        {
            try
            {
                var beauty = await _repository.GetBeautySalon(id);
                return Ok(beauty);

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
        public async Task<ActionResult<IEnumerable<BeautySalon>>> GetBeautySalonById(string id)
        {
            try
            {
                var beauty = await _repository.GetBeautySalon(id);
                return Ok(beauty);

            }
            catch (Exception exc)
            {
                _logger.LogError($"Error: {exc}");
                // transaction.Rollback();
                return NotFound();
            }
        }


        [HttpGet("{id}")]
        public async Task<ActionResult<IEnumerable<BeautySalon>>> GetBeautySalonByLocation(string location)
        {
            try
            {
                var beauty = await _repository.GetBeautySalonByLocation(location);
                return Ok(beauty);

            }
            catch (Exception exc)
            {
                _logger.LogError($"Error: {exc}");
                // transaction.Rollback();
                return NotFound();
            }
        }


        [HttpGet("{id}")]
        public async Task<ActionResult<IEnumerable<BeautySalon>>> GetBeautySalonByCategory(string category)
        {
            try
            {
                var beauty = await _repository.GetBeautySalonByCategory(category);
                return Ok(beauty);

            }
            catch (Exception exc)
            {
                _logger.LogError($"Error: {exc}");
                // transaction.Rollback();
                return NotFound();
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<IEnumerable<BeautySalon>>> GetBeautySalonByName(string name)
        {
            try
            {
                var beauty = await _repository.GetBeautySalonByName(name);
                return Ok(beauty);

            }
            catch (Exception exc)
            {
                _logger.LogError($"Error: {exc}");
                // transaction.Rollback();
                return NotFound();
            }
        }


        [HttpPost]
        public async Task<ActionResult<BeautySalon>> CreateBeautySalon([FromBody] BeautySalon salon)
        {
            try
            {
                await _repository.Create(salon);

                return CreatedAtRoute("BeautySalon", new { id = salon.BeautySalonId }, salon);
            }
            catch (Exception exc)
            {
                _logger.LogError($"Error: {exc}");
                // transaction.Rollback();
                return NotFound();
            }
        }

        [HttpPut]
        [ProducesResponseType(typeof(BeautySalon), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> UpdateBeautySalon([FromBody] BeautySalon beauty)
        {
            try
            {
                return Ok(await _repository.Update(beauty));
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
