using Microsoft.EntityFrameworkCore.Migrations;

namespace StudentOffice.Migrations
{
    public partial class FiDB : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Group_Timetable_TimetableId",
                table: "Group");

            migrationBuilder.DropIndex(
                name: "IX_Group_TimetableId",
                table: "Group");

            migrationBuilder.DropColumn(
                name: "TimetableId",
                table: "Group");

            migrationBuilder.AddColumn<bool>(
                name: "FirstHalf",
                table: "TimeWindow",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "SecondHalf",
                table: "TimeWindow",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "GroupId",
                table: "Timetable",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Timetable_GroupId",
                table: "Timetable",
                column: "GroupId");

            migrationBuilder.AddForeignKey(
                name: "FK_Timetable_Group_GroupId",
                table: "Timetable",
                column: "GroupId",
                principalTable: "Group",
                principalColumn: "GroupId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Timetable_Group_GroupId",
                table: "Timetable");

            migrationBuilder.DropIndex(
                name: "IX_Timetable_GroupId",
                table: "Timetable");

            migrationBuilder.DropColumn(
                name: "FirstHalf",
                table: "TimeWindow");

            migrationBuilder.DropColumn(
                name: "SecondHalf",
                table: "TimeWindow");

            migrationBuilder.DropColumn(
                name: "GroupId",
                table: "Timetable");

            migrationBuilder.AddColumn<int>(
                name: "TimetableId",
                table: "Group",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Group_TimetableId",
                table: "Group",
                column: "TimetableId");

            migrationBuilder.AddForeignKey(
                name: "FK_Group_Timetable_TimetableId",
                table: "Group",
                column: "TimetableId",
                principalTable: "Timetable",
                principalColumn: "TimetableId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
