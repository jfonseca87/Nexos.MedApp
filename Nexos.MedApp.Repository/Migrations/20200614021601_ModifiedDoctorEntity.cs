using Microsoft.EntityFrameworkCore.Migrations;

namespace Nexos.MedApp.Repository.Migrations
{
    public partial class ModifiedDoctorEntity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PatientDoctors_Doctors_DoctorId",
                table: "PatientDoctors");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Doctors",
                table: "Doctors");

            migrationBuilder.DropColumn(
                name: "PatientId",
                table: "Doctors");

            migrationBuilder.AddColumn<int>(
                name: "DoctorId",
                table: "Doctors",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Doctors",
                table: "Doctors",
                column: "DoctorId");

            migrationBuilder.AddForeignKey(
                name: "FK_PatientDoctors_Doctors_DoctorId",
                table: "PatientDoctors",
                column: "DoctorId",
                principalTable: "Doctors",
                principalColumn: "DoctorId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PatientDoctors_Doctors_DoctorId",
                table: "PatientDoctors");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Doctors",
                table: "Doctors");

            migrationBuilder.DropColumn(
                name: "DoctorId",
                table: "Doctors");

            migrationBuilder.AddColumn<int>(
                name: "PatientId",
                table: "Doctors",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Doctors",
                table: "Doctors",
                column: "PatientId");

            migrationBuilder.AddForeignKey(
                name: "FK_PatientDoctors_Doctors_DoctorId",
                table: "PatientDoctors",
                column: "DoctorId",
                principalTable: "Doctors",
                principalColumn: "PatientId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
