using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace EntityManager.Migrations
{
    /// <inheritdoc />
    public partial class SetData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Authors",
                columns: new[] { "Id", "Age", "Name" },
                values: new object[,]
                {
                    { 1, 25, "amir" },
                    { 2, 30, "ali" }
                });

            migrationBuilder.InsertData(
                table: "Libraries",
                columns: new[] { "Id", "Address", "Name" },
                values: new object[] { 4, "Tehran", "iman" });

            migrationBuilder.InsertData(
                table: "Books",
                columns: new[] { "Id", "AuthorId", "LibraryId", "Name", "Price" },
                values: new object[] { 2, 2, 4, "ryaze", 200.0 });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Libraries",
                keyColumn: "Id",
                keyValue: 4);
        }
    }
}
