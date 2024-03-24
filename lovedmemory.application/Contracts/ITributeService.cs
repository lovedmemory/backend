using lovedmemory.Domain.Entities;

namespace lovedmemory.Application.Contracts
{
    public interface ITributeService
    {
        Task<IEnumerable<Tribute>?> GetTributes();
        Task<Tribute?> GetTribute(int id);
        Task<Tribute?> PutTribute(int id, Tribute Tribute, CancellationToken cancellationToken);
        Task<bool?> PostTribute(Tribute Tribute, CancellationToken cancellationToken);
        Task<bool> DeleteTribute(int id, CancellationToken cancellationToken);
    }
}
