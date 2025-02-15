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


    }
}