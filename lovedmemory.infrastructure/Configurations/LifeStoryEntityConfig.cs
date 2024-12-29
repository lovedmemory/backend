using lovedmemory.domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace lovedmemory.infrastructure.Configurations;
class LifeStoryEntityConfig
    : IEntityTypeConfiguration<LifeStory>
{
    public void Configure(EntityTypeBuilder<LifeStory> lifeStoryConfiguration)
    {
        lifeStoryConfiguration.ToTable("lifestory", "tributes");
        lifeStoryConfiguration.HasKey(l => l.TributeId);
        lifeStoryConfiguration.Property(l => l.StorySection)
            .HasMaxLength(100);
        lifeStoryConfiguration.HasOne(l => l.Tribute)
            .WithOne(t=>t.LifeStory)
            .HasForeignKey<LifeStory>(l => l.TributeId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}