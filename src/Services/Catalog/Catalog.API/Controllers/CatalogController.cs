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
    public class CatalogController : ControllerBase
    {


        private readonly ILogger<CatalogController> _logger;
        private readonly ITripRepository _repoTrip;

        public CatalogController(
            ITripRepository repoTrip, ILogger<CatalogController> logger)
        {
            _logger = logger;
            _repoTrip = repoTrip;

        }

        /// <summary>
        /// Get a paginated list of the catalog trip
        /// </summary>
        /// <param name="pageNum">Page number</param>
        /// <param name="pageSize">Page size</param>
        /// <returns>Paginated list of Catalog Trip</returns>
        /// <response code="200">Request successfully processed</response>
        /// <response code="400">Error in the request parameters</response>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpGet("trip")]
        public async Task<ActionResult<Trip>> GetTrip([FromQuery] int pageNum = 0, [FromQuery] int pageSize = 10)
        {
            try
            {
                return Ok(await _repoTrip.GetTrip(pageSize, pageNum));
            }
            catch (ArgumentOutOfRangeException e)
            {
                return BadRequest(e.Message);
            }
        }

        ///// <summary>
        ///// Get the specified Catalog trip from its identifier
        ///// </summary>
        ///// <param name="id">Identifier of the catalog trip to be retreived</param>
        ///// <returns>Catalog trip found</returns>
        ///// <response code="200">Catalog Trip with the given ID found</response>
        ///// <response code="404">No catalog trip with the given ID found</response>
        //[ProducesResponseType(StatusCodes.Status200OK)]
        //[ProducesResponseType(StatusCodes.Status404NotFound)]
        //[HttpGet("trip/{id:int}")]
        //public async Task<ActionResult<Trip>> GetTripById(int id)
        //{
        //    var res = await _repoTrip.GetTripById(id);
        //    if (res == null)
        //    {
        //        return NotFound();
        //    }
        //    else
        //    {
        //        return res;
        //    }
        //}


    }

}
