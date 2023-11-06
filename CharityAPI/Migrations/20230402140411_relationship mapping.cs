using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CharityAPI.Migrations
{
    /// <inheritdoc />
    public partial class relationshipmapping : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Donations_Charities_CharitiesId",
                table: "Donations");

            migrationBuilder.DropForeignKey(
                name: "FK_UserDonations_Donations_DonationsId",
                table: "UserDonations");

            migrationBuilder.DropForeignKey(
                name: "FK_UserDonations_Users_UsersId",
                table: "UserDonations");

            migrationBuilder.DropIndex(
                name: "IX_UserDonations_DonationsId",
                table: "UserDonations");

            migrationBuilder.DropIndex(
                name: "IX_UserDonations_UsersId",
                table: "UserDonations");

            migrationBuilder.DropIndex(
                name: "IX_Donations_CharitiesId",
                table: "Donations");

            migrationBuilder.DropColumn(
                name: "DonationsId",
                table: "UserDonations");

            migrationBuilder.DropColumn(
                name: "UsersId",
                table: "UserDonations");

            migrationBuilder.DropColumn(
                name: "CharitiesId",
                table: "Donations");

            migrationBuilder.CreateIndex(
                name: "IX_UserDonations_DonationId",
                table: "UserDonations",
                column: "DonationId");

            migrationBuilder.CreateIndex(
                name: "IX_UserDonations_UserId",
                table: "UserDonations",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Donations_CharityId",
                table: "Donations",
                column: "CharityId");

            migrationBuilder.AddForeignKey(
                name: "FK_Donations_Charity",
                table: "Donations",
                column: "CharityId",
                principalTable: "Charities",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_UserDonations_Donation",
                table: "UserDonations",
                column: "DonationId",
                principalTable: "Donations",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_UserDonations_User",
                table: "UserDonations",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Donations_Charity",
                table: "Donations");

            migrationBuilder.DropForeignKey(
                name: "FK_UserDonations_Donation",
                table: "UserDonations");

            migrationBuilder.DropForeignKey(
                name: "FK_UserDonations_User",
                table: "UserDonations");

            migrationBuilder.DropIndex(
                name: "IX_UserDonations_DonationId",
                table: "UserDonations");

            migrationBuilder.DropIndex(
                name: "IX_UserDonations_UserId",
                table: "UserDonations");

            migrationBuilder.DropIndex(
                name: "IX_Donations_CharityId",
                table: "Donations");

            migrationBuilder.AddColumn<int>(
                name: "DonationsId",
                table: "UserDonations",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "UsersId",
                table: "UserDonations",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "CharitiesId",
                table: "Donations",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_UserDonations_DonationsId",
                table: "UserDonations",
                column: "DonationsId");

            migrationBuilder.CreateIndex(
                name: "IX_UserDonations_UsersId",
                table: "UserDonations",
                column: "UsersId");

            migrationBuilder.CreateIndex(
                name: "IX_Donations_CharitiesId",
                table: "Donations",
                column: "CharitiesId");

            migrationBuilder.AddForeignKey(
                name: "FK_Donations_Charities_CharitiesId",
                table: "Donations",
                column: "CharitiesId",
                principalTable: "Charities",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserDonations_Donations_DonationsId",
                table: "UserDonations",
                column: "DonationsId",
                principalTable: "Donations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserDonations_Users_UsersId",
                table: "UserDonations",
                column: "UsersId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
