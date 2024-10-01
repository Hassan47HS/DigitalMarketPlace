using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace UoNMarketPlace.Migrations
{
    /// <inheritdoc />
    public partial class addRole : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2e751dbb-f389-4dac-a05b-686ba0878ee8");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "41fa99b2-bde9-4fa6-9516-72c8389cdffd");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "540f75d2-f343-464f-ac26-8d92f51c51e0");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "8d4eba4f-a90a-4173-9da4-99dc00bc9956");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "3fe41069-754b-4313-a8c3-2e1f8d9d4a7d", "5", "Admin", "Admin" },
                    { "46679ec0-ca01-4097-a42f-4e3892eaedea", "4", "Alumini", "Alumini" },
                    { "4d041784-d55c-44d1-b071-56e0100cba23", "1", "Student", "Student" },
                    { "8fd116e5-0912-4266-834b-6017213de68a", "3", "Staff", "Staff" },
                    { "d5671557-8fa3-43e7-9fe1-05f3ec4daf28", "2", "Faculty", "Faculty" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3fe41069-754b-4313-a8c3-2e1f8d9d4a7d");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "46679ec0-ca01-4097-a42f-4e3892eaedea");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "4d041784-d55c-44d1-b071-56e0100cba23");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "8fd116e5-0912-4266-834b-6017213de68a");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d5671557-8fa3-43e7-9fe1-05f3ec4daf28");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "2e751dbb-f389-4dac-a05b-686ba0878ee8", "3", "Staff", "Staff" },
                    { "41fa99b2-bde9-4fa6-9516-72c8389cdffd", "4", "Alumini", "Alumini" },
                    { "540f75d2-f343-464f-ac26-8d92f51c51e0", "1", "Student", "Student" },
                    { "8d4eba4f-a90a-4173-9da4-99dc00bc9956", "2", "Faculty", "Faculty" }
                });
        }
    }
}
