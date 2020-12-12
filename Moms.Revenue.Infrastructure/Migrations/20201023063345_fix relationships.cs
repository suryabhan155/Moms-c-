using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Moms.Revenue.Infrastructure.Migrations
{
    public partial class fixrelationships : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BillingTypes_PriceLists_PriceListId",
                table: "BillingTypes");

            migrationBuilder.DropIndex(
                name: "IX_PriceLists_ModuleId",
                table: "PriceLists");

            migrationBuilder.DropIndex(
                name: "IX_BillingTypes_PriceListId",
                table: "BillingTypes");

            migrationBuilder.DropColumn(
                name: "PriceListId",
                table: "BillingTypes");

            migrationBuilder.AddColumn<Guid>(
                name: "BillingTypeId",
                table: "PriceLists",
                nullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "ItemTypeId",
                table: "ItemMasters",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uuid");

            migrationBuilder.CreateIndex(
                name: "IX_PriceLists_BillingTypeId",
                table: "PriceLists",
                column: "BillingTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_PriceLists_ModuleId",
                table: "PriceLists",
                column: "ModuleId");

            migrationBuilder.AddForeignKey(
                name: "FK_PriceLists_BillingTypes_BillingTypeId",
                table: "PriceLists",
                column: "BillingTypeId",
                principalTable: "BillingTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PriceLists_BillingTypes_BillingTypeId",
                table: "PriceLists");

            migrationBuilder.DropIndex(
                name: "IX_PriceLists_BillingTypeId",
                table: "PriceLists");

            migrationBuilder.DropIndex(
                name: "IX_PriceLists_ModuleId",
                table: "PriceLists");

            migrationBuilder.DropColumn(
                name: "BillingTypeId",
                table: "PriceLists");

            migrationBuilder.AlterColumn<Guid>(
                name: "ItemTypeId",
                table: "ItemMasters",
                type: "uuid",
                nullable: false,
                oldClrType: typeof(Guid),
                oldNullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "PriceListId",
                table: "BillingTypes",
                type: "uuid",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_PriceLists_ModuleId",
                table: "PriceLists",
                column: "ModuleId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_BillingTypes_PriceListId",
                table: "BillingTypes",
                column: "PriceListId");

            migrationBuilder.AddForeignKey(
                name: "FK_BillingTypes_PriceLists_PriceListId",
                table: "BillingTypes",
                column: "PriceListId",
                principalTable: "PriceLists",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
