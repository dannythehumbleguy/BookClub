using Microsoft.EntityFrameworkCore.Migrations;

namespace BookClub.DataAccess.MSSQL.Migrations
{
    public partial class TableName : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ReadBooks_Book_ReadBooksId",
                table: "ReadBooks");

            migrationBuilder.DropForeignKey(
                name: "FK_ReadBooks_User_UsersWhoReadBookId",
                table: "ReadBooks");

            migrationBuilder.DropPrimaryKey(
                name: "PK_User",
                table: "User");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Book",
                table: "Book");

            migrationBuilder.RenameTable(
                name: "User",
                newName: "Users");

            migrationBuilder.RenameTable(
                name: "Book",
                newName: "Books");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Users",
                table: "Users",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Books",
                table: "Books",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ReadBooks_Books_ReadBooksId",
                table: "ReadBooks",
                column: "ReadBooksId",
                principalTable: "Books",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ReadBooks_Users_UsersWhoReadBookId",
                table: "ReadBooks",
                column: "UsersWhoReadBookId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ReadBooks_Books_ReadBooksId",
                table: "ReadBooks");

            migrationBuilder.DropForeignKey(
                name: "FK_ReadBooks_Users_UsersWhoReadBookId",
                table: "ReadBooks");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Users",
                table: "Users");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Books",
                table: "Books");

            migrationBuilder.RenameTable(
                name: "Users",
                newName: "User");

            migrationBuilder.RenameTable(
                name: "Books",
                newName: "Book");

            migrationBuilder.AddPrimaryKey(
                name: "PK_User",
                table: "User",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Book",
                table: "Book",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ReadBooks_Book_ReadBooksId",
                table: "ReadBooks",
                column: "ReadBooksId",
                principalTable: "Book",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ReadBooks_User_UsersWhoReadBookId",
                table: "ReadBooks",
                column: "UsersWhoReadBookId",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
