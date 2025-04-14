using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using lovedmemory.application.Common.Interfaces;
using lovedmemory.application.Contracts;
using lovedmemory.domain.Entities;
using lovedmemory.application.DTOs;
using lovedmemory.application.Utils;
using lovedmemory.domain;
using lovedmemory.application.Common.Models;

namespace lovedmemory.application.Services
{
    public class MemorialService : IMemorialService
    {
        private readonly IAppDbContext _context;
        private readonly ILogger<MemorialService> _logger;
        private readonly IUserProvider _userProvider;
        public MemorialService(IAppDbContext context, ILogger<MemorialService> logger, IUserProvider userProvider)
        {
            _context = context;
            _logger = logger;
            _userProvider = userProvider;
        }

        public async Task<MemorialDto?> GetMemorialByUserId(int id, string userId)
        {
            var Memorial = await _context.Memorials
              .Where(t => t.CreatedByUserId == userId && t.Id == id)
                            .Include(t => t.CreatedByUser)

              .Include(t => t.Comments)
              .ThenInclude(c => c.Replies)
              .Select(t => new MemorialDto
              {
                  Id = t.Id,
                  Name = t.FullName(),
                  Title = t.Title,
                  RunDate = t.RunDate,
                  Created = t.Created,
                  Active = t.Active,
                  CommemorationDate = t.ExtraDetails.CommemorationDate,
                  Slug = t.Slug,
                  Dob = (DateOnly)t.ExtraDetails.DateOfBirth,
                  Dod = (DateOnly)t.ExtraDetails.DateOfDeath,
                  ImageUrl = t.MainImageUrl,
                  PersonalPhrase = t.PersonalPhrase,
                  Description = t.Description,
                  ViewCount = t.ViewCount,
                  AuthorName = t.CreatedByUser.FullName,
                  AuthorEmail = t.CreatedByUser.Email!,
                  Comments = t.Comments.Select(c => new Comment
                  {
                      Id = c.Id,
                      Details = c.Details,
                      Created = c.Created,
                      CreatedByUserId = c.CreatedByUserId,
                      Replies = GetAllReplies(c.Replies).ToList()
                  }).ToList()
              }).FirstOrDefaultAsync();
            return Memorial;
        }
        public async Task<MemorialDto?> GetMemorial(int id, CancellationToken token)
        {
            var memorial = await _context.Memorials
                         .Where(t=> t.Id == id)
                         .Include(t => t.CreatedByUser)
                         .Include(t => t.Comments)
                         .ThenInclude(c => c.Replies)
                         .Select(t => new MemorialDto
                         {
                             Id = t.Id,
                             Name = t.FullName(),
                             Description = t.Description,
                             Title = t.Title,
                             RunDate = t.RunDate,
                             Created = t.Created,
                             Active = t.Active,
                             Dob = (DateOnly)t.ExtraDetails.DateOfBirth,
                             Dod = (DateOnly)t.ExtraDetails.DateOfDeath,
                             ImageUrl = t.MainImageUrl,
                             CommemorationDate = t.ExtraDetails.CommemorationDate,
                             Slug = t.Slug,
                             PersonalPhrase = t.PersonalPhrase,
                             Biography = t.Biography,
                             FirstName = t.FirstName,
                             LastName = t.LastName,
                             NickName = t.ExtraDetails.NickName,
                             ViewCount = t.ViewCount,
                             AuthorName = t.CreatedByUser.FullName,
                             AuthorEmail = t.CreatedByUser.Email!,
                             Published = t.Published,
                             Comments = t.Comments.Select(c => new Comment
                             {
                                 Id = c.Id,
                                 Details = c.Details,
                                 Created = c.Created,
                                 CreatedByUserId = c.CreatedByUserId,
                                 Replies = GetAllReplies(c.Replies).ToList()
                             }).ToList()
                         }).FirstOrDefaultAsync();

            if (memorial != null)
            {
                ++memorial.ViewCount;
                await _context.SaveChangesAsync(token);
            }

            return memorial;
        }
        public async Task<Result<Memorial>> GetEditMemorial(int id, CancellationToken token)
        {
            try
            {
                var memorial = await _context.Memorials
                             .Where(t => t.Id == id)
                             .Include(t => t.CreatedByUser)
                             .Include(t => t.Comments)
                             .ThenInclude(c => c.Replies)
                             .FirstOrDefaultAsync(cancellationToken: token);

                return Result<Memorial>.Success(memorial);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error getting Memorial For Edit form");
                return Result<Memorial>.Failure("An error occured");
            }
        }

        public async Task<IEnumerable<MemorialDto>?> GetMyMemorials(string userId)
        {
            return await _context.Memorials
              .Where(t => t.CreatedByUserId == userId)
              .Include(t => t.Comments)
              .ThenInclude(c => c.Replies)
              .Select(t => new MemorialDto
              {
                  Id = t.Id,
                  Name = t.FullName(),
                  RunDate = t.RunDate,
                  Description = t.Description,
                  FirstName = t.FirstName,
                  LastName = t.LastName,
                  Created = t.Created,
                  Published = t.Published,  
                  CommemorationDate = t.ExtraDetails.CommemorationDate,
                  Slug = t.Slug,
                  Active = t.Active,
                  ImageUrl = t.MainImageUrl,
                  ViewCount = t.ViewCount,
                  AuthorName = t.CreatedByUser.FullName,
                  AuthorEmail = t.CreatedByUser.Email,
                  Dob = (DateOnly)t.ExtraDetails.DateOfBirth,
                  Dod = (DateOnly)t.ExtraDetails.DateOfDeath,
                  PersonalPhrase = t.PersonalPhrase,
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
                    Replies = [.. GetAllReplies(reply.Replies)]
                };
            }
        }
        public async Task<IEnumerable<MemorialDto>?> GetMemorials()
        {
            IEnumerable<MemorialDto> Memorials = [];
            try
            {
                Memorials = await _context.Memorials
                .Where(t => t.Active == true)
                .Include(t => t.CreatedByUser)
                .Include(t => t.Comments)
                .ThenInclude(c => c.Replies)
                .Select(t => new MemorialDto
                {
                    Id = t.Id,
                    Name = t.FullName(),
                    RunDate = t.RunDate,
                    Created = t.Created,
                    Active = t.Active,
                    Title = t.Title,
                    Description = t.Biography,
                    Dob = (DateOnly)t.ExtraDetails.DateOfBirth,
                    Dod = (DateOnly)t.ExtraDetails.DateOfDeath,
                    Slug = t.Slug,
                    ImageUrl = t.MainImageUrl,
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
                return Memorials;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error getting Memorials");
                return Memorials;
            }
        }

        public async Task<Result<bool>> PostMemorial(CreateMemorialDto Memorial, CancellationToken cancellationToken)
        {
            if (_context.Memorials == null)
            {
                return Result<bool>.Failure("Memorials not found");
            }
            try
            {
                var createdByUserId = _userProvider.GetCurrentUser().Id;

                string _slug = SlugGenerator.GenerateSlug(Memorial.FirstName + " " + Memorial.LastName);

                Memorial _Memorial = new()
                {
                    Active = true,
                    Created = DateTimeOffset.UtcNow,
                    RunDate =  DateTimeOffset.UtcNow,
                    FirstName = Memorial.FirstName,
                    LastName = Memorial.LastName,
                    PersonalPhrase = Memorial.PersonalPhrase,
                    Published = Memorial?.Published ?? false,
                    Title = "Memorial for " + Memorial.FirstName + " " + Memorial.LastName,
                    Slug = _slug,   
                    Gender = (char)Memorial.Gender,
                    Biography = Memorial.Biography,
                    Description = Memorial.Description,
                    IsPrivate = Memorial.Privacy,
                    Template = "default",
                    MainImageUrl = Memorial.ImageUrl,
                    ViewCount=0,
                    CreatedByUserId = createdByUserId
                };
                _context.Memorials.Add(_Memorial);
                await _context.SaveChangesAsync(cancellationToken);
                ExtraDetails _extraDetails = new()
                {
                    MemorialId = _Memorial.Id,
                    DateOfBirth = string.IsNullOrEmpty(Memorial.Dob) ? null : DateOnly.FromDateTime(DateTime.Parse(Memorial.Dob)),
                    DateOfDeath = string.IsNullOrEmpty(Memorial.Dod) ? null : DateOnly.FromDateTime(DateTime.Parse(Memorial.Dod)),
                };
                _context.ExtraDetails.Add(_extraDetails);
                await _context.SaveChangesAsync(cancellationToken);

                return Result<bool>.Success(true);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error saving Memorial");
                return Result<bool>.Failure("An error occured while saving Memorial");
            }
        }
        public async Task<Result<Memorial>> AddmoreInfoToMemorial(int id, AddMemorialInfoDto _Memorial, CancellationToken cancellationToken)
        {
            if (_Memorial == null || id != _Memorial.Id)
            {
                return Result<Memorial>.Failure("Memorial not found");
            }
            try
            {
                var existingMemorial = await _context.Memorials.FindAsync([id], cancellationToken);

                if (existingMemorial == null)
                {
                    return Result<Memorial>.Failure("Memorial not found");
                }

                _context.Memorials.Entry(existingMemorial).CurrentValues.SetValues(_Memorial);

                await _context.SaveChangesAsync(cancellationToken);

                return Result<Memorial>.Success(existingMemorial);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error updating Memorial");
                return Result<Memorial>.Failure("An error occured while updating Memorial");
            }
        }

        public async Task<Memorial?> PutMemorial(int id, Memorial _Memorial, CancellationToken cancellationToken)
        {
            if (_Memorial == null || id != _Memorial.Id)
            {
                return null;
            }
            string _slug = SlugGenerator.GenerateSlug(_Memorial.FullName());
            _Memorial.Slug = _slug;
            try
            {
                var existingMemorial = await _context.Memorials.FindAsync([id], cancellationToken);

                if (existingMemorial == null)
                {
                    return null; // Memorial with the given ID not found.
                }

                _context.Memorials.Entry(existingMemorial).CurrentValues.SetValues(_Memorial);

                await _context.SaveChangesAsync(cancellationToken);

                return existingMemorial;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error updating Memorial");
                return null;
            }
        }

        public async Task<bool> DeleteMemorial(int id, CancellationToken cancellationToken)
        {
            if (_context.Memorials == null)
            {
                return false;
            }
            var Memorial = await _context.Memorials.FindAsync(id, cancellationToken);
            if (Memorial == null)
            {
                return true;
            }

            _context.Memorials.Remove(Memorial);
            await _context.SaveChangesAsync(cancellationToken);

            return true;
        }

    }
}
