using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebAppcore.Migrations
{
    /// <inheritdoc />
    public partial class ModifTabl : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Path",
                table: "Produits",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "Produits",
                keyColumn: "Reference",
                keyValue: "Pc55",
                column: "Path",
                value: "C:/Users/regai/Downloads/richman book.jpg");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                column: "DateNaissance",
                value: new DateTime(2025, 6, 16, 0, 0, 0, 0, DateTimeKind.Local));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Path",
                table: "Produits");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                column: "DateNaissance",
                value: new DateTime(2025, 6, 15, 0, 0, 0, 0, DateTimeKind.Local));
        }
    }
}
