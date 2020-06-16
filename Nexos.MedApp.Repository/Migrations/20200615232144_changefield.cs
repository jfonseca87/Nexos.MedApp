using Microsoft.EntityFrameworkCore.Migrations;

namespace Nexos.MedApp.Repository.Migrations
{
    public partial class changefield : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreditialNumber",
                table: "Doctors");

            migrationBuilder.AddColumn<string>(
                name: "CredentialNumber",
                table: "Doctors",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CredentialNumber",
                table: "Doctors");

            migrationBuilder.AddColumn<string>(
                name: "CreditialNumber",
                table: "Doctors",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
