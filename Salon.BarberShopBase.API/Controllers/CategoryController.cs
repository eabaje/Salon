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
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryRepository _repository;
        private readonly ILogger<CategoryController> _logger;


        public CategoryController(ICategoryRepository repository, ILogger<CategoryController> logger)
        {
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<Category>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<IEnumerable<Category>>> GetCategory()
        {
            try
            {
                var price = await _repository.GetCategory();
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
        public async Task<ActionResult<IEnumerable<Category>>> GetCategory(string id)
        {
            try
            {
                var beauty = await _repository.GetCategory(id);
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
        public async Task<ActionResult<IEnumerable<Category>>> GetCategoryByName(string category)
        {
            try
            {
                var beauty = await _repository.GetCategoryByName(category);
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
        public async Task<ActionResult<Calendar>> CreateCategory([FromBody] Category category)
        {
            try
            {
                await _repository.Create(category);

                return CreatedAtRoute("GetCategory", new { id = category.CategoryId }, category);
            }
            catch (Exception exc)
            {
                _logger.LogError($"Error: {exc}");
                // transaction.Rollback();
                return NotFound();
            }
        }

        [HttpPut]
        [ProducesResponseType(typeof(Category), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> UpdateCategory([FromBody] Category category)
        {
            try
            {
                return Ok(await _repository.Update(category));
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
