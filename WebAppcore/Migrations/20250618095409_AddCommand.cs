using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebAppcore.Migrations
{
    /// <inheritdoc />
    public partial class AddCommand : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
			migrationBuilder.CreateTable(
				name: "Commands",
				columns: table => new
				{
					Id = table.Column<int>(type: "int", nullable: false)
						.Annotation("SqlServer:Identity", "1, 1"),
					OrderDate = table.Column<DateTime>(type: "datetime2", nullable: false),
					OrderedQuantity = table.Column<int>(type: "int", nullable: false),
					ProductReference = table.Column<string>(type: "nvarchar(450)", nullable: false),
					TotalPrice = table.Column<float>(type: "real", nullable: false)
				},
				constraints: table =>
				{
					table.PrimaryKey("PK_Commands", x => x.Id);
					table.ForeignKey(
						name: "FK_Commands_Produits_ProductReference",
						column: x => x.ProductReference,
						principalTable: "Produits",
						principalColumn: "Reference",
						onDelete: ReferentialAction.Cascade);
				});
			migrationBuilder.DeleteData(
                table: "Commands",
                keyColumn: "Id",
                keyValue: 1);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
			migrationBuilder.CreateTable(
				name: "Commands",
				columns: table => new
				{
					Id = table.Column<int>(type: "int", nullable: false)
						.Annotation("SqlServer:Identity", "1, 1"),
					OrderDate = table.Column<DateTime>(type: "datetime2", nullable: false),
					OrderedQuantity = table.Column<int>(type: "int", nullable: false),
					ProductReference = table.Column<string>(type: "nvarchar(450)", nullable: false),
					TotalPrice = table.Column<float>(type: "real", nullable: false)
				},
				constraints: table =>
				{
					table.PrimaryKey("PK_Commands", x => x.Id);
					table.ForeignKey(
						name: "FK_Commands_Produits_ProductReference",
						column: x => x.ProductReference,
						principalTable: "Produits",
						principalColumn: "Reference",
						onDelete: ReferentialAction.Cascade);
				});
			migrationBuilder.InsertData(
                table: "Commands",
                columns: new[] { "Id", "OrderDate", "OrderedQuantity", "ProductReference", "TotalPrice" },
                values: new object[] { 1, new DateTime(2025, 6, 18, 10, 51, 31, 727, DateTimeKind.Local).AddTicks(3576), 5, "PROD001", 99.95f });
        }
    }
}
