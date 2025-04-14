using lovedmemory.application.Contracts;
using lovedmemory.application.DTOs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Net;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace lovedmemory.web.Controllers
{
#if DEBUG == false
    [Authorize]
#endif
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

        // POST api/<CommentsController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CommentDto comment)
        {
            bool success = await _commentService.PostComment(comment, cancellationToken);
            return success ? Ok(comment) : new StatusCodeResult(500);
        }

        // PUT api/<CommentsController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] CommentDto comment)
        {
            var res = await _commentService.PutComment(id, comment, cancellationToken);
            return res!=null ? Ok(comment) : new StatusCodeResult(500);
        }

        // DELETE api/<CommentsController>/5
        [HttpDelete("{id}")]
        public async Task<HttpStatusCode> Delete(int id)
        {
            var deleted = await _commentService.DeleteComment(id, cancellationToken);
            return deleted?  HttpStatusCode.NoContent : HttpStatusCode.InternalServerError;

        }
    }
}
