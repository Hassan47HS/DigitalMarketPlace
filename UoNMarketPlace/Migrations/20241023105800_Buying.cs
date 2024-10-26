using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace UoNMarketPlace.Migrations
{
    /// <inheritdoc />
    public partial class Buying : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Messages_Products_sellProductId",
                table: "Messages");

            migrationBuilder.DropIndex(
                name: "IX_Messages_sellProductId",
                table: "Messages");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "203d98e3-fc10-4e3b-bb5e-047f484de85b");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "69761adc-a5ad-4db4-add7-5ebeacf193f1");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ac8ea88a-bb7f-4289-9b30-5fa8cedfc99e");

            migrationBuilder.DropColumn(
                name: "sellProductId",
                table: "Messages");

            migrationBuilder.AlterColumn<int>(
                name: "ProductId",
                table: "Messages",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "163be5b6-6120-4e70-901f-1012bc94fe6b", "5", "Admin", "Admin" },
                    { "2683d385-6c52-4760-b24e-060369688fc0", "4", "Alumini", "Alumini" },
                    { "7a45b511-ff5c-44f5-b6ab-cebefa4fc9f3", "1", "Student", "Student" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Messages_ProductId",
                table: "Messages",
                column: "ProductId");

            migrationBuilder.AddForeignKey(
                name: "FK_Messages_Products_ProductId",
                table: "Messages",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Messages_Products_ProductId",
                table: "Messages");

            migrationBuilder.DropIndex(
                name: "IX_Messages_ProductId",
                table: "Messages");

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

            migrationBuilder.AlterColumn<int>(
                name: "ProductId",
                table: "Messages",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "sellProductId",
                table: "Messages",
                type: "int",
                nullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "203d98e3-fc10-4e3b-bb5e-047f484de85b", "5", "Admin", "Admin" },
                    { "69761adc-a5ad-4db4-add7-5ebeacf193f1", "1", "Student", "Student" },
                    { "ac8ea88a-bb7f-4289-9b30-5fa8cedfc99e", "4", "Alumini", "Alumini" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Messages_sellProductId",
                table: "Messages",
                column: "sellProductId");

            migrationBuilder.AddForeignKey(
                name: "FK_Messages_Products_sellProductId",
                table: "Messages",
                column: "sellProductId",
                principalTable: "Products",
                principalColumn: "Id");
        }
    }
}
