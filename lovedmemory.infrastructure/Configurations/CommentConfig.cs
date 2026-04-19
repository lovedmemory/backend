// lovedmemory.infrastructure.Persistence.Configurations.CommentConfiguration.cs
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using lovedmemory.domain.Entities;

namespace lovedmemory.infrastructure.Configurations;

public class CommentConfiguration : IEntityTypeConfiguration<Comment>
{
    public void Configure(EntityTypeBuilder<Comment> builder)
    {
        builder.HasKey(c => c.Id);

        builder.Property(c => c.Name)
            .IsRequired()
            .HasMaxLength(200);

        builder.Property(c => c.Details)
            .IsRequired()
            .HasMaxLength(5000);

        builder.Property(c => c.Status)
            .HasDefaultValue(CommentStatus.Pending);

        builder.Property(c => c.Edited)
            .HasDefaultValue(false);

        // Self-referencing relationship
        builder.HasOne(c => c.ParentComment)
            .WithMany(c => c.Replies)
            .HasForeignKey(c => c.ParentCommentId)
            .OnDelete(DeleteBehavior.Restrict); 

        // Memorial relationship
        builder.HasOne(c => c.Memorial)
            .WithMany(m => m.Comments)
            .HasForeignKey(c => c.MemorialId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasIndex(c => c.MemorialId);
        builder.HasIndex(c => c.ParentCommentId);
        builder.HasIndex(c => c.Status);
    }
}