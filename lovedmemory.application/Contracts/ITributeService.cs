using lovedmemory.application.DTOs;
using lovedmemory.Domain.Entities;

namespace lovedmemory.Application.Contracts
{
    public interface ITributeService
    {
        Task<IEnumerable<Tribute>?> GetTributes();
        Task<IEnumerable<Tribute>?> GetMyTributes(int userId);
        Task<Tribute?> GetTribute(int id);
        Task<Tribute?> PutTribute(int id, Tribute Tribute, CancellationToken cancellationToken);
        Task<bool> PostTribute(TributeDto Tribute, CancellationToken cancellationToken);
        Task<bool> DeleteTribute(int id, CancellationToken cancellationToken);
    }
}
