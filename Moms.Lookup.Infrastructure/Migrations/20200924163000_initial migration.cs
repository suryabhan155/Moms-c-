using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Moms.Lookup.Infrastructure.Migrations
{
    public partial class initialmigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
                name: "LookupItems",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CreateDate = table.Column<DateTime>(nullable: false),
                    Void = table.Column<bool>(nullable: false),
                    VoidDate = table.Column<DateTime>(nullable: true),
                    UserId = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Alias = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LookupItems", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "LookupMasterItems",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CreateDate = table.Column<DateTime>(nullable: false),
                    Void = table.Column<bool>(nullable: false),
                    VoidDate = table.Column<DateTime>(nullable: true),
                    UserId = table.Column<Guid>(nullable: false),
                    LookupMasterId = table.Column<Guid>(nullable: false),
                    LookupItemId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LookupMasterItems", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "LookupMasters",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CreateDate = table.Column<DateTime>(nullable: false),
                    Void = table.Column<bool>(nullable: false),
                    VoidDate = table.Column<DateTime>(nullable: true),
                    UserId = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Alias = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LookupMasters", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "IcdCodeBlocks",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CreateDate = table.Column<DateTime>(nullable: false),
                    Void = table.Column<bool>(nullable: false),
                    VoidDate = table.Column<DateTime>(nullable: true),
                    UserId = table.Column<Guid>(nullable: false),
                    ChapterId = table.Column<Guid>(nullable: false),
                    Code = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IcdCodeBlocks", x => x.Id);
                    table.ForeignKey(
                        name: "FK_IcdCodeBlocks_IcdCodeChapters_ChapterId",
                        column: x => x.ChapterId,
                        principalTable: "IcdCodeChapters",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
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
                    BlockId = table.Column<Guid>(nullable: false),
                    Code = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    IcdCodeBlockId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IcdCodeSubBlocks", x => x.Id);
                    table.ForeignKey(
                        name: "FK_IcdCodeSubBlocks_IcdCodeBlocks_IcdCodeBlockId",
                        column: x => x.IcdCodeBlockId,
                        principalTable: "IcdCodeBlocks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
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
                    SubBlockId = table.Column<Guid>(nullable: false),
                    Code = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    IcdCodeSubBlockId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IcdCodes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_IcdCodes_IcdCodeSubBlocks_IcdCodeSubBlockId",
                        column: x => x.IcdCodeSubBlockId,
                        principalTable: "IcdCodeSubBlocks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

          /*  migrationBuilder.CreateIndex(
                name: "IX_IcdCodeBlocks_IcdCodeChapterId",
                table: "IcdCodeBlocks",
                column: "IcdCodeChapterId");*/

            migrationBuilder.CreateIndex(
                name: "IX_IcdCodes_IcdCodeSubBlockId",
                table: "IcdCodes",
                column: "IcdCodeSubBlockId");

            migrationBuilder.CreateIndex(
                name: "IX_IcdCodeSubBlocks_IcdCodeBlockId",
                table: "IcdCodeSubBlocks",
                column: "IcdCodeBlockId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "IcdCodes");

            migrationBuilder.DropTable(
                name: "LookupItems");

            migrationBuilder.DropTable(
                name: "LookupMasterItems");

            migrationBuilder.DropTable(
                name: "LookupMasters");

            migrationBuilder.DropTable(
                name: "IcdCodeSubBlocks");

            migrationBuilder.DropTable(
                name: "IcdCodeBlocks");

            migrationBuilder.DropTable(
                name: "IcdCodeChapters");
        }
    }
}
