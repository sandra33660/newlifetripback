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
        private readonly IAccomodationRepository _repoAccomodation;
        private readonly IActivityRepository _repoActivity;
        private readonly ICommentRepository _repoComment;
        private readonly ICityRepository _repoCity;
        public CatalogController(
            ITripRepository repoTrip, IAccomodationRepository repoAccomodation,
            IActivityRepository repoActivity, ICommentRepository repoComment,
            ICityRepository repoCity, ILogger<CatalogController> logger)
        {
            _logger = logger;
            _repoTrip = repoTrip;
            _repoAccomodation = repoAccomodation;
            _repoActivity = repoActivity;
            _repoComment = repoComment;
            _repoCity = repoCity;
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
        public async Task<ActionResult<IEnumerable<Trip>>> GetTrip([FromQuery] int pageNum = 0, [FromQuery] int pageSize = 10)
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

        /// <summary>
        /// Get the specified Catalog trip from its identifier
        /// </summary>
        /// <param name="id">Identifier of the catalog trip to be retreived</param>
        /// <returns>Catalog trip found</returns>
        /// <response code="200">Catalog Trip with the given ID found</response>
        /// <response code="404">No catalog trip with the given ID found</response>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpGet("trip/{id:int}")]
        public async Task<ActionResult<Trip>> GetTripById(int id)
        {
            var res = await _repoTrip.GetTripById(id);
            if (res == null)
            {
                return NotFound();
            }
            else
            {
                return res;
            }
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
        /// <summary>
        /// Get a paginated list of the catalog comment
        /// </summary>
        /// <param name="pageNum">Page number</param>
        /// <param name="pageSize">Page size</param>
        /// <returns>Paginated list of Catalog Comment</returns>
        /// <response code="200">Request successfully processed</response>
        /// <response code="400">Error in the request parameters</response>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpGet("comment")]
        public async Task<ActionResult<IEnumerable<Comment>>> GetComment([FromQuery] int pageNum = 0, [FromQuery] int pageSize = 10)
        {
            try
            {
                return Ok(await _repoComment.GetComment(pageSize, pageNum));
            }
            catch (ArgumentOutOfRangeException e)
            {
                return BadRequest(e.Message);
            }
        }
        /// <summary>
        /// Get the specified Catalog Comment from its identifier
        /// </summary>
        /// <param name="id">Identifier of the catalog comment to be retreived</param>
        /// <returns>Catalog Comment found</returns>
        /// <response code="200">Catalog Comment with the given ID found</response>
        /// <response code="404">No catalog comment with the given ID found</response>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpGet("comment/{id:int}")]
        public async Task<ActionResult<Comment>> GetCommentById(int id)
        {
            var res = await _repoComment.GetCommentById(id);
            if (res == null)
            {
                return NotFound();
            }
            else
            {
                return res;
            }
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
