using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace MedicalCabinetWeb.DataAccessLayer.Migrations
{
    /// <inheritdoc />
    public partial class UsersCommon : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "UserAccountId",
                table: "Patients",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "UserAccountId",
                table: "Medics",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "UserAccountId",
                table: "Admins",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "UserAccounts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    LastName = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    FirstName = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    PasswordHash = table.Column<string>(type: "text", nullable: false),
                    Role = table.Column<int>(type: "integer", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserAccounts", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Patients_UserAccountId",
                table: "Patients",
                column: "UserAccountId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Medics_UserAccountId",
                table: "Medics",
                column: "UserAccountId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Admins_UserAccountId",
                table: "Admins",
                column: "UserAccountId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Admins_UserAccounts_UserAccountId",
                table: "Admins",
                column: "UserAccountId",
                principalTable: "UserAccounts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Medics_UserAccounts_UserAccountId",
                table: "Medics",
                column: "UserAccountId",
                principalTable: "UserAccounts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Patients_UserAccounts_UserAccountId",
                table: "Patients",
                column: "UserAccountId",
                principalTable: "UserAccounts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Admins_UserAccounts_UserAccountId",
                table: "Admins");

            migrationBuilder.DropForeignKey(
                name: "FK_Medics_UserAccounts_UserAccountId",
                table: "Medics");

            migrationBuilder.DropForeignKey(
                name: "FK_Patients_UserAccounts_UserAccountId",
                table: "Patients");

            migrationBuilder.DropTable(
                name: "UserAccounts");

            migrationBuilder.DropIndex(
                name: "IX_Patients_UserAccountId",
                table: "Patients");

            migrationBuilder.DropIndex(
                name: "IX_Medics_UserAccountId",
                table: "Medics");

            migrationBuilder.DropIndex(
                name: "IX_Admins_UserAccountId",
                table: "Admins");

            migrationBuilder.DropColumn(
                name: "UserAccountId",
                table: "Patients");

            migrationBuilder.DropColumn(
                name: "UserAccountId",
                table: "Medics");

            migrationBuilder.DropColumn(
                name: "UserAccountId",
                table: "Admins");
        }
    }
}
