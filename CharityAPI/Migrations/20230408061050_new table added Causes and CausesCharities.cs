using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CharityAPI.Migrations
{
    /// <inheritdoc />
    public partial class newtableaddedCausesandCausesCharities : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Causes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(255)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(MAX)", nullable: false),
                    ImageUrl = table.Column<string>(type: "nvarchar(MAX)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Causes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CausesCharities",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CausesId = table.Column<int>(type: "int", nullable: false),
                    CharityId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CausesCharities", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CausesCharities_Causes_CausesId",
                        column: x => x.CausesId,
                        principalTable: "Causes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CausesCharities_Charities_CharityId",
                        column: x => x.CharityId,
                        principalTable: "Charities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CausesCharities_CausesId",
                table: "CausesCharities",
                column: "CausesId");

            migrationBuilder.CreateIndex(
                name: "IX_CausesCharities_CharityId",
                table: "CausesCharities",
                column: "CharityId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CausesCharities");

            migrationBuilder.DropTable(
                name: "Causes");
        }
    }
}
