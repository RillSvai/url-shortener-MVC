using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace UrlShortener.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class DeleteSeededUsersAndUrls : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Urls",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Urls",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Email", "Password", "Role", "UserName" },
                values: new object[,]
                {
                    { 1, "Test1Email", "Test1Password", "Customer", "Test1Name" },
                    { 2, "Test2Email", "Test2Password", "Admin", "Test2Name" }
                });

            migrationBuilder.InsertData(
                table: "Urls",
                columns: new[] { "Id", "CreatorId", "OriginalUrl", "ShortUrl", "TokenShortUrl" },
                values: new object[,]
                {
                    { 1, 1, "Test1Long", "Test1Short", "test1" },
                    { 2, 2, "Test2Long", "Test2Short", "test2" }
                });
        }
    }
}
