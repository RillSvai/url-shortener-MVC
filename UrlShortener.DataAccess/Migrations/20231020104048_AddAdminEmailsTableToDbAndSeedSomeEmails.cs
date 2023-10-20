using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace UrlShortener.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class AddAdminEmailsTableToDbAndSeedSomeEmails : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AdminEmails",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AdminEmails", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "AdminEmails",
                columns: new[] { "Id", "Email" },
                values: new object[,]
                {
                    { 1, "kirilkvas07@gmail.com" },
                    { 2, "admin@gmail.com" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AdminEmails");
        }
    }
}
