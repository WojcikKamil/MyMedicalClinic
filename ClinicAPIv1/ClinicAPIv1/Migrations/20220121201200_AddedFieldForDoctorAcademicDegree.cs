using Microsoft.EntityFrameworkCore.Migrations;

namespace ClinicAPIv1.Migrations
{
    public partial class AddedFieldForDoctorAcademicDegree : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "AcademicDegree",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AcademicDegree",
                table: "AspNetUsers");
        }
    }
}
