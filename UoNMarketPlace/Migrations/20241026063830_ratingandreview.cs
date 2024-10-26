using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace UoNMarketPlace.Migrations
{
    /// <inheritdoc />
    public partial class ratingandreview : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductReviews_Products_sellProductId",
                table: "ProductReviews");

            migrationBuilder.DropIndex(
                name: "IX_ProductReviews_sellProductId",
                table: "ProductReviews");

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
                name: "sellProductId",
                table: "ProductReviews");

            migrationBuilder.AddColumn<int>(
                name: "ProductId",
                table: "ProductReviews",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "07ebc537-8b7f-4fd5-aa38-47a6c628943b", "1", "Student", "Student" },
                    { "7de8e058-2b4e-4e02-9c70-95ff65c08d18", "5", "Admin", "Admin" },
                    { "81b85a4c-b9b5-4534-87ba-6d9257eab4ce", "4", "Alumini", "Alumini" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_ProductReviews_ProductId",
                table: "ProductReviews",
                column: "ProductId");

            migrationBuilder.AddForeignKey(
                name: "FK_ProductReviews_Products_ProductId",
                table: "ProductReviews",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductReviews_Products_ProductId",
                table: "ProductReviews");

            migrationBuilder.DropIndex(
                name: "IX_ProductReviews_ProductId",
                table: "ProductReviews");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "07ebc537-8b7f-4fd5-aa38-47a6c628943b");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "7de8e058-2b4e-4e02-9c70-95ff65c08d18");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "81b85a4c-b9b5-4534-87ba-6d9257eab4ce");

            migrationBuilder.DropColumn(
                name: "ProductId",
                table: "ProductReviews");

            migrationBuilder.AddColumn<int>(
                name: "sellProductId",
                table: "ProductReviews",
                type: "int",
                nullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "9e991c2e-721d-4463-9a5a-02275d683691", "1", "Student", "Student" },
                    { "e7184eea-9f60-4909-8a52-46a0d2996dea", "5", "Admin", "Admin" },
                    { "f6a2c55d-7c3e-42e2-b698-1eed36656bb0", "4", "Alumini", "Alumini" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_ProductReviews_sellProductId",
                table: "ProductReviews",
                column: "sellProductId");

            migrationBuilder.AddForeignKey(
                name: "FK_ProductReviews_Products_sellProductId",
                table: "ProductReviews",
                column: "sellProductId",
                principalTable: "Products",
                principalColumn: "Id");
        }
    }
}
