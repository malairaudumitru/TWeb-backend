using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MedicalCabinetWeb.DataAccessLayer.Migrations
{
    /// <inheritdoc />
    public partial class Migratie6 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Specialty",
                table: "Medici");

            migrationBuilder.AddColumn<int>(
                name: "Speciality",
                table: "Medici",
                type: "integer",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Speciality",
                table: "Medici");

            migrationBuilder.AddColumn<string>(
                name: "Specialty",
                table: "Medici",
                type: "text",
                nullable: false,
                defaultValue: "");
        }
    }
}
