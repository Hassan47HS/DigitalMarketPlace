using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace UoNMarketPlace.Migrations
{
    /// <inheritdoc />
    public partial class Buyer : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "0d22d701-264f-4ce6-b871-a39e71a29e07");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "52b7041c-6669-4b6f-afbd-19abcb309b45");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "da67eb8f-1627-4bb9-b433-d5e0b9fe8e02");

            migrationBuilder.AddColumn<string>(
                name: "BuyerId",
                table: "Products",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "203d98e3-fc10-4e3b-bb5e-047f484de85b", "5", "Admin", "Admin" },
                    { "69761adc-a5ad-4db4-add7-5ebeacf193f1", "1", "Student", "Student" },
                    { "ac8ea88a-bb7f-4289-9b30-5fa8cedfc99e", "4", "Alumini", "Alumini" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "203d98e3-fc10-4e3b-bb5e-047f484de85b");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "69761adc-a5ad-4db4-add7-5ebeacf193f1");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ac8ea88a-bb7f-4289-9b30-5fa8cedfc99e");

            migrationBuilder.DropColumn(
                name: "BuyerId",
                table: "Products");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "0d22d701-264f-4ce6-b871-a39e71a29e07", "1", "Student", "Student" },
                    { "52b7041c-6669-4b6f-afbd-19abcb309b45", "5", "Admin", "Admin" },
                    { "da67eb8f-1627-4bb9-b433-d5e0b9fe8e02", "4", "Alumini", "Alumini" }
                });
        }
    }
}
