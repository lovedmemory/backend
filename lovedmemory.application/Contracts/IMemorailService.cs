using lovedmemory.application.Common.Models;
using lovedmemory.application.DTOs;
using lovedmemory.domain.Entities;

namespace lovedmemory.application.Contracts
{
    public interface IMemorialService
    {
        Task<Result<Memorial>> AddmoreInfoToMemorial(int id, AddMemorialInfoDto _Memorial, CancellationToken cancellationToken);
        Task<bool> DeleteMemorial(int id, CancellationToken cancellationToken);
        Task<MemorialDto?> GetMemorial(int id, CancellationToken token);
        Task<Result<Memorial>> GetEditMemorial(int id, CancellationToken token);
        Task<MemorialDto?> GetMemorialByUserId(int id, string userId);
        Task<IEnumerable<MemorialDto>?> GetMemorials();
        Task<IEnumerable<MemorialDto>?> GetMyMemorials(string userId);
        Task<Result<bool>> PostMemorial(CreateMemorialDto Memorial, CancellationToken cancellationToken);
        Task<Memorial?> PutMemorial(int id, Memorial _Memorial, CancellationToken cancellationToken);
    }
}
