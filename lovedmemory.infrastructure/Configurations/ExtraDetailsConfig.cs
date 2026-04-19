using lovedmemory.domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace lovedmemory.infrastructure.Configurations;
class ExtraDetailsConfig
    : IEntityTypeConfiguration<ExtraDetails>
{
    public void Configure(EntityTypeBuilder<ExtraDetails> extraDetailsConfiguration)
    {
        extraDetailsConfiguration.ToTable("extra_details", "lovedmemory");

        extraDetailsConfiguration.HasKey(e=>e.MemorialId);
        extraDetailsConfiguration.Property(e => e.Relationship).HasConversion<string>().HasMaxLength(20);
        extraDetailsConfiguration.Property(e => e.Species).HasMaxLength(50);
        extraDetailsConfiguration.Property(e => e.Breed).HasMaxLength(50);
        extraDetailsConfiguration.Property(e => e.Color).HasMaxLength(50);
        extraDetailsConfiguration.Property(e => e.MicrochipNumber).HasMaxLength(50);


    }
}