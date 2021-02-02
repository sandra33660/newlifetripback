using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Catalog.API.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Catalog.API.Controllers
{

    [ApiController]
    [Route("api/v1/[controller]")]
    public class CityController : ControllerBase
    {
        private readonly ILogger<CityController> _logger;

        private readonly ICityRepository _repoCity;
        public CityController(

            ICityRepository repoCity, ILogger<CityController> logger)
        {
            _logger = logger;

            _repoCity = repoCity;
        }
        /// <summary>
        /// Get a paginated list of the catalog city
        /// </summary>
        /// <param name="pageNum">Page number</param>
        /// <param name="pageSize">Page size</param>
        /// <returns>Paginated list of Catalog City</returns>
        /// <response code="200">Request successfully processed</response>
        /// <response code="400">Error in the request parameters</response>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpGet("city")]
        public async Task<ActionResult<IEnumerable<City>>> GetCity([FromQuery] int pageNum = 0, [FromQuery] int pageSize = 10)
        {
            try
            {
                return Ok(await _repoCity.GetCity(pageSize, pageNum));
            }
            catch (ArgumentOutOfRangeException e)
            {
                return BadRequest(e.Message);
            }
        }
        /// <summary>
        /// Get the specified Catalog City from its identifier
        /// </summary>
        /// <param name="id">Identifier of the catalog city to be retreived</param>
        /// <returns>Catalog City found</returns>
        /// <response code="200">Catalog City with the given ID found</response>
        /// <response code="404">No catalog city with the given ID found</response>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpGet("city/{id:int}")]
        public async Task<ActionResult<City>> GetCityById(int id)
        {
            var res = await _repoCity.GetCityById(id);
            if (res == null)
            {
                return NotFound();
            }
            else
            {
                return res;
            }
        }
    }
}