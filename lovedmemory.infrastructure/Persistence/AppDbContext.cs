using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using lovedmemory.Infrastructure.Identity;
using lovedmemory.Domain.Entities;
using lovedmemory.Application.Common.Interfaces;
using System.Reflection.Emit;
namespace lovedmemory.Infrastructure.Data;

public class AppDbContext(DbContextOptions<AppDbContext> options) : IdentityDbContext<AppUser>(options), IAppDbContext
{
    public DbSet<Tribute> Tributes { get; set; }
    public DbSet<Comment> Comments { get; set; }
    public DbSet<EventDetail> EventDetails { get; set; }
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

            //foreach (var index in entity.GetIndexes())
            //{
            //    index.SetName(index.GetName().ToLower());
            //}

            foreach (var foreignKey in entity.GetForeignKeys())
            {
                foreignKey.SetConstraintName(foreignKey.GetConstraintName().ToLower());
            }
        }

        builder.Entity<Tribute>()
        .ToTable("tributes", schema: "lovedmemory");

        builder.Entity<Comment>()
        .ToTable("comments", schema: "lovedmemory");

        builder.Entity<EventDetail>()
        .ToTable("eventdetails", schema: "lovedmemory");
    }
}
