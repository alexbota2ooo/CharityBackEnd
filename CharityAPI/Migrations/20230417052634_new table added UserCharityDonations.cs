using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CharityAPI.Migrations
{
    /// <inheritdoc />
    public partial class newtableaddedUserCharityDonations : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UserDonations");

            migrationBuilder.DropTable(
                name: "Donations");

            migrationBuilder.CreateTable(
                name: "UserCharityDonations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    CharityId = table.Column<int>(type: "int", nullable: false),
                    Amount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    DonationDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserCharityDonations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserCharityDonations_Charities_CharityId",
                        column: x => x.CharityId,
                        principalTable: "Charities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserCharityDonations_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_UserCharityDonations_CharityId",
                table: "UserCharityDonations",
                column: "CharityId");

            migrationBuilder.CreateIndex(
                name: "IX_UserCharityDonations_UserId",
                table: "UserCharityDonations",
                column: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UserCharityDonations");

            migrationBuilder.CreateTable(
                name: "Donations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CharityId = table.Column<int>(type: "int", nullable: false),
                    Amount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Donations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Donations_Charity",
                        column: x => x.CharityId,
                        principalTable: "Charities",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "UserDonations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DonationId = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserDonations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserDonations_Donation",
                        column: x => x.DonationId,
                        principalTable: "Donations",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_UserDonations_User",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Donations_CharityId",
                table: "Donations",
                column: "CharityId");

            migrationBuilder.CreateIndex(
                name: "IX_UserDonations_DonationId",
                table: "UserDonations",
                column: "DonationId");

            migrationBuilder.CreateIndex(
                name: "IX_UserDonations_UserId",
                table: "UserDonations",
                column: "UserId");
        }
    }
}
