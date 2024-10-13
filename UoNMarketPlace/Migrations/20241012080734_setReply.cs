using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace UoNMarketPlace.Migrations
{
    /// <inheritdoc />
    public partial class setReply : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "08339f79-6cd9-44bb-bd47-a99f52d730a7");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b9c87502-c52f-4767-a679-86896c36f696");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "fb0bde18-576d-476f-b3fe-71df04c49003");

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "08339f79-6cd9-44bb-bd47-a99f52d730a7", "4", "Alumini", "Alumini" },
                    { "b9c87502-c52f-4767-a679-86896c36f696", "1", "Student", "Student" },
                    { "fb0bde18-576d-476f-b3fe-71df04c49003", "5", "Admin", "Admin" }
                });
        }
    }
}
