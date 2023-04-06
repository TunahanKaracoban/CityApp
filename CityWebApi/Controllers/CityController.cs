using CityWebApi.Models;
using CityWebApi.Repository.Abstract;
using CityWebApi.Repository.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CityWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CityController : ControllerBase
    {
        private readonly ICityRepository _dbcity;
        public CityController(ICityRepository dbcity)
        {
            _dbcity = dbcity;
        }
        // GET: api/Sehirler
        [HttpGet]
        public async Task<ActionResult<IEnumerable<City>>> GetAllCity()
        {
            return await _dbcity.GetAllAsync();
        }

        // GET: api/Sehirler/5
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<City>> GetCity(int id)
        {
            if (id == 0) 
            {
                return BadRequest();
            }
            var city = await _dbcity.GetAsync(u => u.Id == id);

            if (city == null)
            {
                return NotFound();
            }
            return city;
        }
        // POST: api/Sehirler
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<City>> CreateCity([FromBody] City city)
        {
            if (city == null)
            {
                return BadRequest(city);
            }

            await _dbcity.CreateAsync(city);

            return CreatedAtAction(nameof(GetCity), new { id = city.Id }, city);
        }

        // PUT: api/Sehirler/5
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> UpdateCity(int id,[FromBody] City city)
        {
            if (id != city.Id)
            {
                return BadRequest("Invalid request");
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var existingCity = await _dbcity.GetAsync(c => c.Id == id);
            if (existingCity == null)
            {
                return NotFound();
            }

            existingCity.CityName = city.CityName;
            existingCity.CountryName = city.CountryName;

            await _dbcity.UpdateAsync(existingCity);

            return NoContent();
        }

        // DELETE: api/Sehirler/5
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCity(int id)
        {
            if (id == 0)
            {
                return BadRequest();
            }
            var city = await _dbcity.GetAsync(u => u.Id == id);

            if (city == null)
            {
                return NotFound();
            }

            await _dbcity.RemoveAsync(city);

            return NoContent();
        }
    }
}
