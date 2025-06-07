using Microsoft.EntityFrameworkCore;
using lovedmemory.domain.Entities;

namespace lovedmemory.application.Common.Interfaces
{
    public interface IAppDbContext
    {
        DbSet<Memorial> Memorials { get; set; }
        DbSet<ExtraDetails> ExtraDetails { get; set; }
        DbSet<Comment> Comments { get; set; }
        DbSet<EventDetail> EventDetails { get; set; }
        DbSet<Contact> ContactMessages { get; set; }
        DbSet<Tribute> Tributes { get; set; }        
        Task<int> SaveChangesAsync(CancellationToken cancellationToken);   
    }
}
