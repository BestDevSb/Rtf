using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace RtfWebApp.Migrations
{
    public partial class solutionskills : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EmployeeSolutions_Solutions_SolutionId",
                table: "EmployeeSolutions");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Solutions",
                table: "Solutions");

            migrationBuilder.RenameTable(
                name: "Solutions",
                newName: "Solution");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Solution",
                table: "Solution",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "SolutionsSkills",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    SolutionId = table.Column<int>(nullable: false),
                    SkilId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SolutionsSkills", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SolutionsSkills_Skills_SkilId",
                        column: x => x.SkilId,
                        principalTable: "Skills",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SolutionsSkills_Solution_SolutionId",
                        column: x => x.SolutionId,
                        principalTable: "Solution",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_SolutionsSkills_SkilId",
                table: "SolutionsSkills",
                column: "SkilId");

            migrationBuilder.CreateIndex(
                name: "IX_SolutionsSkills_SolutionId",
                table: "SolutionsSkills",
                column: "SolutionId");

            migrationBuilder.AddForeignKey(
                name: "FK_EmployeeSolutions_Solution_SolutionId",
                table: "EmployeeSolutions",
                column: "SolutionId",
                principalTable: "Solution",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EmployeeSolutions_Solution_SolutionId",
                table: "EmployeeSolutions");

            migrationBuilder.DropTable(
                name: "SolutionsSkills");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Solution",
                table: "Solution");

            migrationBuilder.RenameTable(
                name: "Solution",
                newName: "Solutions");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Solutions",
                table: "Solutions",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_EmployeeSolutions_Solutions_SolutionId",
                table: "EmployeeSolutions",
                column: "SolutionId",
                principalTable: "Solutions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
