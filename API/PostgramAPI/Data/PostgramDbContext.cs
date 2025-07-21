using Microsoft.EntityFrameworkCore;
using PostgramAPI.Models;

namespace PostgramAPI.Data;

public class PostgramDbContext : DbContext
{
    public PostgramDbContext(DbContextOptions<PostgramDbContext> options) : base(options)
    {
    }

    public DbSet<User> Users { get; set; }
    public DbSet<Post> Posts { get; set; }
    public DbSet<Category> Categories { get; set; }
    public DbSet<Auth> Auths { get; set; }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<User>()
            .HasOne(u => u.Auth)
            .WithOne(a => a.User)
            .HasForeignKey<Auth>(a => a.UserId);

        modelBuilder.Entity<Auth>()
            .HasIndex(a => a.UserName)
            .IsUnique();

        modelBuilder.Entity<PostCategoryRelation>()
            .HasKey(pc => new { pc.PostId, pc.CategoryId });

        modelBuilder.Entity<PostCategoryRelation>()
            .HasOne(pc => pc.Post)
            .WithMany(p => p.PostCategoryRelations)
            .HasForeignKey(pc => pc.PostId);

        modelBuilder.Entity<PostCategoryRelation>()
            .HasOne(pc => pc.Category)
            .WithMany(c => c.PostCategoryRelations)
            .HasForeignKey(pc => pc.CategoryId);
    }
}