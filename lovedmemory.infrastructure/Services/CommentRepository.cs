// lovedmemory.infrastructure.Persistence.Repositories.CommentRepository.cs
using lovedmemory.domain.Entities;
using lovedmemory.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace lovedmemory.infrastructure.Persistence.Repositories;

public interface ICommentRepository
{
    Task<IEnumerable<Comment>> GetThreadByMemorialAsync(int memorialId, CancellationToken ct = default);
    Task<Comment?> GetWithRepliesAsync(int commentId, CancellationToken ct = default);
    Task<Comment> AddAsync(Comment comment, CancellationToken ct = default);
    Task UpdateAsync(Comment comment, CancellationToken ct = default);
    Task SoftDeleteAsync(int commentId, CancellationToken ct = default);
}

public class CommentRepository : ICommentRepository
{
    private readonly AppDbContext _context;

    public CommentRepository(AppDbContext context)
    {
        _context = context;
    }

    /// <summary>
    /// Fetches only ROOT comments for a memorial, with up to N levels of replies
    /// loaded eagerly. For deep trees, use recursive CTE instead (see below).
    /// </summary>
    public async Task<IEnumerable<Comment>> GetThreadByMemorialAsync(
        int memorialId, CancellationToken ct = default)
    {
        return await _context.Comments
            .Where(c => c.MemorialId == memorialId
                     && c.ParentCommentId == null          // root comments only
                     && c.Status == CommentStatus.Approved)
            .Include(c => c.Replies.Where(r => r.Status == CommentStatus.Approved))
                .ThenInclude(r => r.Replies.Where(r2 => r2.Status == CommentStatus.Approved))
                    .ThenInclude(r2 => r2.Replies.Where(r3 => r3.Status == CommentStatus.Approved))
            .OrderByDescending(c => c.Created)
            .AsNoTracking()
            .ToListAsync(ct);
    }
    public async Task<IEnumerable<Comment>> GetFullThreadViaCteAsync(
    int memorialId, CancellationToken ct = default)
    {
        return await _context.Comments
            .FromSqlRaw("""
            WITH RECURSIVE CommentTree AS (
                -- Anchor: root comments
                SELECT * FROM "Comments"
                WHERE "MemorialId" = {0}
                  AND "ParentCommentId" IS NULL
                  AND "Status" = 1  -- Approved

                UNION ALL

                -- Recursive: all replies
                SELECT c.* FROM "Comments" c
                INNER JOIN CommentTree ct ON c."ParentCommentId" = ct."Id"
                WHERE c."Status" = 1
            )
            SELECT * FROM CommentTree
            ORDER BY "TreeLevel", "CreatedAt"
        """, memorialId)
            .AsNoTracking()
            .ToListAsync(ct);
        // Then reconstruct the tree in-memory (see below)
    }
    public static IEnumerable<Comment> BuildTree(IEnumerable<Comment> flatList)
    {
        var lookup = flatList.ToDictionary(c => c.Id);
        var roots = new List<Comment>();

        foreach (var comment in flatList)
        {
            if (comment.ParentCommentId.HasValue
                && lookup.TryGetValue(comment.ParentCommentId.Value, out var parent))
            {
                parent.Replies.Add(comment);
            }
            else
            {
                roots.Add(comment);
            }
        }

        return roots;
    }

    /// <summary>
    /// Fetch a single comment with its full reply subtree.
    /// </summary>
    public async Task<Comment?> GetWithRepliesAsync(int commentId, CancellationToken ct = default)
    {
        return await _context.Comments
            .Where(c => c.Id == commentId)
            .Include(c => c.Replies.Where(r => r.Status != CommentStatus.Deleted))
                .ThenInclude(r => r.Replies.Where(r2 => r2.Status != CommentStatus.Deleted))
                    .ThenInclude(r2 => r2.Replies)
            .AsNoTracking()
            .FirstOrDefaultAsync(ct);
    }

    public async Task<Comment> AddAsync(Comment comment, CancellationToken ct = default)
    {
        // Auto-compute TreeLevel from parent
        if (comment.ParentCommentId.HasValue)
        {
            var parent = await _context.Comments
                .Select(c => new { c.Id, c.TreeLevel })
                .FirstOrDefaultAsync(c => c.Id == comment.ParentCommentId, ct);

            comment.TreeLevel = (parent?.TreeLevel ?? 0) + 1;
        }
        else
        {
            comment.TreeLevel = 0;
        }

        _context.Comments.Add(comment);
        await _context.SaveChangesAsync(ct);
        return comment;
    }

    public async Task UpdateAsync(Comment comment, CancellationToken ct = default)
    {
        comment.Edited = true;
        _context.Comments.Update(comment);
        await _context.SaveChangesAsync(ct);
    }

    /// <summary>
    /// Soft delete — marks the comment as Deleted without removing the row,
    /// so child replies remain structurally intact.
    /// </summary>
    public async Task SoftDeleteAsync(int commentId, CancellationToken ct = default)
    {
        var comment = await _context.Comments.FindAsync(commentId, ct);
        if (comment is null) return;

        comment.Status = CommentStatus.Deleted;
        comment.Details = "[comment removed]"; // scrub content
        await _context.SaveChangesAsync(ct);
    }
}