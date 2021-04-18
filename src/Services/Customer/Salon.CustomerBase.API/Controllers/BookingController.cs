using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Salon.CustomerBase.Core.Entities;
using Salon.CustomerBase.Infrastructure.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;



namespace Salon.CustomerBase.API.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class BookingController : ControllerBase
    {
        private readonly IBookingRepository _repository;
        private readonly ILogger<BookingController> _logger;

        public BookingController(IBookingRepository repository, ILogger<BookingController> logger)
        {
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }



        // GET: api/<BarberController>

        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<Booking>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<IEnumerable<Booking>>> GetBooking()
        {
            try { 
            var booking = await _repository.GetBooking();
            return Ok(booking);

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
        public async Task<ActionResult<Booking>> GetBooking(string id)
        {
            try { 
            var booking = await _repository.GetBookingById(id);
            return Ok(booking);

            }
            catch (Exception exc)
            {
                _logger.LogError($"Error: {exc}");
                // transaction.Rollback();
                return NotFound();
            }
        }

        [HttpGet("{salonId}")]
        public async Task<ActionResult<IEnumerable<Booking>>> GetBookingByCustomerSalon(string salonId,string customerId)
        {
            try { 
            var booking = await _repository.GetBookingByCustomerSalon(salonId,customerId);
            return Ok(booking);

            }
            catch (Exception exc)
            {
                _logger.LogError($"Error: {exc}");
                // transaction.Rollback();
                return NotFound();
            }
        }

        [HttpGet("{salonId}")]
        public async Task<ActionResult<IEnumerable<Booking>>> GetBookingBySalon(string salonId)
        {

            try { 
            var booking = await _repository.GetBookingBySalon(salonId);
            return Ok(booking);

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
        public async Task<ActionResult<Booking>> CreateBooking([FromBody] Booking Booking)
        {
            try {

                var result = await _repository.AddBooking(Booking);

                if (result) { }

         return Ok();



            }
            catch (Exception exc)
            {
                _logger.LogError($"Error: {exc}");
                // transaction.Rollback();
                return NotFound();
            }
        }

        [HttpPut]
        [ProducesResponseType(typeof(Booking), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> UpdateBarber([FromBody] Booking Booking)
        {
            try { 
            return Ok(await _repository.UpdateBooking(Booking));
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
