using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CharityAPI.Migrations
{
    /// <inheritdoc />
    public partial class newcolumnImageUrladdedincharitytable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ImageUrl",
                table: "Charities",
                type: "nvarchar(MAX)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImageUrl",
                table: "Charities");
        }
    }
}
