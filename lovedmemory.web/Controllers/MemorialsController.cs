using Microsoft.AspNetCore.Authorization;
using lovedmemory.application.DTOs;
using lovedmemory.application.Contracts;
using lovedmemory.domain.Entities;
using Microsoft.AspNetCore.Mvc;
using lovedmemory.application.Services;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace lovedmemory.web.Controllers
{
    //[Authorize(Permissions = "CanViewMemorials", Roles = "Manager, Admin")]
   // [Authorize(Roles = "Manager, Admin")]
    [Authorize]
    [Route("api/memorials")]
    [ApiController]
    public class MemorialsController : ControllerBase
    {
        private readonly IMemorialService _memorialservice;
        private readonly CancellationToken cancellationToken;
        public MemorialsController(IMemorialService memorialservice)
        {
            _memorialservice  = memorialservice;
        }
        // GET: api/<MemorialsController>
        [AllowAnonymous]
        [HttpGet]
        public async Task<IEnumerable<MemorialDto>> Get()
        {
            return await _memorialservice.GetMemorials();
        }
        // GET: api/<MemorialsController>
        [HttpGet("myMemorials/{userId}")]
        public async Task<IEnumerable<MemorialDto>> GetMyMemorials(string userId)
        {
            return await _memorialservice.GetMyMemorials(userId);
        }
        // GET api/<MemorialsController>/5
        [HttpGet("{id}")]
        public async Task<Memorial> Get(int id)
        {
            return await _memorialservice.GetMemorial(id);
        }

        // POST api/<MemorialsController>
        [HttpPost]
        public async Task<IActionResult> Post(CreateMemorialDto Memorial)
        {
            var res =  await _memorialservice.PostMemorial(Memorial, cancellationToken);
            if (res.IsSuccess)
            {
                return Created();
            }
            else
            {
                return StatusCode(500, res.Error);
            }
        }

        // POST api/<MemorialsController/moreinfo>
        [HttpPost("moreinfo/{Id}")]
        public async Task<IActionResult> MoreInfo(int id, AddMemorialInfoDto Memorial)
        {
            var res = await _memorialservice.AddmoreInfoToMemorial(id, Memorial, cancellationToken);
            if (res.IsSuccess)
            {
                return Created();
            }
            else
            {
                return StatusCode(500, res.Error);
            }
        }
        // PUT api/<MemorialsController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<MemorialsController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
