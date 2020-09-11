using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Moms.RegistrationManagement.Infrastructure.Migrations
{
    public partial class commoncolumns : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "CreateDate",
                table: "Patients",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<Guid>(
                name: "UserId",
                table: "Patients",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<bool>(
                name: "Void",
                table: "Patients",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "VoidDate",
                table: "Patients",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreateDate",
                table: "Guardians",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<Guid>(
                name: "UserId",
                table: "Guardians",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<bool>(
                name: "Void",
                table: "Guardians",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "VoidDate",
                table: "Guardians",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreateDate",
                table: "Employers",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<Guid>(
                name: "UserId",
                table: "Employers",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<bool>(
                name: "Void",
                table: "Employers",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "VoidDate",
                table: "Employers",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreateDate",
                table: "Deaths",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<Guid>(
                name: "UserId",
                table: "Deaths",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<bool>(
                name: "Void",
                table: "Deaths",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "VoidDate",
                table: "Deaths",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreateDate",
                table: "Contacts",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<Guid>(
                name: "UserId",
                table: "Contacts",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<bool>(
                name: "Void",
                table: "Contacts",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "VoidDate",
                table: "Contacts",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreateDate",
                table: "Clinics",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<Guid>(
                name: "UserId",
                table: "Clinics",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<bool>(
                name: "Void",
                table: "Clinics",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "VoidDate",
                table: "Clinics",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreateDate",
                table: "Patients");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Patients");

            migrationBuilder.DropColumn(
                name: "Void",
                table: "Patients");

            migrationBuilder.DropColumn(
                name: "VoidDate",
                table: "Patients");

            migrationBuilder.DropColumn(
                name: "CreateDate",
                table: "Guardians");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Guardians");

            migrationBuilder.DropColumn(
                name: "Void",
                table: "Guardians");

            migrationBuilder.DropColumn(
                name: "VoidDate",
                table: "Guardians");

            migrationBuilder.DropColumn(
                name: "CreateDate",
                table: "Employers");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Employers");

            migrationBuilder.DropColumn(
                name: "Void",
                table: "Employers");

            migrationBuilder.DropColumn(
                name: "VoidDate",
                table: "Employers");

            migrationBuilder.DropColumn(
                name: "CreateDate",
                table: "Deaths");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Deaths");

            migrationBuilder.DropColumn(
                name: "Void",
                table: "Deaths");

            migrationBuilder.DropColumn(
                name: "VoidDate",
                table: "Deaths");

            migrationBuilder.DropColumn(
                name: "CreateDate",
                table: "Contacts");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Contacts");

            migrationBuilder.DropColumn(
                name: "Void",
                table: "Contacts");

            migrationBuilder.DropColumn(
                name: "VoidDate",
                table: "Contacts");

            migrationBuilder.DropColumn(
                name: "CreateDate",
                table: "Clinics");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Clinics");

            migrationBuilder.DropColumn(
                name: "Void",
                table: "Clinics");

            migrationBuilder.DropColumn(
                name: "VoidDate",
                table: "Clinics");
        }
    }
}
