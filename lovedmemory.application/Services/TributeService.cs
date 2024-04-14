using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using lovedmemory.application.Common.Interfaces;
using lovedmemory.application.Contracts;
using lovedmemory.Domain.Entities;
using lovedmemory.application.DTOs;

namespace lovedmemory.application.Services
{
    public class TributeService : ITributeService
    {
        private readonly IAppDbContext _context;
        private readonly ILogger<TributeService> _logger;
        private readonly IDateTime _dateTime;
        public TributeService(IAppDbContext context, ILogger<TributeService> logger, IDateTime dateTime)
        {
            _context = context;
            _logger = logger;
            _dateTime = dateTime;
        }


        public async Task<Tribute?> GetTribute(int id, int userId)
        {
            var tribute = await _context.Tributes
            .Include(t => t.Comments)
            .ThenInclude(c => c.Replies)
            .SingleOrDefaultAsync(t => t.Id == id);
            return tribute;
        }
        public async Task<Tribute?> GetTribute(int id)
        {
            var tribute = await _context.Tributes
    .Include(t => t.Comments)
    .ThenInclude(c => c.Replies)
    .SingleOrDefaultAsync(t => t.Id == id);
            return tribute;
        }

        public async Task<IEnumerable<Tribute>?> GetMyTributes(string userId)
        {
            return await _context.Tributes
                .Where(t => t.OwnerId == userId)
                .Include(t => t.Comments)
                .ThenInclude(c => c.Replies)
                .ToListAsync();
        }
        public async Task<IEnumerable<Tribute>?> GetTributes()
        {
            var tributes = await _context.Tributes
           .Include(t => t.Comments)
           .ThenInclude(c => c.Replies)
           .ToListAsync();
            return tributes;
        }

        public async Task<bool> PostTribute(TributeDto tribute, CancellationToken cancellationToken)
        {
            if (_context.Tributes == null)
            {
                return false;
            }
            Tribute _tribute = new()
            {
                Active = true,
                Created = _dateTime.Now,
                RunDate = _dateTime.Now,
                Name = tribute.Name,
                NickName = tribute.NickName,
                Slug = tribute.Slug,
                MainImageUrl = tribute.MainImageUrl,

            };
            _context.Tributes.Add(_tribute);
            await _context.SaveChangesAsync(cancellationToken);

            return true;
        }

        public async Task<Tribute?> PutTribute(int id, Tribute Tribute, CancellationToken cancellationToken)
        {
            if (Tribute == null || id != Tribute.Id)
            {
                return null;
            }

            try
            {
                var existingTribute = await _context.Tributes.FindAsync(new object[] { id }, cancellationToken);

                if (existingTribute == null)
                {
                    return null; // Tribute with the given ID not found.
                }

                _context.Tributes.Entry(existingTribute).CurrentValues.SetValues(Tribute);

                await _context.SaveChangesAsync(cancellationToken);

                return existingTribute;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error updating Tribute");
                return null;
            }
        }

        public async Task<bool> DeleteTribute(int id, CancellationToken cancellationToken)
        {
            if (_context.Tributes == null)
            {
                return false;
            }
            var Tribute = await _context.Tributes.FindAsync(id, cancellationToken);
            if (Tribute == null)
            {
                return true;
            }

            _context.Tributes.Remove(Tribute);
            await _context.SaveChangesAsync(cancellationToken);

            return true;
        }

  
    }
}
