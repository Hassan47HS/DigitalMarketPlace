using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace UoNMarketPlace.Migrations
{
    /// <inheritdoc />
    public partial class Review : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "046faf16-9c66-4fcc-a522-d7d19067d901");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1fc8803e-fd93-4e62-b72b-e56492887082");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "8badfe42-089a-4cfb-b0e3-aae95d452bc1");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a5a132db-9a3a-4331-8d98-5098c0a6b02b");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d4c261e7-7ba7-40cd-a819-59e939666c5f");

            migrationBuilder.AddColumn<double>(
                name: "Rating",
                table: "Products",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AlterColumn<string>(
                name: "Title",
                table: "AlumniPosts",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "ImagePath",
                table: "AlumniPosts",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Content",
                table: "AlumniPosts",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "AlumniId",
                table: "AlumniPosts",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.CreateTable(
                name: "ProductReviews",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ReviewText = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Rating = table.Column<double>(type: "float", nullable: false),
                    DateReviewed = table.Column<DateTime>(type: "datetime2", nullable: false),
                    sellProductId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductReviews", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProductReviews_Products_sellProductId",
                        column: x => x.sellProductId,
                        principalTable: "Products",
                        principalColumn: "Id");
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "6d9173d4-2722-4422-984c-b32becb85347", "4", "Alumini", "Alumini" },
                    { "c29a884c-45f2-4c7c-a3ec-19ead47087da", "1", "Student", "Student" },
                    { "f2a2f6f3-0877-4cda-a399-ba84205090bc", "5", "Admin", "Admin" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_ProductReviews_sellProductId",
                table: "ProductReviews",
                column: "sellProductId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProductReviews");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "6d9173d4-2722-4422-984c-b32becb85347");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c29a884c-45f2-4c7c-a3ec-19ead47087da");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f2a2f6f3-0877-4cda-a399-ba84205090bc");

            migrationBuilder.DropColumn(
                name: "Rating",
                table: "Products");

            migrationBuilder.AlterColumn<string>(
                name: "Title",
                table: "AlumniPosts",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ImagePath",
                table: "AlumniPosts",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Content",
                table: "AlumniPosts",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "AlumniId",
                table: "AlumniPosts",
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
                    { "046faf16-9c66-4fcc-a522-d7d19067d901", "2", "Faculty", "Faculty" },
                    { "1fc8803e-fd93-4e62-b72b-e56492887082", "3", "Staff", "Staff" },
                    { "8badfe42-089a-4cfb-b0e3-aae95d452bc1", "5", "Admin", "Admin" },
                    { "a5a132db-9a3a-4331-8d98-5098c0a6b02b", "1", "Student", "Student" },
                    { "d4c261e7-7ba7-40cd-a819-59e939666c5f", "4", "Alumini", "Alumini" }
                });
        }
    }
}
