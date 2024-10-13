using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace UoNMarketPlace.Migrations
{
    /// <inheritdoc />
    public partial class Flag : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "005a6e4e-ff11-47d1-8f3b-1dbd30cdd151");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "8e98ecd9-f20e-42e9-b0a1-4846604523e1");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "feea4ef6-73c3-4910-b560-7a06d2fdd927");

            migrationBuilder.AddColumn<string>(
                name: "FlagReason",
                table: "Products",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsApproved",
                table: "Products",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsFlagged",
                table: "Products",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "1838195e-5e4e-4144-a05b-cb69f11f9d69", "4", "Alumini", "Alumini" },
                    { "2e2cdca8-0c8a-48ad-857f-0dfcb348a92b", "5", "Admin", "Admin" },
                    { "c049f5db-e550-4fe3-84dd-41a18a23d926", "1", "Student", "Student" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1838195e-5e4e-4144-a05b-cb69f11f9d69");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2e2cdca8-0c8a-48ad-857f-0dfcb348a92b");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c049f5db-e550-4fe3-84dd-41a18a23d926");

            migrationBuilder.DropColumn(
                name: "FlagReason",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "IsApproved",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "IsFlagged",
                table: "Products");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "005a6e4e-ff11-47d1-8f3b-1dbd30cdd151", "4", "Alumini", "Alumini" },
                    { "8e98ecd9-f20e-42e9-b0a1-4846604523e1", "1", "Student", "Student" },
                    { "feea4ef6-73c3-4910-b560-7a06d2fdd927", "5", "Admin", "Admin" }
                });
        }
    }
}
