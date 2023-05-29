using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NLPCPayRollApp.Migrations
{
    /// <inheritdoc />
    public partial class Payroll : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PayrollComponents",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BasicSalary = table.Column<int>(type: "int", nullable: false),
                    Housing = table.Column<int>(type: "int", nullable: false),
                    Transport = table.Column<int>(type: "int", nullable: false),
                    Furniture = table.Column<int>(type: "int", nullable: false),
                    Entertainment = table.Column<int>(type: "int", nullable: false),
                    Lunch = table.Column<int>(type: "int", nullable: false),
                    Passage = table.Column<int>(type: "int", nullable: false),
                    Dressing = table.Column<int>(type: "int", nullable: false),
                    Bonus = table.Column<int>(type: "int", nullable: false),
                    ThirteenthMonth = table.Column<int>(type: "int", nullable: false),
                    Utility = table.Column<int>(type: "int", nullable: false),
                    OtherAllowances = table.Column<int>(type: "int", nullable: false),
                    NHF = table.Column<int>(type: "int", nullable: false),
                    NHIS = table.Column<int>(type: "int", nullable: false),
                    NPS = table.Column<int>(type: "int", nullable: false),
                    LifeAssurance = table.Column<int>(type: "int", nullable: false),
                    GrossIncome = table.Column<int>(type: "int", nullable: false),
                    TaxPayable = table.Column<int>(type: "int", nullable: false),
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
                name: "PayrollComponents");
        }
    }
}
