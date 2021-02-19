﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Catalog.API.Controllers.Models;
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
        private readonly IActivityRepository _repoActivity;

        public CatalogController(
            ITripRepository repoTrip, ILogger<CatalogController> logger, IActivityRepository repoActivity)
        {
            _logger = logger;
            _repoTrip = repoTrip;
            _repoActivity = repoActivity;

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
        /// Search trip by name
        /// </summary>
        /// <param name="search">name trip search</param>
        /// <returns>Catalog trip by search found</returns>
        /// <response code="200">Catalog Trip with the given search found</response>
        /// <response code="404">No catalog trip with the given search found</response>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpGet("trip/{​​search:regex(^[[a-zA-Z]])}")]
        public async Task<ActionResult<IEnumerable<Trip>>> GetTripByName(string search, [FromQuery] int pageNum = 0, [FromQuery] int pageSize = 10)
        {
            try
            {
                return Ok(await _repoTrip.GetTripByName(search, pageSize, pageNum));
            }
            catch (ArgumentOutOfRangeException e)
            {
                return BadRequest(e.Message);
            }
        }
        // POST api/<controller>
        //[HttpPost]
        //public ActionResult<Trip> Post([FromBody] Trip newTrip)
        //{
        //    if (newTrip == null)
        //    {
        //        return BadRequest("No trip provided");
        //    }
        //    if (newTrip.IdTrip.HasValue)
        //    {
        //        return BadRequest("trip must not have");
        //    }
        //    _repoTrip.SaveTrip(newTrip);
        //    var trip = new Uri($"{Request.Scheme}://{Request.Host}{Request.Path}/{newTrip.IdTrip}");
        //    return Created(trip, newTrip);
        //}
        [HttpPost]
        public async Task<ActionResult<Trip>> Post([FromBody] Trip newTrip)
        {


            try
            {
                return Ok(await _repoTrip.AddTrip(newTrip));
            }
            catch (ArgumentOutOfRangeException e)
            {
                return BadRequest(e.Message);
            }

            //var trip = await _repoTrip.GetTripById(id);


            //if (trip == null)
            //{
            //    return NotFound();
            //}
            //else
            //{
            //    return Ok(await _repoTrip.AddTrip(trip));
            //}
        }

        // PUT api/<controller>/5
        [HttpPut("{id}")]
        public ActionResult<Trip> Put(int id, [FromBody] Trip trip)
        {

            if (trip == null)
            {
                return BadRequest("No trip provided");
            }
            if (!trip.IdTrip.HasValue || id != trip.IdTrip.Value)
            {
                return BadRequest("Inconsistent trip id");
            }
            try
            {
                _repoTrip.UpdateTrip(trip);

                return Ok();
            }
            catch (ArgumentException)
            {
                return NotFound("Unknow trip");
            }




        }

        // DELETE api/<controller>/5
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            try
            {
                _repoTrip.RemoveTrip(id);
                return Ok();

            }
            catch (ArgumentException)
            {
                return NoContent();
            }


        }
    }

}
