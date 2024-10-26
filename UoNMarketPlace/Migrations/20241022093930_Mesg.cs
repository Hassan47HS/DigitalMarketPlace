using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace UoNMarketPlace.Migrations
{
    /// <inheritdoc />
    public partial class Mesg : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2f384710-fb68-4156-bab7-c7e88a8cd5e3");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "4953aadf-bcbf-4c66-be92-a141aa491edc");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "7c1cae0f-c7dc-4759-9ae3-1ee15bc3e40a");

            migrationBuilder.AddColumn<int>(
                name: "sellProductId",
                table: "Messages",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Notifications",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Message = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsRead = table.Column<bool>(type: "bit", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Notifications", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "0d22d701-264f-4ce6-b871-a39e71a29e07", "1", "Student", "Student" },
                    { "52b7041c-6669-4b6f-afbd-19abcb309b45", "5", "Admin", "Admin" },
                    { "da67eb8f-1627-4bb9-b433-d5e0b9fe8e02", "4", "Alumini", "Alumini" }
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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Messages_Products_sellProductId",
                table: "Messages");

            migrationBuilder.DropTable(
                name: "Notifications");

            migrationBuilder.DropIndex(
                name: "IX_Messages_sellProductId",
                table: "Messages");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "0d22d701-264f-4ce6-b871-a39e71a29e07");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "52b7041c-6669-4b6f-afbd-19abcb309b45");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "da67eb8f-1627-4bb9-b433-d5e0b9fe8e02");

            migrationBuilder.DropColumn(
                name: "sellProductId",
                table: "Messages");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "2f384710-fb68-4156-bab7-c7e88a8cd5e3", "1", "Student", "Student" },
                    { "4953aadf-bcbf-4c66-be92-a141aa491edc", "4", "Alumini", "Alumini" },
                    { "7c1cae0f-c7dc-4759-9ae3-1ee15bc3e40a", "5", "Admin", "Admin" }
                });
        }
    }
}
