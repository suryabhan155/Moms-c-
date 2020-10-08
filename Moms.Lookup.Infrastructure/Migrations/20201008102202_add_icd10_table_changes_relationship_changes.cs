using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Moms.Lookup.Infrastructure.Migrations
{
    public partial class add_icd10_table_changes_relationship_changes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_IcdCodeBlocks_IcdCodeChapters_IcdCodeChapterId",
                table: "IcdCodeBlocks");

            migrationBuilder.DropForeignKey(
                name: "FK_IcdCodes_IcdCodeSubBlocks_IcdCodeSubBlockId",
                table: "IcdCodes");

            migrationBuilder.DropForeignKey(
                name: "FK_IcdCodeSubBlocks_IcdCodeBlocks_IcdCodeBlockId",
                table: "IcdCodeSubBlocks");


            migrationBuilder.DropColumn(
                name: "BlockId",
                table: "IcdCodeSubBlocks");

            migrationBuilder.DropColumn(
                name: "SubBlockId",
                table: "IcdCodes");

            migrationBuilder.DropColumn(
                name: "ChapterId",
                table: "IcdCodeBlocks");





      

            migrationBuilder.AlterColumn<Guid>(
                name: "IcdCodeBlockId",
                table: "IcdCodeSubBlocks",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uuid",
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "IcdCodeSubBlockId",
                table: "IcdCodes",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uuid",
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "IcdCodeChapterId",
                table: "IcdCodeBlocks",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uuid",
                oldNullable: true);



            migrationBuilder.AddForeignKey(
                name: "FK_IcdCodeBlocks_IcdCodeChapters_IcdCodeChapterId",
                table: "IcdCodeBlocks",
                column: "IcdCodeChapterId",
                principalTable: "IcdCodeChapters",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_IcdCodes_IcdCodeSubBlocks_IcdCodeSubBlockId",
                table: "IcdCodes",
                column: "IcdCodeSubBlockId",
                principalTable: "IcdCodeSubBlocks",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_IcdCodeSubBlocks_IcdCodeBlocks_IcdCodeBlockId",
                table: "IcdCodeSubBlocks",
                column: "IcdCodeBlockId",
                principalTable: "IcdCodeBlocks",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_IcdCodeBlocks_IcdCodeChapters_IcdCodeChapterId",
                table: "IcdCodeBlocks");

            migrationBuilder.DropForeignKey(
                name: "FK_IcdCodes_IcdCodeSubBlocks_IcdCodeSubBlockId",
                table: "IcdCodes");

            migrationBuilder.DropForeignKey(
                name: "FK_IcdCodeSubBlocks_IcdCodeBlocks_IcdCodeBlockId",
                table: "IcdCodeSubBlocks");

   





            migrationBuilder.AlterColumn<Guid>(
                name: "IcdCodeBlockId",
                table: "IcdCodeSubBlocks",
                type: "uuid",
                nullable: true,
                oldClrType: typeof(Guid));

            migrationBuilder.AddColumn<Guid>(
                name: "BlockId",
                table: "IcdCodeSubBlocks",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AlterColumn<Guid>(
                name: "IcdCodeSubBlockId",
                table: "IcdCodes",
                type: "uuid",
                nullable: true,
                oldClrType: typeof(Guid));

            migrationBuilder.AddColumn<Guid>(
                name: "SubBlockId",
                table: "IcdCodes",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AlterColumn<Guid>(
                name: "IcdCodeChapterId",
                table: "IcdCodeBlocks",
                type: "uuid",
                nullable: true,
                oldClrType: typeof(Guid));

            migrationBuilder.AddColumn<Guid>(
                name: "ChapterId",
                table: "IcdCodeBlocks",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

 

            migrationBuilder.AddForeignKey(
                name: "FK_IcdCodeBlocks_IcdCodeChapters_IcdCodeChapterId",
                table: "IcdCodeBlocks",
                column: "IcdCodeChapterId",
                principalTable: "IcdCodeChapters",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_IcdCodes_IcdCodeSubBlocks_IcdCodeSubBlockId",
                table: "IcdCodes",
                column: "IcdCodeSubBlockId",
                principalTable: "IcdCodeSubBlocks",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_IcdCodeSubBlocks_IcdCodeBlocks_IcdCodeBlockId",
                table: "IcdCodeSubBlocks",
                column: "IcdCodeBlockId",
                principalTable: "IcdCodeBlocks",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
