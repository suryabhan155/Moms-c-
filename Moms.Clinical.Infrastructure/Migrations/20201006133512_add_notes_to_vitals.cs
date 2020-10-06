using Microsoft.EntityFrameworkCore.Migrations;

namespace Moms.Clinical.Infrastructure.Migrations
{
    public partial class add_notes_to_vitals : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Notes",
                table: "Vitals",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Notes",
                table: "Vitals");
        }
    }
}
