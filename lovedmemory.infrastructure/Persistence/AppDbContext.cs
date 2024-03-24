using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using lovedmemory.Infrastructure.Identity;
using lovedmemory.Domain.Entities;
using lovedmemory.Application.Common.Interfaces;
namespace lovedmemory.Infrastructure.Data;

public class AppDbContext : IdentityDbContext<AppUser>, IAppDbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    public DbSet<Tribute> Tributes { get; set; }
    public DbSet<Comment> Comments { get; set; }
    public DbSet<EventDetail> EventDetails { get; set; }
    protected override void OnModelCreating(ModelBuilder builder)
    {

        base.OnModelCreating(builder);
        builder.Entity<Tribute>()
        .ToTable("tribute", schema: "tributes");

        //builder.Entity<Student>()
        //.HasOne(s => s.StudentClass)
        //.WithOne(s => s.Student)
        //.HasForeignKey<ClassRoomStudent>(c => c.StudentId);

    }
}
