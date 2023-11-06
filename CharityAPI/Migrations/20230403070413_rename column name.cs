using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CharityAPI.Migrations
{
    /// <inheritdoc />
    public partial class renamecolumnname : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "sector",
                table: "Charities",
                newName: "Sector");

            migrationBuilder.RenameColumn(
                name: "leadership",
                table: "Charities",
                newName: "Leadership");

            migrationBuilder.RenameColumn(
                name: "efficiency",
                table: "Charities",
                newName: "Efficiency");

            migrationBuilder.RenameColumn(
                name: "category",
                table: "Charities",
                newName: "Category");

            migrationBuilder.RenameColumn(
                name: "target_group",
                table: "Charities",
                newName: "TargetGroup");

            migrationBuilder.RenameColumn(
                name: "social_responsibility_rating",
                table: "Charities",
                newName: "SocialResponsibilityRating");

            migrationBuilder.RenameColumn(
                name: "num_favorites",
                table: "Charities",
                newName: "NumFavorites");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Sector",
                table: "Charities",
                newName: "sector");

            migrationBuilder.RenameColumn(
                name: "Leadership",
                table: "Charities",
                newName: "leadership");

            migrationBuilder.RenameColumn(
                name: "Efficiency",
                table: "Charities",
                newName: "efficiency");

            migrationBuilder.RenameColumn(
                name: "Category",
                table: "Charities",
                newName: "category");

            migrationBuilder.RenameColumn(
                name: "TargetGroup",
                table: "Charities",
                newName: "target_group");

            migrationBuilder.RenameColumn(
                name: "SocialResponsibilityRating",
                table: "Charities",
                newName: "social_responsibility_rating");

            migrationBuilder.RenameColumn(
                name: "NumFavorites",
                table: "Charities",
                newName: "num_favorites");
        }
    }
}
