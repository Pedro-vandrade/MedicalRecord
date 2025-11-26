using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MedicalRecord.Migrations
{
    /// <inheritdoc />
    public partial class ApptPhycian : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FirstName",
                table: "Physicians");

            migrationBuilder.RenameColumn(
                name: "LastName",
                table: "Physicians",
                newName: "FullDocName");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "FullDocName",
                table: "Physicians",
                newName: "LastName");

            migrationBuilder.AddColumn<string>(
                name: "FirstName",
                table: "Physicians",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");
        }
    }
}
