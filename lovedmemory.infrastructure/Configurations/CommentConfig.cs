using lovedmemory.domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace lovedmemory.infrastructure.Configurations;
class CommentConfig
    : IEntityTypeConfiguration<Comment>
{
    public void Configure(EntityTypeBuilder<Comment> CommentConfiguration)
    {
        CommentConfiguration.ToTable("comments", "lovedmemory");
        CommentConfiguration.HasKey(c => c.Id);
        CommentConfiguration.Property(c => c.CreatedByUserId)
           .HasMaxLength(100);
        CommentConfiguration.HasOne(c => c.Memorial).WithMany(m => m.Comments).HasForeignKey(c => c.MemorialId).OnDelete(DeleteBehavior.Cascade);
        CommentConfiguration.HasOne(c => c.CreatedByUser).WithMany().HasForeignKey(c => c.CreatedByUserId).OnDelete(DeleteBehavior.Cascade);
        CommentConfiguration.HasOne(c => c.ParentComment).WithMany(c => c.Replies).HasForeignKey(c => c.ParentCommentId).OnDelete(DeleteBehavior.NoAction).IsRequired(false);
    }
}