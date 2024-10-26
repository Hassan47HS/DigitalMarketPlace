using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace UoNMarketPlace.Migrations
{
    /// <inheritdoc />
    public partial class Checktest : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "0428b7dd-11f7-4d45-91ea-126dcba86daf");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b3a5c7d5-1432-493b-a858-f96f014d3eae");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "da95cec0-abb4-477b-9186-d0f89ed3b7de");

            migrationBuilder.DropColumn(
                name: "ProductId",
                table: "ProductReviews");

            migrationBuilder.DropColumn(
                name: "ProductId",
                table: "Notifications");

            migrationBuilder.AddColumn<string>(
                name: "SellerId",
                table: "ProductReviews",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "SellerId",
                table: "Notifications",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "9e991c2e-721d-4463-9a5a-02275d683691", "1", "Student", "Student" },
                    { "e7184eea-9f60-4909-8a52-46a0d2996dea", "5", "Admin", "Admin" },
                    { "f6a2c55d-7c3e-42e2-b698-1eed36656bb0", "4", "Alumini", "Alumini" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "9e991c2e-721d-4463-9a5a-02275d683691");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e7184eea-9f60-4909-8a52-46a0d2996dea");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f6a2c55d-7c3e-42e2-b698-1eed36656bb0");

            migrationBuilder.DropColumn(
                name: "SellerId",
                table: "ProductReviews");

            migrationBuilder.DropColumn(
                name: "SellerId",
                table: "Notifications");

            migrationBuilder.AddColumn<int>(
                name: "ProductId",
                table: "ProductReviews",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ProductId",
                table: "Notifications",
                type: "int",
                nullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "0428b7dd-11f7-4d45-91ea-126dcba86daf", "1", "Student", "Student" },
                    { "b3a5c7d5-1432-493b-a858-f96f014d3eae", "5", "Admin", "Admin" },
                    { "da95cec0-abb4-477b-9186-d0f89ed3b7de", "4", "Alumini", "Alumini" }
                });
        }
    }
}
