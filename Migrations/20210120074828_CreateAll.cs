using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace StudentOffice.Migrations
{
    public partial class CreateAll : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Anketa",
                columns: table => new
                {
                    AnketaId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Surname = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Middlename = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SurnameR = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NameR = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MiddlenameR = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Birthday = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Sex = table.Column<int>(type: "int", nullable: false),
                    DocumentType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IdentityNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PassportSeries = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PassportNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DateOfIssue = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateOfValidity = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IssuedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PlaceOfBirth = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Postcode = table.Column<int>(type: "int", nullable: false),
                    Region = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TypeOfSettlement = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NameOfSettlement = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StreetType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StreetName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    HouseNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    HullNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ApartmentNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    HomePhone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SocialBehavior = table.Column<bool>(type: "bit", nullable: false),
                    KinshipTypeFather = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SurnameFather = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NameFather = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MiddlenameFather = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AddressFather = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    KinshipTypeMother = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SurnameMother = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NameMother = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MiddlenameMother = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AddressMother = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EducationLevel = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Institution = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    YearOfEnding = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Branch = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Specialty = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PlaceOfWorkAndPosition = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SeniorityGeneral = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SeniorityProfileSpecialty = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Anketa", x => x.AnketaId);
                });

            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RoleId = table.Column<int>(type: "int", nullable: true),
                    AnketaId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.id);
                    table.ForeignKey(
                        name: "FK_Users_Anketa_AnketaId",
                        column: x => x.AnketaId,
                        principalTable: "Anketa",
                        principalColumn: "AnketaId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Users_Roles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Roles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "admin" },
                    { 2, "user" },
                    { 3, "student" },
                    { 4, "teacher" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "id", "AnketaId", "Email", "Password", "RoleId" },
                values: new object[] { 1, null, "admin@mail.ru", "12345", 1 });

            migrationBuilder.CreateIndex(
                name: "IX_Users_AnketaId",
                table: "Users",
                column: "AnketaId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_RoleId",
                table: "Users",
                column: "RoleId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Anketa");

            migrationBuilder.DropTable(
                name: "Roles");
        }
    }
}
