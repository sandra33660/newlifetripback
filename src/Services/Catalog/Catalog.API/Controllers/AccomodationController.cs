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
    public class AccomodationController : ControllerBase
    {
        private readonly ILogger<AccomodationController> _logger;

        private readonly IAccomodationRepository _repoAccomodation;

        public AccomodationController(
            IAccomodationRepository repoAccomodation,

           ILogger<AccomodationController> logger)
        {
            _logger = logger;

            _repoAccomodation = repoAccomodation;

        }
        /// <summary>
        /// Get a paginated list of the catalog accomodation
        /// </summary>
        /// <param name="pageNum">Page number</param>
        /// <param name="pageSize">Page size</param>
        /// <returns>Paginated list of Catalog Accomodation</returns>
        /// <response code="200">Request successfully processed</response>
        /// <response code="400">Error in the request parameters</response>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpGet("accomodation")]
        public async Task<ActionResult<IEnumerable<Accomodation>>> GetAccomodation([FromQuery] int pageNum = 0, [FromQuery] int pageSize = 10)
        {
            try
            {
                return Ok(await _repoAccomodation.GetAccomodation(pageSize, pageNum));
            }
            catch (ArgumentOutOfRangeException e)
            {
                return BadRequest(e.Message);
            }
        }
        /// <summary>
        /// Get the specified Catalog Accomodation from its identifier
        /// </summary>
        /// <param name="id">Identifier of the catalog accomodation to be retreived</param>
        /// <returns>Catalog Accomodation found</returns>
        /// <response code="200">Catalog Accomodation with the given ID found</response>
        /// <response code="404">No catalog accomodation with the given ID found</response>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpGet("accomodation/{id:int}")]
        public async Task<ActionResult<Accomodation>> GetAccomodationById(int id)
        {
            var res = await _repoAccomodation.GetAccomodationpById(id);
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