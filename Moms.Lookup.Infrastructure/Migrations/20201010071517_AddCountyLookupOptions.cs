using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Moms.Lookup.Infrastructure.Migrations
{
    public partial class AddCountyLookupOptions : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CountyLookups",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CreateDate = table.Column<DateTime>(nullable: false),
                    Void = table.Column<bool>(nullable: false),
                    VoidDate = table.Column<DateTime>(nullable: true),
                    UserId = table.Column<Guid>(nullable: false),
                    CountyUid = table.Column<Guid>(nullable: false),
                    CountyCode = table.Column<int>(nullable: false),
                    CountyName = table.Column<string>(nullable: true),
                    SubCountyUid = table.Column<Guid>(nullable: false),
                    SubCountyCode = table.Column<int>(nullable: false),
                    SubCountyName = table.Column<string>(nullable: true),
                    WardUid = table.Column<Guid>(nullable: false),
                    WardCode = table.Column<int>(nullable: false),
                    WardName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CountyLookups", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CountyLookups");
        }
    }
}
