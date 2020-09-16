using Microsoft.EntityFrameworkCore.Migrations;

namespace Moms.Lookup.Infrastructure.Migrations
{
    public partial class updateinitialmigrations : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_LookupOptions_LookupItemId",
                table: "LookupOptions",
                column: "LookupItemId");

            migrationBuilder.CreateIndex(
                name: "IX_LookupOptions_LookupMasterId",
                table: "LookupOptions",
                column: "LookupMasterId");

            migrationBuilder.AddForeignKey(
                name: "FK_LookupOptions_LookupItems_LookupItemId",
                table: "LookupOptions",
                column: "LookupItemId",
                principalTable: "LookupItems",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);

            migrationBuilder.AddForeignKey(
                name: "FK_LookupOptions_LookupMasters_LookupMasterId",
                table: "LookupOptions",
                column: "LookupMasterId",
                principalTable: "LookupMasters",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LookupOptions_LookupItems_LookupItemId",
                table: "LookupOptions");

            migrationBuilder.DropForeignKey(
                name: "FK_LookupOptions_LookupMasters_LookupMasterId",
                table: "LookupOptions");

            migrationBuilder.DropIndex(
                name: "IX_LookupOptions_LookupItemId",
                table: "LookupOptions");

            migrationBuilder.DropIndex(
                name: "IX_LookupOptions_LookupMasterId",
                table: "LookupOptions");
        }
    }
}
