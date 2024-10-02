using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace UoNMarketPlace.Migrations
{
    /// <inheritdoc />
    public partial class sellProduct : Migration
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

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Category = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ImagePath = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                });

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Products");

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
