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
    public class ActivityController : ControllerBase
    {

        private readonly ILogger<ActivityController> _logger;

        private readonly IActivityRepository _repoActivity;

        public ActivityController(

            IActivityRepository repoActivity, ILogger<ActivityController> logger)
        {
            _logger = logger;

            _repoActivity = repoActivity;

        }
        /// <summary>
        /// Get a paginated list of the catalog activity
        /// </summary>
        /// <param name="pageNum">Page number</param>
        /// <param name="pageSize">Page size</param>
        /// <returns>Paginated list of Catalog Activity</returns>
        /// <response code="200">Request successfully processed</response>
        /// <response code="400">Error in the request parameters</response>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpGet("activity")]
        public async Task<ActionResult<IEnumerable<Activity>>> GetActivity([FromQuery] int pageNum = 0, [FromQuery] int pageSize = 10)
        {
            try
            {
                return Ok(await _repoActivity.GetActivity(pageSize, pageNum));
            }
            catch (ArgumentOutOfRangeException e)
            {
                return BadRequest(e.Message);
            }
        }
        /// <summary>
        /// Get the specified Catalog Activity from its identifier
        /// </summary>
        /// <param name="id">Identifier of the catalog activity to be retreived</param>
        /// <returns>Catalog Activity found</returns>
        /// <response code="200">Catalog Activity with the given ID found</response>
        /// <response code="404">No catalog activity with the given ID found</response>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]

        [HttpGet("activity/{id:int}")]
        public async Task<ActionResult<Activity>> GetActivityById(int id)
        {
            var res = await _repoActivity.GetActivityById(id);
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