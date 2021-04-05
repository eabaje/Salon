using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Salon.BarberShopBase.Entities;
using Salon.BarberShop.Infrastructure.Repositories.Interfaces;
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
    public class CalendarController : ControllerBase
    {
        private readonly ICalendarRepository _repository;
        private readonly ILogger<CalendarController> _logger;


        public CalendarController(ICalendarRepository repository, ILogger<CalendarController> logger)
        {
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<Calendar>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<IEnumerable<Calendar>>> GetCalendar()
        {
            try
            {
                var price = await _repository.GetCalendar();
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
        public async Task<ActionResult<IEnumerable<Calendar>>> GetCalendar(string id)
        {
            try
            {
                var beauty = await _repository.GetCalendar(id);
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
        public async Task<ActionResult<IEnumerable<Calendar>>> GetCalendarByBarber(string salonId,string barberId)
        {
            try
            {
                var beauty = await _repository.GetCalendarByBarber(salonId, barberId);
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
        public async Task<ActionResult<IEnumerable<Calendar>>> GetCalendarBySalon(string salonId)
        {
            try
            {
                var beauty = await _repository.GetCalendarBySalon(salonId);
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
        public async Task<ActionResult<IEnumerable<Calendar>>> GetCalendarByBooked(bool booked)
        {
            try
            {
                var beauty = await _repository.GetCalendarByBooked(booked);
                return Ok(beauty);

            }
            catch (Exception exc)
            {
                _logger.LogError($"Error: {exc}");
                // transaction.Rollback();
                return NotFound();
            }
        }


        public async Task<ActionResult<IEnumerable<Calendar>>> GetCalendarByDate(string fromdate, string todate, string salonId)
        {
            try
            {
                var beauty = await _repository.GetCalendarByDate(Convert.ToDateTime(fromdate), Convert.ToDateTime(todate), salonId);
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
        public async Task<ActionResult<Calendar>> CreateCalender([FromBody] Calendar calendar)
        {
            try
            {
                await _repository.Create(calendar);

                return CreatedAtRoute("Calendar", new { id = calendar.CalenderId }, calendar);
            }
            catch (Exception exc)
            {
                _logger.LogError($"Error: {exc}");
                // transaction.Rollback();
                return NotFound();
            }
        }

        [HttpPut]
        [ProducesResponseType(typeof(Calendar), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> UpdateCalendar([FromBody] Calendar calendar)
        {
            try
            {
                return Ok(await _repository.Update(calendar));
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
        public async Task<IActionResult> DeleteCalender(string id)
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
