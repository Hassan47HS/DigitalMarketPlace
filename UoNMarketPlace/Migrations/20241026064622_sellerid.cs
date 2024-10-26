using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace UoNMarketPlace.Migrations
{
    /// <inheritdoc />
    public partial class sellerid : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "07ebc537-8b7f-4fd5-aa38-47a6c628943b");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "7de8e058-2b4e-4e02-9c70-95ff65c08d18");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "81b85a4c-b9b5-4534-87ba-6d9257eab4ce");

            migrationBuilder.AlterColumn<string>(
                name: "SellerId",
                table: "Notifications",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "3781959f-0ead-4260-b50c-895a36f5752c", "1", "Student", "Student" },
                    { "5b19139a-a6b9-4e0f-b9e0-364ab31b50aa", "5", "Admin", "Admin" },
                    { "7c52155f-3ec5-49b4-9549-e71a3766d8b5", "4", "Alumini", "Alumini" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3781959f-0ead-4260-b50c-895a36f5752c");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "5b19139a-a6b9-4e0f-b9e0-364ab31b50aa");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "7c52155f-3ec5-49b4-9549-e71a3766d8b5");

            migrationBuilder.AlterColumn<string>(
                name: "SellerId",
                table: "Notifications",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "07ebc537-8b7f-4fd5-aa38-47a6c628943b", "1", "Student", "Student" },
                    { "7de8e058-2b4e-4e02-9c70-95ff65c08d18", "5", "Admin", "Admin" },
                    { "81b85a4c-b9b5-4534-87ba-6d9257eab4ce", "4", "Alumini", "Alumini" }
                });
        }
    }
}
