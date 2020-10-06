using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Moms.RegistrationManagement.Infrastructure.Migrations
{
    public partial class Newpatientcolumns : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "IdentificationNumber",
                table: "Patients",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PatientNumber",
                table: "Patients",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Phone",
                table: "Patients",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "RegistrationDate",
                table: "Patients",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.CreateTable(
                name: "LookupItem",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CreateDate = table.Column<DateTime>(nullable: false),
                    Void = table.Column<bool>(nullable: false),
                    VoidDate = table.Column<DateTime>(nullable: true),
                    UserId = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Alias = table.Column<string>(nullable: true),
                    PatientId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LookupItem", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LookupItem_Patients_PatientId",
                        column: x => x.PatientId,
                        principalTable: "Patients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_LookupItem_PatientId",
                table: "LookupItem",
                column: "PatientId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "LookupItem");

            migrationBuilder.DropColumn(
                name: "IdentificationNumber",
                table: "Patients");

            migrationBuilder.DropColumn(
                name: "PatientNumber",
                table: "Patients");

            migrationBuilder.DropColumn(
                name: "Phone",
                table: "Patients");

            migrationBuilder.DropColumn(
                name: "RegistrationDate",
                table: "Patients");
        }
    }
}
