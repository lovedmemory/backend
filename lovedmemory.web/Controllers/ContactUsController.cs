using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using lovedmemory.Infrastructure.Data;
using lovedmemory.domain.Entities;
using lovedmemory.application.Contracts;
using lovedmemory.application.DTOs;

namespace lovedmemory.web.Controllers
{
    [Route("api/contactus")]
    [ApiController]
    public class ContactUsController : ControllerBase
    {
        private readonly AppDbContext _context;
        private readonly IContactMessageService _contactMessageService;

        public ContactUsController(AppDbContext context, IContactMessageService contactMessageService)
        {
            _context = context;
            _contactMessageService = contactMessageService;
        }

        // GET: api/ContactUs
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Contact>>> GetContactMessages()
        {
            var result = await _contactMessageService.GetContactMessages();
            if (result.IsSuccess)
            {
                return Ok(result.Value);
            }
            return BadRequest(result.Error);
        }

        // GET: api/ContactUs/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Contact>> GetContact(int id)
        {
            var contact = await _context.ContactMessages.FindAsync(id);

            if (contact == null)
            {
                return NotFound();
            }

            return contact;
        }

        // PUT: api/ContactUs/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutContact(int id, Contact contact)
        {
            if (id != contact.Id)
            {
                return BadRequest();
            }

            _context.Entry(contact).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ContactExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/ContactUs
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Contact>> PostContact(ContactUsDto contactdto)
        {
            CancellationToken cancellationToken = new CancellationToken();
            var res = await _contactMessageService.PostContactUs(contactdto, cancellationToken);
            if (res.IsSuccess)
            {
                return CreatedAtAction("GetContact", new { id = res.Value.Id }, res.Value);
            }
            return StatusCode(500, res.Error);

        }

        // DELETE: api/ContactUs/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteContact(int id)
        {
            var contact = await _context.ContactMessages.FindAsync(id);
            if (contact == null)
            {
                return NotFound();
            }

            _context.ContactMessages.Remove(contact);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ContactExists(int id)
        {
            return _context.ContactMessages.Any(e => e.Id == id);
        }
    }
}
