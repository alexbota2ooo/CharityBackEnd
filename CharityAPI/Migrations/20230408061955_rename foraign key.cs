using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CharityAPI.Migrations
{
    /// <inheritdoc />
    public partial class renameforaignkey : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CausesCharities_Causes_CausesId",
                table: "CausesCharities");

            migrationBuilder.RenameColumn(
                name: "CausesId",
                table: "CausesCharities",
                newName: "CauseId");

            migrationBuilder.RenameIndex(
                name: "IX_CausesCharities_CausesId",
                table: "CausesCharities",
                newName: "IX_CausesCharities_CauseId");

            migrationBuilder.AddForeignKey(
                name: "FK_CausesCharities_Causes_CauseId",
                table: "CausesCharities",
                column: "CauseId",
                principalTable: "Causes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CausesCharities_Causes_CauseId",
                table: "CausesCharities");

            migrationBuilder.RenameColumn(
                name: "CauseId",
                table: "CausesCharities",
                newName: "CausesId");

            migrationBuilder.RenameIndex(
                name: "IX_CausesCharities_CauseId",
                table: "CausesCharities",
                newName: "IX_CausesCharities_CausesId");

            migrationBuilder.AddForeignKey(
                name: "FK_CausesCharities_Causes_CausesId",
                table: "CausesCharities",
                column: "CausesId",
                principalTable: "Causes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
