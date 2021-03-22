using Microsoft.EntityFrameworkCore.Migrations;

namespace BookClub.DataAccess.MSSQL.Migrations
{
    public partial class UserEmailAsUnique : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "Users",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.InsertData(
                table: "Books",
                columns: new[] { "Id", "Author", "Name" },
                values: new object[,]
                {
                    { "52abc775-42b4-47cb-a6bb-5e3e7c31d068", "Александр Грин", "Алые паруса" },
                    { "2123e897-c328-4006-8e73-41e80951a311", "Стивен Кинг", "11/22/63" },
                    { "c85e9b10-8bb0-49d0-9129-42e410eee2b4", "Аркадий Стругацкий и др.", "Пикник на обочине" },
                    { "852a8b0f-f836-4219-9de9-432c493a3bb5", "Айн Рэнд", "Источник" },
                    { "d9da1629-6ce2-4668-b1d9-12e8343f81cf", "О` Генри", "Дары волхвов" },
                    { "daab8d65-4740-4a2b-a95d-8e1e8efb7835", "Иоганн Вольфганг Гете", "Фауст" },
                    { "d86a471e-5c16-4d8b-b195-e803137deb76", "Виктор Гюго", "Отверженные" },
                    { "af3dd5a9-f566-4443-964b-3ece6b390c6e", "Артур Конан Дойл", "Собака Баскервилей" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Users_Email",
                table: "Users",
                column: "Email",
                unique: true,
                filter: "[Email] IS NOT NULL");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Users_Email",
                table: "Users");

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: "2123e897-c328-4006-8e73-41e80951a311");

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: "52abc775-42b4-47cb-a6bb-5e3e7c31d068");

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: "852a8b0f-f836-4219-9de9-432c493a3bb5");

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: "af3dd5a9-f566-4443-964b-3ece6b390c6e");

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: "c85e9b10-8bb0-49d0-9129-42e410eee2b4");

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: "d86a471e-5c16-4d8b-b195-e803137deb76");

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: "d9da1629-6ce2-4668-b1d9-12e8343f81cf");

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: "daab8d65-4740-4a2b-a95d-8e1e8efb7835");

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "Users",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

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
    }
}
