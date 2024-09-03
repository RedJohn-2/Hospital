using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Hospital.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class FixMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Patients_Office_OfficeId",
                table: "Patients");

            migrationBuilder.RenameColumn(
                name: "OfficeId",
                table: "Patients",
                newName: "SiteId");

            migrationBuilder.RenameIndex(
                name: "IX_Patients_OfficeId",
                table: "Patients",
                newName: "IX_Patients_SiteId");

            migrationBuilder.AddForeignKey(
                name: "FK_Patients_HospitalSites_SiteId",
                table: "Patients",
                column: "SiteId",
                principalTable: "HospitalSites",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Patients_HospitalSites_SiteId",
                table: "Patients");

            migrationBuilder.RenameColumn(
                name: "SiteId",
                table: "Patients",
                newName: "OfficeId");

            migrationBuilder.RenameIndex(
                name: "IX_Patients_SiteId",
                table: "Patients",
                newName: "IX_Patients_OfficeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Patients_Office_OfficeId",
                table: "Patients",
                column: "OfficeId",
                principalTable: "Office",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
