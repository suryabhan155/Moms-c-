using Microsoft.EntityFrameworkCore.Migrations;

namespace Moms.Revenue.Infrastructure.Migrations
{
    public partial class InitialMigrationRevenue : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_ClientBillPayment_ItemMasterId",
                table: "ClientBillPayment");

            migrationBuilder.DropIndex(
                name: "IX_ClientBillPayment_ModuleId",
                table: "ClientBillPayment");

            migrationBuilder.DropIndex(
                name: "IX_ClientBillPayment_PaymentTypeId",
                table: "ClientBillPayment");

            migrationBuilder.CreateIndex(
                name: "IX_ClientBillPayment_ItemMasterId",
                table: "ClientBillPayment",
                column: "ItemMasterId");

            migrationBuilder.CreateIndex(
                name: "IX_ClientBillPayment_ModuleId",
                table: "ClientBillPayment",
                column: "ModuleId");

            migrationBuilder.CreateIndex(
                name: "IX_ClientBillPayment_PaymentTypeId",
                table: "ClientBillPayment",
                column: "PaymentTypeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_ClientBillPayment_ItemMasterId",
                table: "ClientBillPayment");

            migrationBuilder.DropIndex(
                name: "IX_ClientBillPayment_ModuleId",
                table: "ClientBillPayment");

            migrationBuilder.DropIndex(
                name: "IX_ClientBillPayment_PaymentTypeId",
                table: "ClientBillPayment");

            migrationBuilder.CreateIndex(
                name: "IX_ClientBillPayment_ItemMasterId",
                table: "ClientBillPayment",
                column: "ItemMasterId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ClientBillPayment_ModuleId",
                table: "ClientBillPayment",
                column: "ModuleId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ClientBillPayment_PaymentTypeId",
                table: "ClientBillPayment",
                column: "PaymentTypeId",
                unique: true);
        }
    }
}
