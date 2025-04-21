using Microsoft.Extensions.Logging;
using lovedmemory.application.Common.Interfaces;
using lovedmemory.domain.Entities;
using lovedmemory.application.DTOs;
using lovedmemory.application.Contracts;

namespace lovedmemory.application.Services
{
    public class CommentService : ICommentService
    {
        private readonly IAppDbContext _context;
        private readonly ILogger<CommentService> _logger;
        private readonly IUserProvider _userProvider;

        public CommentService(IAppDbContext context, ILogger<CommentService> logger, IUserProvider userProvider)
        {
            _context = context;
            _logger = logger;
            _userProvider = userProvider;
        }

        public async Task<bool> PostComment(CommentDto Comment, CancellationToken cancellationToken)
        {
            try
            {
                var createdByUserId = "";
                try
                {
                    createdByUserId = _userProvider.GetCurrentUser().Id;
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex, "error saving comment");
                }
                if (_context.Comments == null)
                {
                    return false;
                }
                Comment _Comment = new()
                {
                    Details = Comment.Details,
                    ParentCommentId = Comment.ParentCommentId,
                    MemorialId = Comment.MemorialId,
                    Status = 0,
                    Name = Comment.Name,
                    CreatedByUserId = Comment?.CreatedByUserId
                };
                _context.Comments.Add(_Comment);
                var res = await _context.SaveChangesAsync(cancellationToken);
                return res > 0;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "error saving comment");
                return false;
            }
        }

        public async Task<Comment?> PutComment(int id, CommentDto Comment, CancellationToken cancellationToken)
        {
            if (Comment == null || id != Comment.Id)
            {
                return null;
            }

            try
            {
                var existingComment = await _context.Comments.FindAsync(id, cancellationToken);

                if (existingComment == null)
                {
                    return null; // Comment with the given ID not found.
                }
                Comment updatedComment = new()
                {
                    Edited = true,
                    Details = Comment.Details,
                    ParentCommentId = Comment.ParentCommentId,
                    MemorialId = Comment.Id,
                    Status = existingComment.Status

                };
                _context.Comments.Entry(existingComment).CurrentValues.SetValues(Comment);

                await _context.SaveChangesAsync(cancellationToken);

                return existingComment;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error updating Comment");
                return null;
            }
        }

        public async Task<bool> DeleteComment(int id, CancellationToken cancellationToken)
        {
            try { 
            if (_context.Comments == null)
            {
                return false;
            }
            var Comment = await _context.Comments.FindAsync(id);
            if (Comment == null)
            {
                return true;
            }

            _context.Comments.Remove(Comment);
            int res = await _context.SaveChangesAsync(cancellationToken);

            return res>0;
        }
            catch (Exception ex)
            {
                _logger.LogError(ex, "error saving comment");
                return false;
            }
        }


    }
}
