using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Attendace_Std.Migrations
{
    /// <inheritdoc />
    public partial class insall : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "factories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_factories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "levels",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_levels", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "specializations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_specializations", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "supervisors",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_supervisors", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Students",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EmailAddress = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Repassword = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Level_id = table.Column<int>(type: "int", nullable: false),
                    Specialization_id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Students", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Students_levels_Level_id",
                        column: x => x.Level_id,
                        principalTable: "levels",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Students_specializations_Specialization_id",
                        column: x => x.Specialization_id,
                        principalTable: "specializations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "std_Factories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    stdId = table.Column<int>(type: "int", nullable: false),
                    facId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_std_Factories", x => x.Id);
                    table.ForeignKey(
                        name: "FK_std_Factories_Students_stdId",
                        column: x => x.stdId,
                        principalTable: "Students",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_std_Factories_factories_facId",
                        column: x => x.facId,
                        principalTable: "factories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "std_Supervisors",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    stdId = table.Column<int>(type: "int", nullable: false),
                    suberId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_std_Supervisors", x => x.Id);
                    table.ForeignKey(
                        name: "FK_std_Supervisors_Students_stdId",
                        column: x => x.stdId,
                        principalTable: "Students",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_std_Supervisors_supervisors_suberId",
                        column: x => x.suberId,
                        principalTable: "supervisors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "student_attendaces",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    Student_Id = table.Column<int>(type: "int", nullable: false),
                    DateOnly = table.Column<DateTime>(type: "datetime2", nullable: false),
                    fac_id = table.Column<int>(type: "int", nullable: false),
                    Supervisor_id = table.Column<int>(type: "int", nullable: false),
                    Location = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_student_attendaces", x => new { x.Id, x.Student_Id, x.DateOnly });
                    table.ForeignKey(
                        name: "FK_student_attendaces_Students_Student_Id",
                        column: x => x.Student_Id,
                        principalTable: "Students",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_student_attendaces_factories_fac_id",
                        column: x => x.fac_id,
                        principalTable: "factories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_student_attendaces_supervisors_Supervisor_id",
                        column: x => x.Supervisor_id,
                        principalTable: "supervisors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_std_Factories_facId",
                table: "std_Factories",
                column: "facId");

            migrationBuilder.CreateIndex(
                name: "IX_std_Factories_stdId",
                table: "std_Factories",
                column: "stdId");

            migrationBuilder.CreateIndex(
                name: "IX_std_Supervisors_stdId",
                table: "std_Supervisors",
                column: "stdId");

            migrationBuilder.CreateIndex(
                name: "IX_std_Supervisors_suberId",
                table: "std_Supervisors",
                column: "suberId");

            migrationBuilder.CreateIndex(
                name: "IX_student_attendaces_fac_id",
                table: "student_attendaces",
                column: "fac_id");

            migrationBuilder.CreateIndex(
                name: "IX_student_attendaces_Student_Id",
                table: "student_attendaces",
                column: "Student_Id");

            migrationBuilder.CreateIndex(
                name: "IX_student_attendaces_Supervisor_id",
                table: "student_attendaces",
                column: "Supervisor_id");

            migrationBuilder.CreateIndex(
                name: "IX_Students_Level_id",
                table: "Students",
                column: "Level_id");

            migrationBuilder.CreateIndex(
                name: "IX_Students_Specialization_id",
                table: "Students",
                column: "Specialization_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "std_Factories");

            migrationBuilder.DropTable(
                name: "std_Supervisors");

            migrationBuilder.DropTable(
                name: "student_attendaces");

            migrationBuilder.DropTable(
                name: "Students");

            migrationBuilder.DropTable(
                name: "factories");

            migrationBuilder.DropTable(
                name: "supervisors");

            migrationBuilder.DropTable(
                name: "levels");

            migrationBuilder.DropTable(
                name: "specializations");
        }
    }
}
