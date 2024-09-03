using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Hospital.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class IdPropertyMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Doctors_HospitalSites_SiteId",
                table: "Doctors");

            migrationBuilder.DropForeignKey(
                name: "FK_Patients_HospitalSites_SiteId",
                table: "Patients");

            migrationBuilder.RenameColumn(
                name: "SiteId",
                table: "Patients",
                newName: "HospitalSiteId");

            migrationBuilder.RenameIndex(
                name: "IX_Patients_SiteId",
                table: "Patients",
                newName: "IX_Patients_HospitalSiteId");

            migrationBuilder.RenameColumn(
                name: "SiteId",
                table: "Doctors",
                newName: "HospitalSiteId");

            migrationBuilder.RenameIndex(
                name: "IX_Doctors_SiteId",
                table: "Doctors",
                newName: "IX_Doctors_HospitalSiteId");

            migrationBuilder.AddForeignKey(
                name: "FK_Doctors_HospitalSites_HospitalSiteId",
                table: "Doctors",
                column: "HospitalSiteId",
                principalTable: "HospitalSites",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Patients_HospitalSites_HospitalSiteId",
                table: "Patients",
                column: "HospitalSiteId",
                principalTable: "HospitalSites",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Doctors_HospitalSites_HospitalSiteId",
                table: "Doctors");

            migrationBuilder.DropForeignKey(
                name: "FK_Patients_HospitalSites_HospitalSiteId",
                table: "Patients");

            migrationBuilder.RenameColumn(
                name: "HospitalSiteId",
                table: "Patients",
                newName: "SiteId");

            migrationBuilder.RenameIndex(
                name: "IX_Patients_HospitalSiteId",
                table: "Patients",
                newName: "IX_Patients_SiteId");

            migrationBuilder.RenameColumn(
                name: "HospitalSiteId",
                table: "Doctors",
                newName: "SiteId");

            migrationBuilder.RenameIndex(
                name: "IX_Doctors_HospitalSiteId",
                table: "Doctors",
                newName: "IX_Doctors_SiteId");

            migrationBuilder.AddForeignKey(
                name: "FK_Doctors_HospitalSites_SiteId",
                table: "Doctors",
                column: "SiteId",
                principalTable: "HospitalSites",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Patients_HospitalSites_SiteId",
                table: "Patients",
                column: "SiteId",
                principalTable: "HospitalSites",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
