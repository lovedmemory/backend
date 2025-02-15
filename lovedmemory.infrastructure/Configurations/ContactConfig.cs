using lovedmemory.domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace lovedmemory.infrastructure.Configurations;
class ContactConfig
    : IEntityTypeConfiguration<Contact>
{
    public void Configure(EntityTypeBuilder<Contact> ContactConfiguration)
    {
        ContactConfiguration.ToTable("contact_messages", "contacts");
        ContactConfiguration.HasKey(c => c.Id);
        ContactConfiguration.Property(c => c.FirstName)
           .HasMaxLength(100);
        ContactConfiguration.Property(c => c.LastName)
        .HasMaxLength(100);
        ContactConfiguration.Property(c => c.Email)
            .HasMaxLength(100);
        ContactConfiguration.Property(c => c.Phone)
            .HasMaxLength(12);

        ContactConfiguration.Property(c => c.CreatedAt)
    .HasDefaultValueSql("now()");
    }
}