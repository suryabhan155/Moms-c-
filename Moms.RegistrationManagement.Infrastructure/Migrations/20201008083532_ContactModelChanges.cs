using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Moms.RegistrationManagement.Infrastructure.Migrations
{
    public partial class ContactModelChanges : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {



            migrationBuilder.AlterColumn<string>(
                name: "City",
                table: "Contacts",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uuid");

            migrationBuilder.AddColumn<Guid>(
                name: "Ward",
                table: "Contacts",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Ward",
                table: "Contacts");


            migrationBuilder.RenameColumn(
                name: "FirstName",
                table: "PatientGrids",
                newName: "firstname");

            migrationBuilder.AlterColumn<Guid>(
                name: "City",
                table: "Contacts",
                type: "uuid",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);
        }
    }
}
