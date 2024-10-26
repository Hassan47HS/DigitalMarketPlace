using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace UoNMarketPlace.Migrations
{
    /// <inheritdoc />
    public partial class Check : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3d5f9ea0-f046-4783-b883-ff73d52a82c7");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "7914361c-46c6-4bf8-b5eb-01252f638ef3");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ef069807-e632-40c8-8bd9-f646f279922f");

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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
                table: "Notifications");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "3d5f9ea0-f046-4783-b883-ff73d52a82c7", "5", "Admin", "Admin" },
                    { "7914361c-46c6-4bf8-b5eb-01252f638ef3", "1", "Student", "Student" },
                    { "ef069807-e632-40c8-8bd9-f646f279922f", "4", "Alumini", "Alumini" }
                });
        }
    }
}
