using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Salon.BarberShopBase.Core.Entities;
using Salon.BarberShopBase.Infrastructure.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;



namespace Salon.BarberShopBase.API.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class AppointmentController : ControllerBase
    { 
        
        private readonly IAppointmentRepository _repository;
        private readonly ILogger<AppointmentController> _logger;
        
       

        public AppointmentController(IAppointmentRepository repository, ILogger<AppointmentController> logger)
        {
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }



        // GET: api/<BarberController>

        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<Appointment>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<IEnumerable<Appointment>>> GetAppointment()
        {
            try
            {
                var barber = await _repository.GetAppointment();
            return Ok(barber);

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
        public async Task<ActionResult<IEnumerable<Appointment>>> GetAppointment(string id)
        {
            try
            {
                var barber = await _repository.GetAppointment(id);
            return Ok(barber);

            }
            catch (Exception exc)
            {
                _logger.LogError($"Error: {exc}");
                // transaction.Rollback();
                return NotFound();
            }
        }


        [HttpGet("{salonId}")]
        public async Task<ActionResult<IEnumerable<Appointment>>> GetAppointmentBySalon(string salonId)
        {
            try
            {
                var barber = await _repository.GetAppointmentBySalon(salonId);
            return Ok(barber);


        }
            catch (Exception exc)
            {
                _logger.LogError($"Error: {exc}");
               // transaction.Rollback();
                return NotFound();
    }
}

        [HttpGet("{customerId}")]
        public async Task<ActionResult<IEnumerable<Appointment>>> GetAppointmentByCustomer(string customerId)
        {
            try
            {
                var barber = await _repository.GetAppointmentByCustomer(customerId);
            return Ok(barber);


            }
            catch (Exception exc)
            {
            _logger.LogError($"Error: {exc}");
            // transaction.Rollback();
            return NotFound();
            }
        }

        [HttpGet("{fromdate}")]
        public async Task<ActionResult<IEnumerable<Appointment>>> GetAppointmentByDate(string fromdate,string todate,string salonId)
        {
            try
            {
            var barber = await _repository.GetAppointmentByDate(Convert.ToDateTime(fromdate), Convert.ToDateTime(todate),salonId);
            return Ok(barber);
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
        public async Task<ActionResult<Appointment>> CreateAppointment([FromBody] Appointment appointment)
            {
                try
                {



                    await _repository.Create(appointment);

            return CreatedAtRoute("GetAppointment", new { id = appointment.AppointmentId }, appointment);
            }
            catch (Exception exc)
            {
                _logger.LogError($"Error: {exc}");
                // transaction.Rollback();
                return NotFound();
            }
        }

        [HttpPut]
        [ProducesResponseType(typeof(Appointment), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> UpdateAppointment([FromBody] Appointment appointment)
        {
            try 
            { 
            return Ok(await _repository.Update(appointment));
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
