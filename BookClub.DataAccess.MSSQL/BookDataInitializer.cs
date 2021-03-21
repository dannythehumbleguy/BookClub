using System;
using System.Collections.Generic;
using BookClub.Domain.Models;

namespace BookClub.DataAccess.MSSQL
{
    public class BookDataInitializer
    {
        public static Book[] GetBooks()
        {
            return new Book[]
            {
                new()
                {
                    Id = Guid.NewGuid().ToString(),
                    Name = "Алые паруса",
                    Author = "Александр Грин",
                    UsersWhoReadBook = new List<User>()
                },
                new()
                {
                    Id = Guid.NewGuid().ToString(),
                    Name = "11/22/63",
                    Author = "Стивен Кинг",
                    UsersWhoReadBook = new List<User>()
                },
                new()
                {
                    Id = Guid.NewGuid().ToString(),
                    Name = "Пикник на обочине",
                    Author = "Аркадий Стругацкий и др.",
                    UsersWhoReadBook = new List<User>()
                },
                new()
                {
                    Id = Guid.NewGuid().ToString(),
                    Name = "Источник",
                    Author = "Айн Рэнд",
                    UsersWhoReadBook = new List<User>()
                },
                new()
                {
                    Id = Guid.NewGuid().ToString(),
                    Name = "Дары волхвов",
                    Author = "О` Генри",
                    UsersWhoReadBook = new List<User>()
                },
                new()
                {
                    Id = Guid.NewGuid().ToString(),
                    Name = "Фауст",
                    Author = "Иоганн Вольфганг Гете",
                    UsersWhoReadBook = new List<User>()
                },
                new()
                {
                    Id = Guid.NewGuid().ToString(),
                    Name = "Отверженные",
                    Author = "Виктор Гюго",
                    UsersWhoReadBook = new List<User>()
                },
                new()
                {
                    Id = Guid.NewGuid().ToString(),
                    Name = "Собака Баскервилей",
                    Author = "Артур Конан Дойл",
                    UsersWhoReadBook = new List<User>()
                }
            };
        }
    }
}