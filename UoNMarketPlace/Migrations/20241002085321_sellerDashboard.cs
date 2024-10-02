using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace UoNMarketPlace.Migrations
{
    /// <inheritdoc />
    public partial class sellerDashboard : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "19e7c31a-f77e-4bcc-8c17-148de232d325");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "38492d99-7258-4acc-9b8c-eaabe5c8c64a");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "5841fc7c-b804-4df0-ab74-b91f7705937b");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "7a88ff2b-aab2-43f5-a56a-51ea0e9e8edb");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "7ce2ad2b-7f5a-4fdb-be62-dc7bae5cf9ad");

            migrationBuilder.AddColumn<DateTime>(
                name: "DateUploaded",
                table: "Products",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "SellerId",
                table: "Products",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "Views",
                table: "Products",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "0afd8ec9-a524-47a8-aed5-84b8e4291cc6", "1", "Student", "Student" },
                    { "3c5f6217-22e1-459a-b63e-737dcbf21e02", "5", "Admin", "Admin" },
                    { "5c4671ac-d200-451f-9afd-b1b1deb6cbe3", "4", "Alumini", "Alumini" },
                    { "f4a3e137-d34e-47fb-97d1-da9f76c84143", "2", "Faculty", "Faculty" },
                    { "fb062d91-73a3-4258-b4eb-21c7ea6322fa", "3", "Staff", "Staff" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "0afd8ec9-a524-47a8-aed5-84b8e4291cc6");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3c5f6217-22e1-459a-b63e-737dcbf21e02");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "5c4671ac-d200-451f-9afd-b1b1deb6cbe3");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f4a3e137-d34e-47fb-97d1-da9f76c84143");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "fb062d91-73a3-4258-b4eb-21c7ea6322fa");

            migrationBuilder.DropColumn(
                name: "DateUploaded",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "SellerId",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "Views",
                table: "Products");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "19e7c31a-f77e-4bcc-8c17-148de232d325", "3", "Staff", "Staff" },
                    { "38492d99-7258-4acc-9b8c-eaabe5c8c64a", "1", "Student", "Student" },
                    { "5841fc7c-b804-4df0-ab74-b91f7705937b", "2", "Faculty", "Faculty" },
                    { "7a88ff2b-aab2-43f5-a56a-51ea0e9e8edb", "4", "Alumini", "Alumini" },
                    { "7ce2ad2b-7f5a-4fdb-be62-dc7bae5cf9ad", "5", "Admin", "Admin" }
                });
        }
    }
}
