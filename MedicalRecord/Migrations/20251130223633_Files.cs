using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MedicalRecord.Migrations
{
    /// <inheritdoc />
    public partial class Files : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "EndDate",
                table: "Prescriptions",
                type: "datetime(6)",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)");

            migrationBuilder.AddColumn<int>(
                name: "MedicalRecordId",
                table: "Prescriptions",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "MedicalRecsId",
                table: "Prescriptions",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "MedicalRecs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    PatientId = table.Column<int>(type: "int", nullable: false),
                    PhysicianId = table.Column<int>(type: "int", nullable: false),
                    RecordDate = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    Symptom = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Treatment = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    DoctorNotes = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MedicalRecs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MedicalRecs_Patients_PatientId",
                        column: x => x.PatientId,
                        principalTable: "Patients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MedicalRecs_Physicians_PhysicianId",
                        column: x => x.PhysicianId,
                        principalTable: "Physicians",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_Prescriptions_MedicalRecsId",
                table: "Prescriptions",
                column: "MedicalRecsId");

            migrationBuilder.CreateIndex(
                name: "IX_MedicalRecs_PatientId",
                table: "MedicalRecs",
                column: "PatientId");

            migrationBuilder.CreateIndex(
                name: "IX_MedicalRecs_PhysicianId",
                table: "MedicalRecs",
                column: "PhysicianId");

            migrationBuilder.AddForeignKey(
                name: "FK_Prescriptions_MedicalRecs_MedicalRecsId",
                table: "Prescriptions",
                column: "MedicalRecsId",
                principalTable: "MedicalRecs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Prescriptions_MedicalRecs_MedicalRecsId",
                table: "Prescriptions");

            migrationBuilder.DropTable(
                name: "MedicalRecs");

            migrationBuilder.DropIndex(
                name: "IX_Prescriptions_MedicalRecsId",
                table: "Prescriptions");

            migrationBuilder.DropColumn(
                name: "MedicalRecordId",
                table: "Prescriptions");

            migrationBuilder.DropColumn(
                name: "MedicalRecsId",
                table: "Prescriptions");

            migrationBuilder.AlterColumn<DateTime>(
                name: "EndDate",
                table: "Prescriptions",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldNullable: true);
        }
    }
}
