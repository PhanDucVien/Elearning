using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Elearning.Migrations
{
    public partial class Elearning : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Format",
                columns: table => new
                {
                    FormatId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Format", x => x.FormatId);
                });

            migrationBuilder.CreateTable(
                name: "Myclass",
                columns: table => new
                {
                    MyclassId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Myclass", x => x.MyclassId);
                });

            migrationBuilder.CreateTable(
                name: "Subject",
                columns: table => new
                {
                    SubjectId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Nest = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Subject", x => x.SubjectId);
                });

            migrationBuilder.CreateTable(
                name: "Student",
                columns: table => new
                {
                    StudentId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    username = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Gmail = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Gender = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Dateofbirth = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Schoolyear = table.Column<DateTime>(type: "datetime2", nullable: false),
                    MyclassId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Student", x => x.StudentId);
                    table.ForeignKey(
                        name: "FK_Student_Myclass_MyclassId",
                        column: x => x.MyclassId,
                        principalTable: "Myclass",
                        principalColumn: "MyclassId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Teacher",
                columns: table => new
                {
                    TeacherId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PassWord = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SubjectId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Teacher", x => x.TeacherId);
                    table.ForeignKey(
                        name: "FK_Teacher_Subject_SubjectId",
                        column: x => x.SubjectId,
                        principalTable: "Subject",
                        principalColumn: "SubjectId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TakeClass",
                columns: table => new
                {
                    TakeClassId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Topic = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Workingtime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Startdate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Enddate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Security = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Link = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MyclassId = table.Column<int>(type: "int", nullable: false),
                    TeacherId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TakeClass", x => x.TakeClassId);
                    table.ForeignKey(
                        name: "FK_TakeClass_Myclass_MyclassId",
                        column: x => x.MyclassId,
                        principalTable: "Myclass",
                        principalColumn: "MyclassId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TakeClass_Teacher_TeacherId",
                        column: x => x.TeacherId,
                        principalTable: "Teacher",
                        principalColumn: "TeacherId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Test",
                columns: table => new
                {
                    TestId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Topic = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Workingtime = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Classify = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Startdate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Enddate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AttachTeacher = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AttachStudent = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Comment = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TeacherId = table.Column<int>(type: "int", nullable: false),
                    StudentId = table.Column<int>(type: "int", nullable: false),
                    FormatId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Test", x => x.TestId);
                    table.ForeignKey(
                        name: "FK_Test_Format_FormatId",
                        column: x => x.FormatId,
                        principalTable: "Format",
                        principalColumn: "FormatId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Test_Student_StudentId",
                        column: x => x.StudentId,
                        principalTable: "Student",
                        principalColumn: "StudentId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Test_Teacher_TeacherId",
                        column: x => x.TeacherId,
                        principalTable: "Teacher",
                        principalColumn: "TeacherId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Student_MyclassId",
                table: "Student",
                column: "MyclassId");

            migrationBuilder.CreateIndex(
                name: "IX_TakeClass_MyclassId",
                table: "TakeClass",
                column: "MyclassId");

            migrationBuilder.CreateIndex(
                name: "IX_TakeClass_TeacherId",
                table: "TakeClass",
                column: "TeacherId");

            migrationBuilder.CreateIndex(
                name: "IX_Teacher_SubjectId",
                table: "Teacher",
                column: "SubjectId");

            migrationBuilder.CreateIndex(
                name: "IX_Test_FormatId",
                table: "Test",
                column: "FormatId");

            migrationBuilder.CreateIndex(
                name: "IX_Test_StudentId",
                table: "Test",
                column: "StudentId");

            migrationBuilder.CreateIndex(
                name: "IX_Test_TeacherId",
                table: "Test",
                column: "TeacherId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TakeClass");

            migrationBuilder.DropTable(
                name: "Test");

            migrationBuilder.DropTable(
                name: "Format");

            migrationBuilder.DropTable(
                name: "Student");

            migrationBuilder.DropTable(
                name: "Teacher");

            migrationBuilder.DropTable(
                name: "Myclass");

            migrationBuilder.DropTable(
                name: "Subject");
        }
    }
}
