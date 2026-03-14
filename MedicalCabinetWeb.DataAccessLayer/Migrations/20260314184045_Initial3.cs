using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MedicalCabinetWeb.DataAccessLayer.Migrations
{
    /// <inheritdoc />
    public partial class Initial3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Services",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "Duration",
                table: "Services",
                type: "integer",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Description",
                table: "Services");

            migrationBuilder.DropColumn(
                name: "Duration",
                table: "Services");
        }
    }
}
