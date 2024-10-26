using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace UoNMarketPlace.Migrations
{
    /// <inheritdoc />
    public partial class test : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "163be5b6-6120-4e70-901f-1012bc94fe6b");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2683d385-6c52-4760-b24e-060369688fc0");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "7a45b511-ff5c-44f5-b6ab-cebefa4fc9f3");

            migrationBuilder.AlterColumn<string>(
                name: "BuyerId",
                table: "Products",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AlterColumn<string>(
                name: "BuyerId",
                table: "Products",
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
                    { "163be5b6-6120-4e70-901f-1012bc94fe6b", "5", "Admin", "Admin" },
                    { "2683d385-6c52-4760-b24e-060369688fc0", "4", "Alumini", "Alumini" },
                    { "7a45b511-ff5c-44f5-b6ab-cebefa4fc9f3", "1", "Student", "Student" }
                });
        }
    }
}
