using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Nexos.MedApp.Repository.Migrations
{
    public partial class addDatesinMiddleTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "CreationDate",
                table: "PatientDoctors",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreationDate",
                table: "PatientDoctors");
        }
    }
}
