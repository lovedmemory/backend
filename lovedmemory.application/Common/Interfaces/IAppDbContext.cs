using Microsoft.EntityFrameworkCore;
using lovedmemory.Domain.Entities;

namespace lovedmemory.application.Common.Interfaces
{
    public interface IAppDbContext
    {
        DbSet<Tribute> Tributes { get; set; }
        DbSet<Comment> Comments { get; set; }
        DbSet<EventDetail> EventDetails { get; set; }
        Task<int> SaveChangesAsync(CancellationToken cancellationToken);   
    }
}
