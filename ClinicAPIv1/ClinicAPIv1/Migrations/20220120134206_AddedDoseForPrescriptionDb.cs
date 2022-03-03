using Microsoft.EntityFrameworkCore.Migrations;

namespace ClinicAPIv1.Migrations
{
    public partial class AddedDoseForPrescriptionDb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Dose",
                table: "Prescriptions",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Dose",
                table: "Prescriptions");
        }
    }
}
