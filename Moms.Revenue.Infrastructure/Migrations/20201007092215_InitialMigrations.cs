using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Moms.Revenue.Infrastructure.Migrations
{
    public partial class InitialMigrations : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BillingDiscounts",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CreateDate = table.Column<DateTime>(nullable: false),
                    Void = table.Column<bool>(nullable: false),
                    VoidDate = table.Column<DateTime>(nullable: true),
                    UserId = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    IsPercentage = table.Column<bool>(nullable: false),
                    MinDiscount = table.Column<decimal>(nullable: false),
                    MaxDiscount = table.Column<decimal>(nullable: false),
                    NeedsApproval = table.Column<bool>(nullable: false),
                    Status = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BillingDiscounts", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ClientBillingItems",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CreateDate = table.Column<DateTime>(nullable: false),
                    Void = table.Column<bool>(nullable: false),
                    VoidDate = table.Column<DateTime>(nullable: true),
                    UserId = table.Column<Guid>(nullable: false),
                    BillId = table.Column<Guid>(nullable: false),
                    ItemMasterId = table.Column<Guid>(nullable: false),
                    PriceListId = table.Column<Guid>(nullable: false),
                    Quantity = table.Column<decimal>(nullable: false),
                    Price = table.Column<decimal>(nullable: false),
                    Status = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClientBillingItems", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ClientBills",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CreateDate = table.Column<DateTime>(nullable: false),
                    Void = table.Column<bool>(nullable: false),
                    VoidDate = table.Column<DateTime>(nullable: true),
                    UserId = table.Column<Guid>(nullable: false),
                    PatientId = table.Column<Guid>(nullable: false),
                    BillingDate = table.Column<DateTime>(nullable: false),
                    BillNumber = table.Column<string>(nullable: true),
                    BillTotal = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClientBills", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ItemConfigurations",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CreateDate = table.Column<DateTime>(nullable: false),
                    Void = table.Column<bool>(nullable: false),
                    VoidDate = table.Column<DateTime>(nullable: true),
                    UserId = table.Column<Guid>(nullable: false),
                    ItemMasterId = table.Column<Guid>(nullable: false),
                    MaxStock = table.Column<int>(nullable: false),
                    MinStock = table.Column<int>(nullable: false),
                    PurchaseUnitPrice = table.Column<decimal>(nullable: false),
                    QuantityPerPurchaseUnit = table.Column<decimal>(nullable: false),
                    DispensingUnit = table.Column<string>(nullable: true),
                    PurchaseUnit = table.Column<string>(nullable: true),
                    QuantityPerDispenseUnit = table.Column<string>(nullable: true),
                    Status = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ItemConfigurations", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Modules",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CreateDate = table.Column<DateTime>(nullable: false),
                    Void = table.Column<bool>(nullable: false),
                    VoidDate = table.Column<DateTime>(nullable: true),
                    UserId = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(nullable: false),
                    Status = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Modules", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PaymentTypes",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CreateDate = table.Column<DateTime>(nullable: false),
                    Void = table.Column<bool>(nullable: false),
                    VoidDate = table.Column<DateTime>(nullable: true),
                    UserId = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PaymentTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ItemMasters",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CreateDate = table.Column<DateTime>(nullable: false),
                    Void = table.Column<bool>(nullable: false),
                    VoidDate = table.Column<DateTime>(nullable: true),
                    UserId = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    DisplayName = table.Column<string>(nullable: true),
                    ItemTypeId = table.Column<Guid>(nullable: false),
                    ItemSubTypeId = table.Column<Guid>(nullable: false),
                    ItemCode = table.Column<string>(nullable: true),
                    ItemDescription = table.Column<string>(nullable: true),
                    Abbreviation = table.Column<string>(nullable: true),
                    Type = table.Column<Guid>(nullable: false),
                    ItemConfigurationId = table.Column<Guid>(nullable: true),
                    ClientBillingItemId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ItemMasters", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ItemMasters_ClientBillingItems_ClientBillingItemId",
                        column: x => x.ClientBillingItemId,
                        principalTable: "ClientBillingItems",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ItemMasters_ItemConfigurations_ItemConfigurationId",
                        column: x => x.ItemConfigurationId,
                        principalTable: "ItemConfigurations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ClientBillPayment",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CreateDate = table.Column<DateTime>(nullable: false),
                    Void = table.Column<bool>(nullable: false),
                    VoidDate = table.Column<DateTime>(nullable: true),
                    UserId = table.Column<Guid>(nullable: false),
                    ClientBillingId = table.Column<Guid>(nullable: false),
                    ItemMasterId = table.Column<Guid>(nullable: false),
                    PaymentTypeId = table.Column<Guid>(nullable: false),
                    ModuleId = table.Column<Guid>(nullable: false),
                    DiscountedAmount = table.Column<decimal>(nullable: false),
                    Amount = table.Column<decimal>(nullable: false),
                    Status = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClientBillPayment", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ClientBillPayment_ItemMasters_ItemMasterId",
                        column: x => x.ItemMasterId,
                        principalTable: "ItemMasters",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ClientBillPayment_Modules_ModuleId",
                        column: x => x.ModuleId,
                        principalTable: "Modules",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ClientBillPayment_PaymentTypes_PaymentTypeId",
                        column: x => x.PaymentTypeId,
                        principalTable: "PaymentTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ItemTypes",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CreateDate = table.Column<DateTime>(nullable: false),
                    Void = table.Column<bool>(nullable: false),
                    VoidDate = table.Column<DateTime>(nullable: true),
                    UserId = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Status = table.Column<bool>(nullable: false),
                    ItemMasterId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ItemTypes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ItemTypes_ItemMasters_ItemMasterId",
                        column: x => x.ItemMasterId,
                        principalTable: "ItemMasters",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PriceLists",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CreateDate = table.Column<DateTime>(nullable: false),
                    Void = table.Column<bool>(nullable: false),
                    VoidDate = table.Column<DateTime>(nullable: true),
                    UserId = table.Column<Guid>(nullable: false),
                    ItemMasterId = table.Column<Guid>(nullable: false),
                    ItemName = table.Column<string>(nullable: true),
                    ModuleId = table.Column<Guid>(nullable: false),
                    BillTypeId = table.Column<Guid>(nullable: false),
                    SellingPrice = table.Column<decimal>(nullable: false),
                    EffectiveDate = table.Column<DateTime>(nullable: false),
                    IsDiscounted = table.Column<bool>(nullable: false),
                    Status = table.Column<bool>(nullable: false),
                    ClientBillingItemsId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PriceLists", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PriceLists_ClientBillingItems_ClientBillingItemsId",
                        column: x => x.ClientBillingItemsId,
                        principalTable: "ClientBillingItems",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PriceLists_ItemMasters_ItemMasterId",
                        column: x => x.ItemMasterId,
                        principalTable: "ItemMasters",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PriceLists_Modules_ModuleId",
                        column: x => x.ModuleId,
                        principalTable: "Modules",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ItemTypeSubTypes",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CreateDate = table.Column<DateTime>(nullable: false),
                    Void = table.Column<bool>(nullable: false),
                    VoidDate = table.Column<DateTime>(nullable: true),
                    UserId = table.Column<Guid>(nullable: false),
                    ItemTypeId = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Status = table.Column<bool>(nullable: false),
                    ItemMasterId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ItemTypeSubTypes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ItemTypeSubTypes_ItemMasters_ItemMasterId",
                        column: x => x.ItemMasterId,
                        principalTable: "ItemMasters",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ItemTypeSubTypes_ItemTypes_ItemTypeId",
                        column: x => x.ItemTypeId,
                        principalTable: "ItemTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BillingTypes",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CreateDate = table.Column<DateTime>(nullable: false),
                    Void = table.Column<bool>(nullable: false),
                    VoidDate = table.Column<DateTime>(nullable: true),
                    UserId = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Status = table.Column<bool>(nullable: false),
                    PriceListId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BillingTypes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BillingTypes_PriceLists_PriceListId",
                        column: x => x.PriceListId,
                        principalTable: "PriceLists",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BillingTypes_PriceListId",
                table: "BillingTypes",
                column: "PriceListId");

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

            migrationBuilder.CreateIndex(
                name: "IX_ItemMasters_ClientBillingItemId",
                table: "ItemMasters",
                column: "ClientBillingItemId");

            migrationBuilder.CreateIndex(
                name: "IX_ItemMasters_ItemConfigurationId",
                table: "ItemMasters",
                column: "ItemConfigurationId");

            migrationBuilder.CreateIndex(
                name: "IX_ItemTypes_ItemMasterId",
                table: "ItemTypes",
                column: "ItemMasterId");

            migrationBuilder.CreateIndex(
                name: "IX_ItemTypeSubTypes_ItemMasterId",
                table: "ItemTypeSubTypes",
                column: "ItemMasterId");

            migrationBuilder.CreateIndex(
                name: "IX_ItemTypeSubTypes_ItemTypeId",
                table: "ItemTypeSubTypes",
                column: "ItemTypeId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_PriceLists_ClientBillingItemsId",
                table: "PriceLists",
                column: "ClientBillingItemsId");

            migrationBuilder.CreateIndex(
                name: "IX_PriceLists_ItemMasterId",
                table: "PriceLists",
                column: "ItemMasterId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_PriceLists_ModuleId",
                table: "PriceLists",
                column: "ModuleId",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BillingDiscounts");

            migrationBuilder.DropTable(
                name: "BillingTypes");

            migrationBuilder.DropTable(
                name: "ClientBillPayment");

            migrationBuilder.DropTable(
                name: "ClientBills");

            migrationBuilder.DropTable(
                name: "ItemTypeSubTypes");

            migrationBuilder.DropTable(
                name: "PriceLists");

            migrationBuilder.DropTable(
                name: "PaymentTypes");

            migrationBuilder.DropTable(
                name: "ItemTypes");

            migrationBuilder.DropTable(
                name: "Modules");

            migrationBuilder.DropTable(
                name: "ItemMasters");

            migrationBuilder.DropTable(
                name: "ClientBillingItems");

            migrationBuilder.DropTable(
                name: "ItemConfigurations");
        }
    }
}
