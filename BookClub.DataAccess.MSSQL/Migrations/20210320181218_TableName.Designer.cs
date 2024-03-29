﻿// <auto-generated />
using BookClub.DataAccess.MSSQL;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace BookClub.DataAccess.MSSQL.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20210320181218_TableName")]
    partial class TableName
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseIdentityColumns()
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.0");

            modelBuilder.Entity("BookClub.Domain.Models.Book", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Author")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Books");
                });

            modelBuilder.Entity("BookClub.Domain.Models.User", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("BookUser", b =>
                {
                    b.Property<string>("ReadBooksId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("UsersWhoReadBookId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("ReadBooksId", "UsersWhoReadBookId");

                    b.HasIndex("UsersWhoReadBookId");

                    b.ToTable("ReadBooks");
                });

            modelBuilder.Entity("BookUser", b =>
                {
                    b.HasOne("BookClub.Domain.Models.Book", null)
                        .WithMany()
                        .HasForeignKey("ReadBooksId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BookClub.Domain.Models.User", null)
                        .WithMany()
                        .HasForeignKey("UsersWhoReadBookId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
