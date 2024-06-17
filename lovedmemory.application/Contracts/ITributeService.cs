using lovedmemory.application.DTOs;
using lovedmemory.domain.Entities;

namespace lovedmemory.application.Contracts
{
    public interface ITributeService
    {
        Task<bool> DeleteTribute(int id, CancellationToken cancellationToken);
        Task<IEnumerable<TributeDto>?> GetMyTributes(string userId);
        Task<Tribute?> GetTribute(int id);
        Task<TributeDto?> GetTribute(int id, string userId);
        Task<IEnumerable<TributeDto>?> GetTributes();
        Task<bool> PostTribute(CreateTributeDto tribute, CancellationToken cancellationToken);
        Task<Tribute?> PutTribute(int id, Tribute Tribute, CancellationToken cancellationToken);
    }
}
