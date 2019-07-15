using Microsoft.EntityFrameworkCore.Migrations;

namespace AdviseeGPATracker.Migrations
{
    public partial class mig5 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "GPA",
                table: "Courses");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<double>(
                name: "GPA",
                table: "Courses",
                nullable: false,
                defaultValue: 0.0);
        }
    }
}
