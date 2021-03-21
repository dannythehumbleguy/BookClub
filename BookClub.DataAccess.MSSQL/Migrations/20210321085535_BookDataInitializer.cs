using Microsoft.EntityFrameworkCore.Migrations;

namespace BookClub.DataAccess.MSSQL.Migrations
{
    public partial class BookDataInitializer : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Books",
                columns: new[] { "Id", "Author", "Name" },
                values: new object[,]
                {
                    { "4ab73c18-ef9d-4642-89be-986a7a2e8b4f", "Александр Грин", "Алые паруса" },
                    { "ccfcb146-797d-4f34-8947-526ea848aa70", "Стивен Кинг", "11/22/63" },
                    { "2994537b-3283-45d8-bbb1-596e97c3ea8e", "Аркадий Стругацкий и др.", "Пикник на обочине" },
                    { "717fbd01-5149-46d0-8edc-ed579792812a", "Айн Рэнд", "Источник" },
                    { "85c0d171-b147-46cf-90bc-9214003c31d2", "О` Генри", "Дары волхвов" },
                    { "090198a5-85ea-4931-945c-22c667497689", "Иоганн Вольфганг Гете", "Фауст" },
                    { "b8fc6973-cc94-4943-8e73-4a661eaf5baf", "Виктор Гюго", "Отверженные" },
                    { "374cf051-c3f9-49ce-b4dc-e84b7146a605", "Артур Конан Дойл", "Собака Баскервилей" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: "090198a5-85ea-4931-945c-22c667497689");

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: "2994537b-3283-45d8-bbb1-596e97c3ea8e");

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: "374cf051-c3f9-49ce-b4dc-e84b7146a605");

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: "4ab73c18-ef9d-4642-89be-986a7a2e8b4f");

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: "717fbd01-5149-46d0-8edc-ed579792812a");

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: "85c0d171-b147-46cf-90bc-9214003c31d2");

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: "b8fc6973-cc94-4943-8e73-4a661eaf5baf");

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: "ccfcb146-797d-4f34-8947-526ea848aa70");
        }
    }
}
