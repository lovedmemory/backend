using lovedmemory.application.Common.Security.Request;
using lovedmemory.application.DTOs;
using lovedmemory.application.Contracts;
using lovedmemory.domain.Entities;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace lovedmemory.web.Controllers
{
    //[Authorize(Permissions = "CanViewTributes", Roles = "Manager, Admin")]
   // [Authorize(Roles = "Manager, Admin")]
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class TributesController : ControllerBase
    {
        private readonly ITributeService _tributeService;
        private readonly CancellationToken cancellationToken;
        public TributesController(ITributeService tributeService)
        {
            _tributeService  = tributeService;
        }
        // GET: api/<TributesController>
        [HttpGet]
        public async Task<IEnumerable<TributeDto>> Get()
        {
            return await _tributeService.GetTributes();
        }
        // GET: api/<TributesController>
        [HttpGet("mytributes/{userId}")]
        public async Task<IEnumerable<TributeDto>> GetMyTributes(string userId)
        {
            return await _tributeService.GetMyTributes(userId);
        }
        // GET api/<TributesController>/5
        [HttpGet("{id}")]
        public async Task<Tribute> Get(int id)
        {
            return await _tributeService.GetTribute(id);
        }

        // POST api/<TributesController>
        [HttpPost]
        public async Task<IActionResult> Post(CreateTributeDto tribute)
        {
            bool created =  await _tributeService.PostTribute(tribute, cancellationToken);
            if (created)
            {
                return Created();
            }
            else
            {
                return BadRequest();
            }
        }

        // PUT api/<TributesController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<TributesController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
