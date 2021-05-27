using AutoMapper;
using MassTransit;
using Microsoft.AspNetCore.Http;
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
    public class RatingController : Controller
    {
        // GET: RatingController
        private readonly IRatingRepository _repository;
        private readonly ILogger<RatingController> _logger;
        private readonly IPublishEndpoint _publishEndpoint;
        private readonly IMapper _mapper;

        public RatingController(IRatingRepository repository, ILogger<RatingController> logger, IPublishEndpoint publishEndpoint, IMapper mapper)
        {
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _publishEndpoint = publishEndpoint ?? throw new ArgumentNullException(nameof(publishEndpoint));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }


        // GET: api/<BarberController>

       

        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<Rating>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<IEnumerable<Rating>>> GetRating()
        {
            try
            {
                var Rating = await _repository.GetRatings();
                return Ok(Rating);

            }
            catch (Exception exc)
            {
                _logger.LogError($"Error: {exc}");
                // transaction.Rollback();
                return NotFound();
            }
        }




        // GET api/<BarberController>/5
        [HttpGet("{id}", Name = "GetRating")]
        [ProducesResponseType(typeof(Rating), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<Rating>> GetRating(string id)
        {
            try
            {
                var Rating = await _repository.GetRatingById(id);
                if (Rating == null)
                {
                    return BadRequest();
                }
                return Ok(Rating);

            }
            catch (Exception exc)
            {
                _logger.LogError($"Error: {exc}");
                // transaction.Rollback();
                return NotFound();
            }
        }

        [HttpGet("{salonId}")]
        public async Task<ActionResult<IEnumerable<Rating>>> GetRatingsByCustomerSalon(string salonId, string customerId)
        {
            try
            {
                var Rating = await _repository.GetRatingsByCustomerSalon(salonId, customerId);
                if (Rating == null)
                {
                    return BadRequest();
                }
                return Ok(Rating);

            }
            catch (Exception exc)
            {
                _logger.LogError($"Error: {exc}");
                // transaction.Rollback();
                return NotFound();
            }
        }

        [HttpGet("{salonId}")]
        public async Task<ActionResult<IEnumerable<Rating>>> GetRatingBySalon(string salonId)
        {

            try
            {
                var Rating = await _repository.GetRatingsBySalon(salonId);
                if (Rating == null)
                {
                    return BadRequest();
                }
                return Ok(Rating);

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
        public async Task<ActionResult<Rating>> CreateRating([FromBody] Rating Rating)
        {
            try
            {

                var result = await _repository.AddRating(Rating);

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
        [ProducesResponseType(typeof(Rating), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> UpdateRating([FromBody] Rating Rating)
        {
            try
            {
                return Ok(await _repository.UpdateRating(Rating));
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
