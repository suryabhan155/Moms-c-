using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Moms.Lookup.Infrastructure.Migrations
{
    public partial class AddLookupIcd10Options : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "IcdCodeBlocks",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CreateDate = table.Column<DateTime>(nullable: false),
                    Void = table.Column<bool>(nullable: false),
                    VoidDate = table.Column<DateTime>(nullable: true),
                    UserId = table.Column<Guid>(nullable: false),
                    IcdCodeChapterId = table.Column<Guid>(nullable: false),
                    Code = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IcdCodeBlocks", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "IcdCodeChapters",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CreateDate = table.Column<DateTime>(nullable: false),
                    Void = table.Column<bool>(nullable: false),
                    VoidDate = table.Column<DateTime>(nullable: true),
                    UserId = table.Column<Guid>(nullable: false),
                    Code = table.Column<int>(nullable: false),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IcdCodeChapters", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "IcdCodes",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CreateDate = table.Column<DateTime>(nullable: false),
                    Void = table.Column<bool>(nullable: false),
                    VoidDate = table.Column<DateTime>(nullable: true),
                    UserId = table.Column<Guid>(nullable: false),
                    IcdCodeSubBlockId = table.Column<Guid>(nullable: false),
                    Code = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IcdCodes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "IcdCodeSubBlocks",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CreateDate = table.Column<DateTime>(nullable: false),
                    Void = table.Column<bool>(nullable: false),
                    VoidDate = table.Column<DateTime>(nullable: true),
                    UserId = table.Column<Guid>(nullable: false),
                    IcdCodeBlockId = table.Column<Guid>(nullable: false),
                    Code = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IcdCodeSubBlocks", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "IcdCodeBlocks");

            migrationBuilder.DropTable(
                name: "IcdCodeChapters");

            migrationBuilder.DropTable(
                name: "IcdCodes");

            migrationBuilder.DropTable(
                name: "IcdCodeSubBlocks");
        }
    }
}
