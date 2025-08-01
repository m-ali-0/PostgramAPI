﻿using Microsoft.EntityFrameworkCore;
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


        modelBuilder.Entity<Post>()
            .HasMany(p => p.Categories)
            .WithMany(c => c.Posts);
    }
}