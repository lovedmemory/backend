using lovedmemory.domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace lovedmemory.infrastructure.Configurations;
class LifeStoryEntityConfig
    : IEntityTypeConfiguration<LifeStory>
{
    public void Configure(EntityTypeBuilder<LifeStory> lifeStoryConfiguration)
    {
        lifeStoryConfiguration.ToTable("life_story", "lovedmemory");
        lifeStoryConfiguration.HasKey(l => l.MemorialId);
        lifeStoryConfiguration.Property(l => l.StorySection)
            .HasMaxLength(100);
        lifeStoryConfiguration.HasOne(l => l.Memorial)
            .WithOne(t=>t.LifeStory)
            .HasForeignKey<LifeStory>(l => l.MemorialId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}