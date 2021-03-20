using System.Collections.Generic;
using BookClub.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace BookClub.DataAccess.MSSQL
{
    public class AppDbContext : DbContext
    {
        public DbSet<Book> Books { get; set; }
        public DbSet<User> Users { get; set; }
        public AppDbContext(DbContextOptions<AppDbContext> options): base(options)
        {}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Book>()
                .ToTable("Books");
            modelBuilder.Entity<User>()
                .ToTable("Users")
                .HasMany(c => c.ReadBooks)
                .WithMany(s => s.UsersWhoReadBook)
                .UsingEntity(j => j.ToTable("ReadBooks"));
        }
    }
}