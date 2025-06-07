using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using lovedmemory.domain.Entities;
using lovedmemory.application.Common.Interfaces;
using lovedmemory.Domain.Entities.Other;
using lovedmemory.infrastructure.Configurations;
namespace lovedmemory.Infrastructure.Data;

public class AppDbContext(DbContextOptions<AppDbContext> options) : IdentityDbContext<AppUser>(options), IAppDbContext
{
    public DbSet<Memorial> Memorials { get; set; }
    public DbSet<Comment> Comments { get; set; }
    public DbSet<Gallery> Gallary { get; set; }
    public DbSet<Contact> ContactMessages { get; set; }
    public DbSet<EventDetail> EventDetails { get; set; }
    public DbSet<Permission> Permissions { get; set; }
    public DbSet<RolePermission> RolePermissions { get;  set; }
    public DbSet<ExtraDetails> ExtraDetails { get; set; }
    public DbSet<Tribute> Tributes { get; set; }
    protected override void OnModelCreating(ModelBuilder builder)
    {

        base.OnModelCreating(builder);
        builder.HasDefaultSchema("lovedmemory");
        foreach (var entity in builder.Model.GetEntityTypes())
        {
            entity.SetTableName(entity.GetTableName().ToLower());

            foreach (var property in entity.GetProperties())
            {
                property.SetColumnName(property.GetColumnName().ToLower());
            }

            foreach (var key in entity.GetKeys())
            {
                key.SetName(key.GetName().ToLower());
            }

            foreach (var foreignKey in entity.GetForeignKeys())
            {
                foreignKey.SetConstraintName(foreignKey.GetConstraintName().ToLower());
            }
        }
        builder.ApplyConfiguration(new MemorialConfig());
        builder.ApplyConfiguration(new LifeStoryEntityConfig());
        builder.ApplyConfiguration(new ExtraDetailsConfig());
        builder.Entity<Memorial>()
        .ToTable("memorials", schema: "lovedmemory");

        builder.Entity<Gallery>()
        .ToTable("gallery", schema: "lovedmemory");

        builder.Entity<Comment>()
        .ToTable("comments", schema: "lovedmemory");

        builder.Entity<EventDetail>()
        .ToTable("event_details", schema: "lovedmemory");

        builder.Entity<Memorial>()
         .HasOne(t => t.CreatedByUser)
         .WithMany()
         .HasForeignKey(t => t.CreatedByUserId)
         .OnDelete(DeleteBehavior.Restrict);

        builder.Entity<Memorial>()
            .HasMany(t => t.Gallery)
            .WithOne(g => g.Memorial)
            .HasForeignKey(g => g.MemorialId);

        builder.Entity<Memorial>()
            .HasOne(t => t.ExtraDetails)
            .WithOne()
            .HasForeignKey<ExtraDetails>(e => e.MemorialId);

        builder.Entity<Gallery>()
        .HasKey(g => g.MemorialId);

        builder.Entity<ExtraDetails>()
            .HasKey(e => e.MemorialId);
    }
}
