using lovedmemory.application.DTOs;
using lovedmemory.domain.Entities;

namespace lovedmemory.application.Contracts
{
    public interface ICommentService
    {
        Task<bool> DeleteComment(int id, CancellationToken cancellationToken);
        Task<bool> PostComment(CommentDto Comment, CancellationToken cancellationToken);
        Task<Comment?> PutComment(int id, CommentDto Comment, CancellationToken cancellationToken);
    }
}
