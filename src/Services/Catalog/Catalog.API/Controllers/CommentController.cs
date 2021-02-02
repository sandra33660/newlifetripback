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
    public class CommentController : ControllerBase
    {
        private readonly ILogger<CommentController> _logger;

        private readonly ICommentRepository _repoComment;

        public CommentController(
            ICommentRepository repoComment,
            ILogger<CommentController> logger)
        {
            _logger = logger;

            _repoComment = repoComment;

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
    }
}