using Microsoft.EntityFrameworkCore.Migrations;

namespace RtfWebApp.Migrations
{
    public partial class skiLLfix : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Achivments_Skills_SkilId",
                table: "Achivments");

            migrationBuilder.DropForeignKey(
                name: "FK_ProfileSkils_Skills_SkilId",
                table: "ProfileSkils");

            migrationBuilder.DropForeignKey(
                name: "FK_SkillDependencies_Skills_SkilAId",
                table: "SkillDependencies");

            migrationBuilder.DropForeignKey(
                name: "FK_SkillDependencies_Skills_SkilBId",
                table: "SkillDependencies");

            migrationBuilder.DropForeignKey(
                name: "FK_SolutionsSkills_Skills_SkilId",
                table: "SolutionsSkills");

            migrationBuilder.RenameColumn(
                name: "SkilId",
                table: "SolutionsSkills",
                newName: "SkillId");

            migrationBuilder.RenameIndex(
                name: "IX_SolutionsSkills_SkilId",
                table: "SolutionsSkills",
                newName: "IX_SolutionsSkills_SkillId");

            migrationBuilder.RenameColumn(
                name: "SkilBId",
                table: "SkillDependencies",
                newName: "SkillBId");

            migrationBuilder.RenameColumn(
                name: "SkilAId",
                table: "SkillDependencies",
                newName: "SkillAId");

            migrationBuilder.RenameIndex(
                name: "IX_SkillDependencies_SkilBId",
                table: "SkillDependencies",
                newName: "IX_SkillDependencies_SkillBId");

            migrationBuilder.RenameIndex(
                name: "IX_SkillDependencies_SkilAId",
                table: "SkillDependencies",
                newName: "IX_SkillDependencies_SkillAId");

            migrationBuilder.RenameColumn(
                name: "SkilId",
                table: "ProfileSkils",
                newName: "SkillId");

            migrationBuilder.RenameIndex(
                name: "IX_ProfileSkils_SkilId",
                table: "ProfileSkils",
                newName: "IX_ProfileSkils_SkillId");

            migrationBuilder.RenameColumn(
                name: "SkilId",
                table: "Achivments",
                newName: "SkillId");

            migrationBuilder.RenameIndex(
                name: "IX_Achivments_SkilId",
                table: "Achivments",
                newName: "IX_Achivments_SkillId");

            migrationBuilder.AddForeignKey(
                name: "FK_Achivments_Skills_SkillId",
                table: "Achivments",
                column: "SkillId",
                principalTable: "Skills",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ProfileSkils_Skills_SkillId",
                table: "ProfileSkils",
                column: "SkillId",
                principalTable: "Skills",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SkillDependencies_Skills_SkillAId",
                table: "SkillDependencies",
                column: "SkillAId",
                principalTable: "Skills",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_SkillDependencies_Skills_SkillBId",
                table: "SkillDependencies",
                column: "SkillBId",
                principalTable: "Skills",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_SolutionsSkills_Skills_SkillId",
                table: "SolutionsSkills",
                column: "SkillId",
                principalTable: "Skills",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Achivments_Skills_SkillId",
                table: "Achivments");

            migrationBuilder.DropForeignKey(
                name: "FK_ProfileSkils_Skills_SkillId",
                table: "ProfileSkils");

            migrationBuilder.DropForeignKey(
                name: "FK_SkillDependencies_Skills_SkillAId",
                table: "SkillDependencies");

            migrationBuilder.DropForeignKey(
                name: "FK_SkillDependencies_Skills_SkillBId",
                table: "SkillDependencies");

            migrationBuilder.DropForeignKey(
                name: "FK_SolutionsSkills_Skills_SkillId",
                table: "SolutionsSkills");

            migrationBuilder.RenameColumn(
                name: "SkillId",
                table: "SolutionsSkills",
                newName: "SkilId");

            migrationBuilder.RenameIndex(
                name: "IX_SolutionsSkills_SkillId",
                table: "SolutionsSkills",
                newName: "IX_SolutionsSkills_SkilId");

            migrationBuilder.RenameColumn(
                name: "SkillBId",
                table: "SkillDependencies",
                newName: "SkilBId");

            migrationBuilder.RenameColumn(
                name: "SkillAId",
                table: "SkillDependencies",
                newName: "SkilAId");

            migrationBuilder.RenameIndex(
                name: "IX_SkillDependencies_SkillBId",
                table: "SkillDependencies",
                newName: "IX_SkillDependencies_SkilBId");

            migrationBuilder.RenameIndex(
                name: "IX_SkillDependencies_SkillAId",
                table: "SkillDependencies",
                newName: "IX_SkillDependencies_SkilAId");

            migrationBuilder.RenameColumn(
                name: "SkillId",
                table: "ProfileSkils",
                newName: "SkilId");

            migrationBuilder.RenameIndex(
                name: "IX_ProfileSkils_SkillId",
                table: "ProfileSkils",
                newName: "IX_ProfileSkils_SkilId");

            migrationBuilder.RenameColumn(
                name: "SkillId",
                table: "Achivments",
                newName: "SkilId");

            migrationBuilder.RenameIndex(
                name: "IX_Achivments_SkillId",
                table: "Achivments",
                newName: "IX_Achivments_SkilId");

            migrationBuilder.AddForeignKey(
                name: "FK_Achivments_Skills_SkilId",
                table: "Achivments",
                column: "SkilId",
                principalTable: "Skills",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ProfileSkils_Skills_SkilId",
                table: "ProfileSkils",
                column: "SkilId",
                principalTable: "Skills",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SkillDependencies_Skills_SkilAId",
                table: "SkillDependencies",
                column: "SkilAId",
                principalTable: "Skills",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_SkillDependencies_Skills_SkilBId",
                table: "SkillDependencies",
                column: "SkilBId",
                principalTable: "Skills",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_SolutionsSkills_Skills_SkilId",
                table: "SolutionsSkills",
                column: "SkilId",
                principalTable: "Skills",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
