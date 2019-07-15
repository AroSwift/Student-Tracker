using Microsoft.EntityFrameworkCore.Migrations;

namespace AdviseeGPATracker.Migrations
{
    public partial class mig6 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TotalCreditHours",
                table: "Advisees");

            migrationBuilder.DropColumn(
                name: "TotalGPA",
                table: "Advisees");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "TotalCreditHours",
                table: "Advisees",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TotalGPA",
                table: "Advisees",
                nullable: true);
        }
    }
}
