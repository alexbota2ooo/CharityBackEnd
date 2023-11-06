using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CharityAPI.Migrations
{
    /// <inheritdoc />
    public partial class Charityupdatefundraising : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Category",
                table: "Charities");

            migrationBuilder.RenameColumn(
                name: "Sector",
                table: "Charities",
                newName: "Website");

            migrationBuilder.RenameColumn(
                name: "Contact",
                table: "Charities",
                newName: "Cause");

            migrationBuilder.AlterColumn<string>(
                name: "TargetGroup",
                table: "Charities",
                type: "nvarchar(255)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(255)");

            migrationBuilder.AlterColumn<string>(
                name: "Leadership",
                table: "Charities",
                type: "nvarchar(255)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(255)");

            migrationBuilder.AlterColumn<string>(
                name: "ImageUrl",
                table: "Charities",
                type: "nvarchar(MAX)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(MAX)");

            migrationBuilder.AddColumn<string>(
                name: "AnnualReportLink",
                table: "Charities",
                type: "nvarchar(255)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Financials",
                table: "Charities",
                type: "nvarchar(MAX)",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsFeatured",
                table: "Charities",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "LeadershipDescription",
                table: "Charities",
                type: "nvarchar(MAX)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Mail",
                table: "Charities",
                type: "varchar(255)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PhoneNumber",
                table: "Charities",
                type: "varchar(255)",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "Vetted",
                table: "Charities",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.CreateTable(
                name: "CharityProgram",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Type = table.Column<string>(type: "nvarchar(255)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(MAX)", nullable: false),
                    CharityId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CharityProgram", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CharityProgram_Charities_CharityId",
                        column: x => x.CharityId,
                        principalTable: "Charities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CharityProgram_CharityId",
                table: "CharityProgram",
                column: "CharityId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CharityProgram");

            migrationBuilder.DropColumn(
                name: "AnnualReportLink",
                table: "Charities");

            migrationBuilder.DropColumn(
                name: "Financials",
                table: "Charities");

            migrationBuilder.DropColumn(
                name: "IsFeatured",
                table: "Charities");

            migrationBuilder.DropColumn(
                name: "LeadershipDescription",
                table: "Charities");

            migrationBuilder.DropColumn(
                name: "Mail",
                table: "Charities");

            migrationBuilder.DropColumn(
                name: "PhoneNumber",
                table: "Charities");

            migrationBuilder.DropColumn(
                name: "Vetted",
                table: "Charities");

            migrationBuilder.RenameColumn(
                name: "Website",
                table: "Charities",
                newName: "Sector");

            migrationBuilder.RenameColumn(
                name: "Cause",
                table: "Charities",
                newName: "Contact");

            migrationBuilder.AlterColumn<string>(
                name: "TargetGroup",
                table: "Charities",
                type: "nvarchar(255)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(255)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Leadership",
                table: "Charities",
                type: "nvarchar(255)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(255)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ImageUrl",
                table: "Charities",
                type: "nvarchar(MAX)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(MAX)",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Category",
                table: "Charities",
                type: "nvarchar(255)",
                nullable: false,
                defaultValue: "");
        }
    }
}
