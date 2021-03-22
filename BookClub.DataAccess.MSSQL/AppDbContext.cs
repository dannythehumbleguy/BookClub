using System.IO;
using BookClub.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace BookClub.DataAccess.MSSQL
{
    public class AppDbContext : DbContext
    {
        public DbSet<Book> Books { get; set; }
        public DbSet<User> Users { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Book>()
                .ToTable("Books")
                .HasData(BookDataInitializer.GetBooks());
            
            modelBuilder.Entity<User>(entity =>
            {
                entity.ToTable("Users")
                    .HasMany(c => c.ReadBooks)
                    .WithMany(s => s.UsersWhoReadBook)
                    .UsingEntity(j => j.ToTable("ReadBooks"));
                
                entity.HasIndex(i => i.Email).IsUnique();
            });
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            IConfigurationRoot configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();
            
            var connectionString = configuration.GetConnectionString("DefaultConnection");
            optionsBuilder.UseSqlServer(connectionString);
        }
    }
}