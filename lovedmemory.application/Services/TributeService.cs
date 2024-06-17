using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using lovedmemory.application.Common.Interfaces;
using lovedmemory.application.Contracts;
using lovedmemory.domain.Entities;
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


        public async Task<TributeDto?> GetTribute(int id, string userId)
        {
            var tribute = await _context.Tributes
              .Where(t => t.CreatedByUserId == userId && t.Id == id)
                            .Include(t => t.CreatedByUser)

              .Include(t => t.Comments)
              .ThenInclude(c => c.Replies)
              .Select(t => new TributeDto
              {
                  Id = t.Id,
                  Name = t.Name,
                  RunDate = t.RunDate,
                  Created = t.Created,
                  Active = t.Active,
                  MainImageUrl = t.MainImageUrl,
                  ViewCount = t.ViewCount,
                  AuthorName = t.CreatedByUser.FullName,
                  AuthorEmail = t.CreatedByUser.Email,
                  Comments = t.Comments.Select(c => new Comment
                  {
                      Id = c.Id,
                      Details = c.Details,
                      Created = c.Created,
                      CreatedByUserId = c.CreatedByUserId,
                      Replies = GetAllReplies(c.Replies).ToList()
                  }).ToList()
              }).FirstOrDefaultAsync();
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

        public async Task<IEnumerable<TributeDto>?> GetMyTributes(string userId)
        {
            return await _context.Tributes
              .Where(t => t.CreatedByUserId == userId)
              .Include(t => t.Comments)
              .ThenInclude(c => c.Replies)
              .Select(t => new TributeDto
              {
                  Id = t.Id,
                  Name = t.Name,
                  RunDate = t.RunDate,
                  Created = t.Created,
                  Active = t.Active,
                  MainImageUrl = t.MainImageUrl,
                  ViewCount = t.ViewCount,
                  AuthorName = t.CreatedByUser.FullName,
                  AuthorEmail = t.CreatedByUser.Email,
                  Comments = t.Comments.Select(c => new Comment
                  {
                      Id = c.Id,
                      Details = c.Details,
                      Created = c.Created,
                      CreatedByUserId = c.CreatedByUserId,
                      Replies = GetAllReplies(c.Replies).ToList()
                  }).ToList()
              })
              .ToListAsync();


        }
        // Helper function to retrieve all replies recursively
        private static IEnumerable<Comment> GetAllReplies(IEnumerable<Comment> replies)
        {
            foreach (var reply in replies)
            {
                yield return new Comment
                {
                    Id = reply.Id,
                    Details = reply.Details,
                    Created = reply.Created,
                    CreatedByUserId = reply.CreatedByUserId,
                    Replies = GetAllReplies(reply.Replies).ToList()
                };
            }
        }
        public async Task<IEnumerable<TributeDto>?> GetTributes()
        {
            return await _context.Tributes
         .Where(t => t.Active == true)
         .Include(t => t.CreatedByUser)
         .Include(t => t.Comments)
         .ThenInclude(c => c.Replies)
         .Select(t => new TributeDto
         {
             Id = t.Id,
             Name = t.Name,
             RunDate = t.RunDate,
             Created = t.Created,
             Active = t.Active,
             MainImageUrl = t.MainImageUrl,
             ViewCount = t.ViewCount,
             AuthorName = t.CreatedByUser.FullName,
             AuthorEmail = t.CreatedByUser.Email,
             Comments = t.Comments.Select(c => new Comment
             {
                 Id = c.Id,
                 Details = c.Details,
                 Created = c.Created,
                 CreatedByUserId = c.CreatedByUserId,
                 Replies = GetAllReplies(c.Replies).ToList()
             }).ToList()
         })
         .ToListAsync();
        }

        public async Task<bool> PostTribute(CreateTributeDto tribute, CancellationToken cancellationToken)
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
                var existingTribute = await _context.Tributes.FindAsync([id], cancellationToken);

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
