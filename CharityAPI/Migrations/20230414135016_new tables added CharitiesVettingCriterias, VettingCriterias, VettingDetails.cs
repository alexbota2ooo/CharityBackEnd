using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CharityAPI.Migrations
{
    /// <inheritdoc />
    public partial class newtablesaddedCharitiesVettingCriteriasVettingCriteriasVettingDetails : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "DonationLink",
                table: "Charities",
                type: "nvarchar(MAX)",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "VettingCriterias",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(MAX)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VettingCriterias", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CharitiesVettingCriterias",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CharityId = table.Column<int>(type: "int", nullable: false),
                    VettingCriteriaId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CharitiesVettingCriterias", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CharitiesVettingCriterias_Charities_CharityId",
                        column: x => x.CharityId,
                        principalTable: "Charities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CharitiesVettingCriterias_VettingCriterias_VettingCriteriaId",
                        column: x => x.VettingCriteriaId,
                        principalTable: "VettingCriterias",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "VettingDetails",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(MAX)", nullable: false),
                    VettingCriteriaId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VettingDetails", x => x.Id);
                    table.ForeignKey(
                        name: "FK_VettingDetails_VettingCriterias_VettingCriteriaId",
                        column: x => x.VettingCriteriaId,
                        principalTable: "VettingCriterias",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CharitiesVettingCriterias_CharityId",
                table: "CharitiesVettingCriterias",
                column: "CharityId");

            migrationBuilder.CreateIndex(
                name: "IX_CharitiesVettingCriterias_VettingCriteriaId",
                table: "CharitiesVettingCriterias",
                column: "VettingCriteriaId");

            migrationBuilder.CreateIndex(
                name: "IX_VettingDetails_VettingCriteriaId",
                table: "VettingDetails",
                column: "VettingCriteriaId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CharitiesVettingCriterias");

            migrationBuilder.DropTable(
                name: "VettingDetails");

            migrationBuilder.DropTable(
                name: "VettingCriterias");

            migrationBuilder.DropColumn(
                name: "DonationLink",
                table: "Charities");
        }
    }
}
