using System.Collections.Generic;
using BookClub.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace BookClub.DataAccess.MSSQL
{
    public class AppDbContext : DbContext
    {
        public List<Book> Books { get; set; }
        public List<User> Users { get; set; }
        public AppDbContext(DbContextOptions<AppDbContext> options): base(options)
        {}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
                .HasMany(c => c.ReadBooks)
                .WithMany(s => s.UsersWhoReadBook)
                .UsingEntity(j => j.ToTable("ReadBooks"));
        }
    }
}