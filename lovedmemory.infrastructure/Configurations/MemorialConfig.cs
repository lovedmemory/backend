using lovedmemory.domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace lovedmemory.infrastructure.Configurations;
class MemorialConfig
    : IEntityTypeConfiguration<Memorial>
{
    public void Configure(EntityTypeBuilder<Memorial> MemorialConfig)
    {
        MemorialConfig.ToTable("memorials", "lovedmemory");

        MemorialConfig.HasKey(t => t.Id);
        MemorialConfig.HasOne(t => t.LifeStory).WithOne(l => l.Memorial).HasForeignKey<LifeStory>(l => l.MemorialId).OnDelete(DeleteBehavior.Cascade);
        MemorialConfig.HasOne(t => t.ExtraDetails).WithOne().HasForeignKey<ExtraDetails>(e=>e.MemorialId).OnDelete(DeleteBehavior.Cascade);
        MemorialConfig.HasOne(t => t.CoverPhoto).WithOne(e => e.Memorial).HasForeignKey<CoverPhoto>(e => e.MemorialId).OnDelete(DeleteBehavior.Cascade);

    }
}