using Microsoft.EntityFrameworkCore.Migrations;

namespace StudentOffice.Migrations
{
    public partial class UpdateBD : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Groups_Specialties_SpecialtyId",
                table: "Groups");

            migrationBuilder.DropForeignKey(
                name: "FK_Specializations_Specialties_SpecialtyId",
                table: "Specializations");

            migrationBuilder.DropIndex(
                name: "IX_Specializations_SpecialtyId",
                table: "Specializations");

            migrationBuilder.DropIndex(
                name: "IX_Groups_SpecialtyId",
                table: "Groups");

            migrationBuilder.DropColumn(
                name: "SpecialtyId",
                table: "Specializations");

            migrationBuilder.DropColumn(
                name: "SpecialtyId",
                table: "Groups");

            migrationBuilder.AddColumn<int>(
                name: "GroupId",
                table: "Specialties",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "SpecializationId",
                table: "Specialties",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Specialties_GroupId",
                table: "Specialties",
                column: "GroupId");

            migrationBuilder.CreateIndex(
                name: "IX_Specialties_SpecializationId",
                table: "Specialties",
                column: "SpecializationId");

            migrationBuilder.AddForeignKey(
                name: "FK_Specialties_Groups_GroupId",
                table: "Specialties",
                column: "GroupId",
                principalTable: "Groups",
                principalColumn: "GroupId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Specialties_Specializations_SpecializationId",
                table: "Specialties",
                column: "SpecializationId",
                principalTable: "Specializations",
                principalColumn: "SpecializationId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Specialties_Groups_GroupId",
                table: "Specialties");

            migrationBuilder.DropForeignKey(
                name: "FK_Specialties_Specializations_SpecializationId",
                table: "Specialties");

            migrationBuilder.DropIndex(
                name: "IX_Specialties_GroupId",
                table: "Specialties");

            migrationBuilder.DropIndex(
                name: "IX_Specialties_SpecializationId",
                table: "Specialties");

            migrationBuilder.DropColumn(
                name: "GroupId",
                table: "Specialties");

            migrationBuilder.DropColumn(
                name: "SpecializationId",
                table: "Specialties");

            migrationBuilder.AddColumn<int>(
                name: "SpecialtyId",
                table: "Specializations",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "SpecialtyId",
                table: "Groups",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Specializations_SpecialtyId",
                table: "Specializations",
                column: "SpecialtyId");

            migrationBuilder.CreateIndex(
                name: "IX_Groups_SpecialtyId",
                table: "Groups",
                column: "SpecialtyId");

            migrationBuilder.AddForeignKey(
                name: "FK_Groups_Specialties_SpecialtyId",
                table: "Groups",
                column: "SpecialtyId",
                principalTable: "Specialties",
                principalColumn: "SpecialtyId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Specializations_Specialties_SpecialtyId",
                table: "Specializations",
                column: "SpecialtyId",
                principalTable: "Specialties",
                principalColumn: "SpecialtyId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
