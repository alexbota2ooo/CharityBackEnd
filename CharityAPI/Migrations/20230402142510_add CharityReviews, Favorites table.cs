using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CharityAPI.Migrations
{
    /// <inheritdoc />
    public partial class addCharityReviewsFavoritestable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CharityReviews",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CharityId = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    Rating = table.Column<int>(type: "int", nullable: false),
                    Review = table.Column<string>(type: "nvarchar(MAX)", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CharityReviews", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CharityReviews_Charity",
                        column: x => x.CharityId,
                        principalTable: "Charities",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_CharityReviews_User",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Favorites",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    CharityId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Favorites", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Favorites_Charity",
                        column: x => x.CharityId,
                        principalTable: "Charities",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Favorites_User",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_CharityReviews_CharityId",
                table: "CharityReviews",
                column: "CharityId");

            migrationBuilder.CreateIndex(
                name: "IX_CharityReviews_UserId",
                table: "CharityReviews",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Favorites_CharityId",
                table: "Favorites",
                column: "CharityId");

            migrationBuilder.CreateIndex(
                name: "IX_Favorites_UserId",
                table: "Favorites",
                column: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CharityReviews");

            migrationBuilder.DropTable(
                name: "Favorites");
        }
    }
}
