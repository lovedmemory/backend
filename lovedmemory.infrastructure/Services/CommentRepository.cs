using lovedmemory.domain.Entities;
using lovedmemory.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace lovedmemory.infrastructure.Services
{
    class CommentRepository
    {
        private readonly AppDbContext _dbContext;
        public CommentRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        // Get top-level comments for a memorial (no parent)
        public IQueryable<Comment> GetTopLevelComments(int memorialId)
        {
            return _dbContext.Comments
                .Where(c => c.MemorialId == memorialId && c.ParentCommentId == null && c.Status==CommentStatus.Approved)
                .OrderByDescending(c => c.Created)
                .AsQueryable();
        }

        // Get a comment with its immediate replies
        public IQueryable<Comment> GetCommentWithReplies(int commentId)
        {
            return _dbContext.Comments
                .Include(c => c.Replies.Where(r => r.Status == CommentStatus.Approved).OrderByDescending(r => r.Created));
                //.FirstOrDefaultAsync(c => c.Id == commentId && c.Visible);
        }

        // Get an entire comment thread (a comment with all nested replies)
        public IQueryable<Comment> GetCommentThread(int commentId)
        {
            // Using a more reliable approach with multiple includes
            return  _dbContext.Comments
                .Include(c => c.Replies
                    .Where(r => r.Status == CommentStatus.Approved))
                    .ThenInclude(r => r.Replies
                        .Where(r2 => r2.Status == CommentStatus.Approved))
                        .ThenInclude(r2 => r2.Replies
                            .Where(r3 => r3.Status == CommentStatus.Approved))
                            .ThenInclude(r3 => r3.Replies
                                .Where(r4 => r4.Status == CommentStatus.Approved));
                //.FirstOrDefaultAsync(c => c.Id == commentId && c.Visible);
        }

        // Add a reply to a comment
        public async Task<Comment> AddReplyAsync(int parentCommentId, Comment reply)
        {
            var parentComment = await _dbContext.Comments.FindAsync(parentCommentId);
            if (parentComment == null)
                throw new ArgumentException("Parent comment not found");

            // Set the parent ID and update the tree level
            reply.ParentCommentId = parentCommentId;
            reply.TreeLevel = parentComment.TreeLevel + 1;
            reply.MemorialId = parentComment.MemorialId;

            _dbContext.Comments.Add(reply);
            await _dbContext.SaveChangesAsync();

            return reply;
        }

        // Get all comments for a memorial with their hierarchy preserved
        public async Task<List<Comment>> GetAllCommentsHierarchicallyAsync(int memorialId)
        {
            // Get only top-level comments with nested replies up to a reasonable depth
            return await _dbContext.Comments
                .Where(c => c.MemorialId == memorialId && c.ParentCommentId == null && c.Status==CommentStatus.Approved)
                .Include(c => c.Replies
                    .Where(r => r.Status == CommentStatus.Approved))
                    .ThenInclude(r => r.Replies
                        .Where(r2 => r2.Status == CommentStatus.Approved))
                        .ThenInclude(r2 => r2.Replies
                            .Where(r3 => r3.Status == CommentStatus.Approved))
                            .ThenInclude(r3 => r3.Replies
                                .Where(r4 => r4.Status == CommentStatus.Approved))
                .OrderByDescending(c => c.Created)
                .ToListAsync();
        }

        // Alternative approach using explicit loading for truly recursive scenarios
        public async Task<Comment> GetCommentThreadWithExplicitLoadingAsync(int commentId)
        {
            var comment = await _dbContext.Comments
                .FirstOrDefaultAsync(c => c.Id == commentId && c.Status == CommentStatus.Approved);

            if (comment != null)
            {
                await LoadRepliesRecursivelyAsync(comment);
            }

            return comment;
        }

        // Helper method for explicit loading of replies
        private async Task LoadRepliesRecursivelyAsync(Comment comment, int maxDepth = 5)
        {
            if (maxDepth <= 0) return;

            // Explicitly load the replies for this comment
            await _dbContext.Entry(comment)
                .Collection(c => c.Replies)
                .Query()
                .Where(r => r.Status == CommentStatus.Approved)
                .OrderByDescending(r => r.Created)
                .LoadAsync();

            // Recursively load replies for each child comment
            foreach (var reply in comment.Replies)
            {
                await LoadRepliesRecursivelyAsync(reply, maxDepth - 1);
            }
        }
    }
}
