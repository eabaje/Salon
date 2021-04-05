using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Salon.CustomerBase.Infrastructure.Repositories.Interfaces;
using Salon.CustomerBase.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;



namespace Salon.CustomerBase.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerRepository _repository;
        private readonly ILogger<CustomerController> _logger;

        public CustomerController(ICustomerRepository repository, ILogger<CustomerController> logger)
        {
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }



        // GET: api/<BarberController>

        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<Customer>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<IEnumerable<Customer>>> GetCustomer()
        {
            try { 
            var customer = await _repository.GetCustomer();
            return Ok(customer);
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
        public async Task<ActionResult<Customer>> GetCustomer(string id)
        {
            try { 
            var customer = await _repository.GetCustomerById(id);
            return Ok(customer);
            }
            catch (Exception exc)
            {
                _logger.LogError($"Error: {exc}");
                // transaction.Rollback();
                return NotFound();
            }
        }

       

      
        // POST api/<BarberController>
        [HttpPost]
        public async Task<ActionResult<Customer>> AddCustomer([FromBody] Customer customer)
        {
            try { 
            return Ok(await _repository.AddCustomer(customer));

             }
            catch (Exception exc)
            {
                _logger.LogError($"Error: {exc}");
                // transaction.Rollback();
                return NotFound();
            }   
        }

        [HttpPut]
        [ProducesResponseType(typeof(Customer), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> UpdateCustomer([FromBody] Customer customer)
        {
            try { 
            return Ok(await _repository.UpdateCustomer(customer));


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
            try { 
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
