using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MedicalCabinetWeb.DataAccessLayer.Migrations
{
    /// <inheritdoc />
    public partial class Migratie13 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Admins",
                type: "boolean",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Admins");
        }
    }
}
