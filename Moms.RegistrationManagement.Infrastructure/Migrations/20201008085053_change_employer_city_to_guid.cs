using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Moms.RegistrationManagement.Infrastructure.Migrations
{
    public partial class change_employer_city_to_guid : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Country",
                table: "Employers",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uuid");

            migrationBuilder.AlterColumn<string>(
                name: "City",
                table: "Employers",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uuid");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<Guid>(
                name: "Country",
                table: "Employers",
                type: "uuid",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "City",
                table: "Employers",
                type: "uuid",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);
        }
    }
}
