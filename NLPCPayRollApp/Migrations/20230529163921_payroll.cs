using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NLPCPayRollApp.Migrations
{
    /// <inheritdoc />
    public partial class payroll : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CadreLevels",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CadreLevels", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Employees",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Designation = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CadreLevelName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employees", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PayrollComponents",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BasicSalary = table.Column<double>(type: "float", nullable: false),
                    Housing = table.Column<double>(type: "float", nullable: false),
                    Transport = table.Column<double>(type: "float", nullable: false),
                    Furniture = table.Column<double>(type: "float", nullable: false),
                    Entertainment = table.Column<double>(type: "float", nullable: false),
                    Lunch = table.Column<double>(type: "float", nullable: false),
                    Passage = table.Column<double>(type: "float", nullable: false),
                    Dressing = table.Column<double>(type: "float", nullable: false),
                    Bonus = table.Column<double>(type: "float", nullable: false),
                    ThirteenthMonth = table.Column<double>(type: "float", nullable: false),
                    Utility = table.Column<double>(type: "float", nullable: false),
                    OtherAllowances = table.Column<double>(type: "float", nullable: false),
                    NHF = table.Column<double>(type: "float", nullable: false),
                    NHIS = table.Column<double>(type: "float", nullable: false),
                    NPS = table.Column<double>(type: "float", nullable: false),
                    LifeAssurance = table.Column<double>(type: "float", nullable: false),
                    GrossIncome = table.Column<double>(type: "float", nullable: false),
                    TaxPayable = table.Column<double>(type: "float", nullable: false),
                    CadreLevelId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PayrollComponents", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PayrollComponents_CadreLevels_CadreLevelId",
                        column: x => x.CadreLevelId,
                        principalTable: "CadreLevels",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PayrollComponents_CadreLevelId",
                table: "PayrollComponents",
                column: "CadreLevelId",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Employees");

            migrationBuilder.DropTable(
                name: "PayrollComponents");

            migrationBuilder.DropTable(
                name: "CadreLevels");
        }
    }
}
