using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AdviseeGPATracker.Migrations
{
    public partial class mig1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Advisees",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    FirstName = table.Column<string>(maxLength: 50, nullable: false),
                    LastName = table.Column<string>(maxLength: 50, nullable: false),
                    TotalGPA = table.Column<string>(nullable: true),
                    TotalCreditHours = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Advisees", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Courses",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    QualityPoints = table.Column<double>(nullable: false),
                    CreditHours = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Courses", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AdviseeCourses",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    AdviseeId = table.Column<int>(nullable: false),
                    CourseId = table.Column<int>(nullable: false),
                    GradePoints = table.Column<int>(nullable: false),
                    LetterGrade = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AdviseeCourses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AdviseeCourses_Advisees_AdviseeId",
                        column: x => x.AdviseeId,
                        principalTable: "Advisees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AdviseeCourses_Courses_CourseId",
                        column: x => x.CourseId,
                        principalTable: "Courses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AdviseeCourses_AdviseeId",
                table: "AdviseeCourses",
                column: "AdviseeId");

            migrationBuilder.CreateIndex(
                name: "IX_AdviseeCourses_CourseId",
                table: "AdviseeCourses",
                column: "CourseId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AdviseeCourses");

            migrationBuilder.DropTable(
                name: "Advisees");

            migrationBuilder.DropTable(
                name: "Courses");
        }
    }
}
