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
    public class BarberController : ControllerBase
    {
        private readonly IBarberRepository _repository;
        private readonly ILogger<BarberController> _logger;

        public BarberController(IBarberRepository repository, ILogger<BarberController> logger)
        {
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }



        // GET: api/<BarberController>
       
        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<Barber>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<IEnumerable<Barber>>> GetBarber()
        {
            var barber = await _repository.GetBarber();
            return Ok(barber);
        }




        // GET api/<BarberController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<IEnumerable<Barber>>> GetBarber(string id)
        {
            var barber = await _repository.GetBarber(id);
            return Ok(barber);
        }

        [HttpGet("{salonId}")]
        public async Task<ActionResult<IEnumerable<Barber>>> GetBarberBySalon(string salonId)
        {
            var barber = await _repository.GetBarberBySalon(salonId);
            return Ok(barber);
        }

        [HttpGet("{barberName}")]
        public async Task<ActionResult<IEnumerable<Barber>>> GetBarberByName(string barberName)
        {
            var barber = await _repository.GetBarberByName(barberName);
            return Ok(barber);
        }
        // POST api/<BarberController>
        [HttpPost]
        public async Task<ActionResult<Barber>> CreateBarber([FromBody] Barber barber)
        {
            await _repository.Create(barber);

            return CreatedAtRoute("GetBarber", new { id = barber.BarberId }, barber);
        }

        [HttpPut]
        [ProducesResponseType(typeof(Barber), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> UpdateBarber([FromBody] Barber barber)
        {
            return Ok(await _repository.Update(barber));
        }

        

        // DELETE api/<BarberController>/5
        [HttpDelete("{id}")]
       
        [ProducesResponseType(typeof(void), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> DeleteBarber(string id)
        {
            return Ok(await _repository.Delete(id));
        }
    }
}
