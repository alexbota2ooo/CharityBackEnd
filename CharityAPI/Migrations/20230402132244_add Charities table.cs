using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CharityAPI.Migrations
{
    /// <inheritdoc />
    public partial class addCharitiestable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Employees");

            migrationBuilder.CreateTable(
                name: "Charities",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(255)", nullable: false),
                    Contact = table.Column<string>(type: "nvarchar(255)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(MAX)", nullable: false),
                    sector = table.Column<string>(type: "nvarchar(255)", nullable: false),
                    category = table.Column<string>(type: "nvarchar(255)", nullable: false),
                    target_group = table.Column<string>(type: "nvarchar(255)", nullable: false),
                    leadership = table.Column<string>(type: "nvarchar(255)", nullable: false),
                    efficiency = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    social_responsibility_rating = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    num_favorites = table.Column<int>(type: "int", nullable: false, defaultValue: 0)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Charities", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Charities");

            migrationBuilder.CreateTable(
                name: "Employees",
                columns: table => new
                {
                    EmployeeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Designation = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EmployeeFirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EmployeeLastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Salary = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employees", x => x.EmployeeId);
                });
        }
    }
}
