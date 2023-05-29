using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NLPCPayRollApp.Migrations
{
    /// <inheritdoc />
    public partial class cadrelevelname : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CadreLevelId",
                table: "Employees");

            migrationBuilder.AddColumn<string>(
                name: "CadreLevelName",
                table: "Employees",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CadreLevelName",
                table: "Employees");

            migrationBuilder.AddColumn<int>(
                name: "CadreLevelId",
                table: "Employees",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
