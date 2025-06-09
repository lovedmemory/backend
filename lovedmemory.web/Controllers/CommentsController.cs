using lovedmemory.application.Contracts;
using lovedmemory.application.DTOs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Net;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace lovedmemory.web.Controllers
{

    [Route("api/comments")]
    [ApiController]
    public class CommentsController : ControllerBase
    {
        private readonly ICommentService _commentService;

        private readonly CancellationToken cancellationToken;
        public CommentsController(ICommentService commentService)
        {
            _commentService = commentService;
        }

        /// <summary>
        /// Add comment to memorial
        /// </summary>
        /// <param name="comment"></param>
        /// <returns></returns>
        // POST api/<CommentsController>
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpPost] 
        public async Task<IActionResult> Post(CommentDto comment)
        {
            bool success = await _commentService.PostComment(comment, cancellationToken);
            return success ? Ok(comment) : new StatusCodeResult(500);
        }

        /// <summary>
        /// Update Comment
        /// </summary>
        /// <param name="id"></param>
        /// <param name="comment"></param>
        /// <returns></returns>
        // PUT api/<CommentsController>/5
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] CommentDto comment)
        {
            var res = await _commentService.PutComment(id, comment, cancellationToken);
            return res!=null ? Ok(comment) : new StatusCodeResult(500);
        }

        /// <summary>
        /// Delete Comment
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        // DELETE api/<CommentsController>/5
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpDelete("{id}")]
        public async Task<HttpStatusCode> Delete(int id)
        {
            var deleted = await _commentService.DeleteComment(id, cancellationToken);
            return deleted?  HttpStatusCode.NoContent : HttpStatusCode.InternalServerError;
        }
    }
}
