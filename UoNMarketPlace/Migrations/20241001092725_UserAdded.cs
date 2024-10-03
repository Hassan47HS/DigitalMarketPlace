using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace UoNMarketPlace.Migrations
{
    /// <inheritdoc />
    public partial class UserAdded : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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
                    { "41739869-7d19-4a20-8937-0e60275e85f3", "4", "Alumini", "Alumini" },
                    { "a350e2af-9391-422a-ba77-5ed5ed5e0e7d", "2", "Faculty", "Faculty" },
                    { "aa0c20e7-8f86-48a7-b858-f7a3122ef756", "3", "Staff", "Staff" },
                    { "b9fa86e7-c6bd-4ee5-b0c3-87c9a5402c6f", "5", "Admin", "Admin" },
                    { "d96ff48f-27a6-41f5-b44b-b990554c30a8", "1", "Student", "Student" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "41739869-7d19-4a20-8937-0e60275e85f3");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a350e2af-9391-422a-ba77-5ed5ed5e0e7d");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "aa0c20e7-8f86-48a7-b858-f7a3122ef756");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b9fa86e7-c6bd-4ee5-b0c3-87c9a5402c6f");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d96ff48f-27a6-41f5-b44b-b990554c30a8");

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
    }
}
