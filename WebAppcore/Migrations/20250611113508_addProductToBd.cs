using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebAppcore.Migrations
{
    /// <inheritdoc />
    public partial class addProductToBd : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Produits",
                columns: table => new
                {
                    Reference = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Prix = table.Column<float>(type: "real", nullable: false),
                    Qte = table.Column<int>(type: "int", nullable: false),
                    CategoryId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Produits", x => x.Reference);
                    table.ForeignKey(
                        name: "FK_Produits_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Produits",
                columns: new[] { "Reference", "CategoryId", "Prix", "Qte" },
                values: new object[] { "Pc55", 2, 5000f, 26 });

            migrationBuilder.CreateIndex(
                name: "IX_Produits_CategoryId",
                table: "Produits",
                column: "CategoryId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Produits");
        }
    }
}
