using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AdviseeGPATracker.Migrations
{
    public partial class mig2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AdviseeCourses");

            migrationBuilder.DropColumn(
                name: "QualityPoints",
                table: "Courses");

            migrationBuilder.AddColumn<int>(
                name: "AdviseeId",
                table: "Courses",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Code",
                table: "Courses",
                maxLength: 50,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "LetterGrade",
                table: "Courses",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Courses_AdviseeId",
                table: "Courses",
                column: "AdviseeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Courses_Advisees_AdviseeId",
                table: "Courses",
                column: "AdviseeId",
                principalTable: "Advisees",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Courses_Advisees_AdviseeId",
                table: "Courses");

            migrationBuilder.DropIndex(
                name: "IX_Courses_AdviseeId",
                table: "Courses");

            migrationBuilder.DropColumn(
                name: "AdviseeId",
                table: "Courses");

            migrationBuilder.DropColumn(
                name: "Code",
                table: "Courses");

            migrationBuilder.DropColumn(
                name: "LetterGrade",
                table: "Courses");

            migrationBuilder.AddColumn<double>(
                name: "QualityPoints",
                table: "Courses",
                nullable: false,
                defaultValue: 0.0);

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
    }
}
