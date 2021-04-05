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
    public class ServiceTypeController : ControllerBase
    {
        private readonly IServiceTypeRepository _repository;
        private readonly ILogger<ServiceTypeController> _logger;


        public ServiceTypeController(IServiceTypeRepository repository, ILogger<ServiceTypeController> logger)
        {
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<ServiceType>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<IEnumerable<ServiceType>>> GetServiceType()
        {
            try
            {
                var price = await _repository.GetServiceType();
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
        public async Task<ActionResult<IEnumerable<ServiceType>>> GetServiceType(string id)
        {
            try
            {
                var beauty = await _repository.GetServiceType(id);
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
        public async Task<ActionResult<IEnumerable<ServiceType>>> GetServiceTypeByCategory(string id)
        {
            try
            {
                var beauty = await _repository.GetServiceTypeByCategory(id);
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
        public async Task<ActionResult<IEnumerable<ServiceType>>> GetServiceTypeByName(string name)
        {
            try
            {
                var beauty = await _repository.GetServiceTypeByName(name);
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
        public async Task<ActionResult<ServiceType>> CreateServiceType([FromBody] ServiceType serviceType)
        {
            try
            {
                await _repository.Create(serviceType);

                return CreatedAtRoute("ServiceType", new { id = serviceType.ServiceTypeId }, serviceType);
            }
            catch (Exception exc)
            {
                _logger.LogError($"Error: {exc}");
                // transaction.Rollback();
                return NotFound();
            }
        }

        [HttpPut]
        [ProducesResponseType(typeof(ServiceType), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> UpdateServiceType([FromBody] ServiceType serviceType)
        {
            try
            {
                return Ok(await _repository.Update(serviceType));
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
