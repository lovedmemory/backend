using lovedmemory.application.Common.Interfaces;
using lovedmemory.application.Common.Models;
using lovedmemory.application.Contracts;
using lovedmemory.application.DTOs;
using lovedmemory.domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace lovedmemory.application.Services
{
    public class ContactMessageservice : IContactMessageService
    {
        private readonly IAppDbContext _context;
        private readonly ILogger<ContactMessageservice> _logger;
        public ContactMessageservice(IAppDbContext context, ILogger<ContactMessageservice> logger)
        {
            _context = context;
            _logger = logger;
        }

        public async Task<Result<IEnumerable<Contact>>> GetContactMessages()
        {
            try
            {
                var messages=  await _context.ContactMessages.ToListAsync();
                return Result<IEnumerable<Contact>>.Success(messages);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "error fetching messages");
                return Result<IEnumerable<Contact>>.Failure("error fetching messages");
            }
        }
        public async Task<Result<Contact>> PostContactUs(ContactUsDto ContactUsDto, CancellationToken cancellationToken)
        {
            try
            {
                if (_context.ContactMessages == null)
                {
                    return Result<Contact>.Failure("ContactUs not found");
                }
                Contact _ContactUs = new()
                {
                    FirstName = ContactUsDto.FirstName,
                    LastName = ContactUsDto.LastName,
                    Email = ContactUsDto.Email,
                    Message = ContactUsDto.Message,
                    Phone = ContactUsDto.Phone

                };
                _context.ContactMessages.Add(_ContactUs);
                var res = await _context.SaveChangesAsync(cancellationToken);
                if( res > 0)
                {
                    return Result<Contact>.Success(_ContactUs);
                }
                else
                {
                    return Result<Contact>.Failure("error saving ContactUs");
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "error saving ContactUs");
                return Result<Contact>.Failure("error saving ContactUs");
            }
        }


        public async Task<bool> DeleteContactUs(int id, CancellationToken cancellationToken)
        {
            try
            {
                if (_context.ContactMessages == null)
                {
                    return false;
                }
                var ContactUs = await _context.ContactMessages.FindAsync(id);
                if (ContactUs == null)
                {
                    return true;
                }

                _context.ContactMessages.Remove(ContactUs);
                int res = await _context.SaveChangesAsync(cancellationToken);

                return res > 0;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "error saving ContactUs");
                return false;
            }
        }


    }
}
