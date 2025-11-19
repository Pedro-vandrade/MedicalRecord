using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MedicalRecord.Migrations
{
    /// <inheritdoc />
    public partial class physicianEnumField : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Specialty",
                table: "Physicians");

            migrationBuilder.AddColumn<string>(
                name: "PhysicianSpecialty",
                table: "Physicians",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PhysicianSpecialty",
                table: "Physicians");

            migrationBuilder.AddColumn<int>(
                name: "Specialty",
                table: "Physicians",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
