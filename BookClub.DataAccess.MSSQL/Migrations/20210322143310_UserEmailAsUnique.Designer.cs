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
    [Migration("20210322143310_UserEmailAsUnique")]
    partial class UserEmailAsUnique
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

                    b.HasData(
                        new
                        {
                            Id = "52abc775-42b4-47cb-a6bb-5e3e7c31d068",
                            Author = "Александр Грин",
                            Name = "Алые паруса"
                        },
                        new
                        {
                            Id = "2123e897-c328-4006-8e73-41e80951a311",
                            Author = "Стивен Кинг",
                            Name = "11/22/63"
                        },
                        new
                        {
                            Id = "c85e9b10-8bb0-49d0-9129-42e410eee2b4",
                            Author = "Аркадий Стругацкий и др.",
                            Name = "Пикник на обочине"
                        },
                        new
                        {
                            Id = "852a8b0f-f836-4219-9de9-432c493a3bb5",
                            Author = "Айн Рэнд",
                            Name = "Источник"
                        },
                        new
                        {
                            Id = "d9da1629-6ce2-4668-b1d9-12e8343f81cf",
                            Author = "О` Генри",
                            Name = "Дары волхвов"
                        },
                        new
                        {
                            Id = "daab8d65-4740-4a2b-a95d-8e1e8efb7835",
                            Author = "Иоганн Вольфганг Гете",
                            Name = "Фауст"
                        },
                        new
                        {
                            Id = "d86a471e-5c16-4d8b-b195-e803137deb76",
                            Author = "Виктор Гюго",
                            Name = "Отверженные"
                        },
                        new
                        {
                            Id = "af3dd5a9-f566-4443-964b-3ece6b390c6e",
                            Author = "Артур Конан Дойл",
                            Name = "Собака Баскервилей"
                        });
                });

            modelBuilder.Entity("BookClub.Domain.Models.User", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("Email")
                        .IsUnique()
                        .HasFilter("[Email] IS NOT NULL");

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