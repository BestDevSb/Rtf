using Microsoft.EntityFrameworkCore.Migrations;

namespace RtfWebApp.Migrations
{
    public partial class initial2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Ratings_Skills_SkilId",
                table: "Ratings");

            migrationBuilder.RenameColumn(
                name: "SkilId",
                table: "Ratings",
                newName: "SkillId");

            migrationBuilder.RenameIndex(
                name: "IX_Ratings_SkilId",
                table: "Ratings",
                newName: "IX_Ratings_SkillId");

            migrationBuilder.AddForeignKey(
                name: "FK_Ratings_Skills_SkillId",
                table: "Ratings",
                column: "SkillId",
                principalTable: "Skills",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Ratings_Skills_SkillId",
                table: "Ratings");

            migrationBuilder.RenameColumn(
                name: "SkillId",
                table: "Ratings",
                newName: "SkilId");

            migrationBuilder.RenameIndex(
                name: "IX_Ratings_SkillId",
                table: "Ratings",
                newName: "IX_Ratings_SkilId");

            migrationBuilder.AddForeignKey(
                name: "FK_Ratings_Skills_SkilId",
                table: "Ratings",
                column: "SkilId",
                principalTable: "Skills",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
