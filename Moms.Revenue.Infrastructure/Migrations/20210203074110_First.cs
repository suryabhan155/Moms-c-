using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Moms.Revenue.Infrastructure.Migrations
{
    public partial class First : Migration
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
                name: "BillingItemConfigurations",
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
                    table.PrimaryKey("PK_BillingItemConfigurations", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "BillingItemTypes",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CreateDate = table.Column<DateTime>(nullable: false),
                    Void = table.Column<bool>(nullable: false),
                    VoidDate = table.Column<DateTime>(nullable: true),
                    UserId = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Status = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BillingItemTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "BillingMasters",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CreateDate = table.Column<DateTime>(nullable: false),
                    Void = table.Column<bool>(nullable: false),
                    VoidDate = table.Column<DateTime>(nullable: true),
                    UserId = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Status = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BillingMasters", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "BillingSubItemTypes",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CreateDate = table.Column<DateTime>(nullable: false),
                    Void = table.Column<bool>(nullable: false),
                    VoidDate = table.Column<DateTime>(nullable: true),
                    UserId = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    ItemTypeID = table.Column<Guid>(nullable: false),
                    Status = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BillingSubItemTypes", x => x.Id);
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
                    Status = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BillingTypes", x => x.Id);
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
                name: "ItemTypes",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CreateDate = table.Column<DateTime>(nullable: false),
                    Void = table.Column<bool>(nullable: false),
                    VoidDate = table.Column<DateTime>(nullable: true),
                    UserId = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Status = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ItemTypes", x => x.Id);
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
                name: "PaymentMasters",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CreateDate = table.Column<DateTime>(nullable: false),
                    Void = table.Column<bool>(nullable: false),
                    VoidDate = table.Column<DateTime>(nullable: true),
                    UserId = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Status = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PaymentMasters", x => x.Id);
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
                name: "PriceMasters",
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
                    Status = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PriceMasters", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "BillingItemMasters",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CreateDate = table.Column<DateTime>(nullable: false),
                    Void = table.Column<bool>(nullable: false),
                    VoidDate = table.Column<DateTime>(nullable: true),
                    UserId = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    DisplayName = table.Column<string>(nullable: true),
                    ItemTypeId = table.Column<Guid>(nullable: true),
                    ItemSubTypeId = table.Column<Guid>(nullable: false),
                    ItemCode = table.Column<string>(nullable: true),
                    ItemDescription = table.Column<string>(nullable: true),
                    Abbreviation = table.Column<string>(nullable: true),
                    Type = table.Column<string>(nullable: true),
                    BillingItemConfigurationId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BillingItemMasters", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BillingItemMasters_BillingItemConfigurations_BillingItemCon~",
                        column: x => x.BillingItemConfigurationId,
                        principalTable: "BillingItemConfigurations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
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
                    Status = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ItemTypeSubTypes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ItemTypeSubTypes_ItemTypes_ItemTypeId",
                        column: x => x.ItemTypeId,
                        principalTable: "ItemTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
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
                    ItemTypeId = table.Column<Guid>(nullable: true),
                    ItemSubTypeId = table.Column<Guid>(nullable: false),
                    ItemCode = table.Column<string>(nullable: true),
                    ItemDescription = table.Column<string>(nullable: true),
                    Abbreviation = table.Column<string>(nullable: true),
                    Type = table.Column<Guid>(nullable: false),
                    ItemTypeSubTypeId = table.Column<Guid>(nullable: true),
                    ItemConfigurationId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ItemMasters", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ItemMasters_ItemConfigurations_ItemConfigurationId",
                        column: x => x.ItemConfigurationId,
                        principalTable: "ItemConfigurations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ItemMasters_ItemTypes_ItemTypeId",
                        column: x => x.ItemTypeId,
                        principalTable: "ItemTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ItemMasters_ItemTypeSubTypes_ItemTypeSubTypeId",
                        column: x => x.ItemTypeSubTypeId,
                        principalTable: "ItemTypeSubTypes",
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
                    BillingTypeId = table.Column<Guid>(nullable: true),
                    ClientBillingItemsId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PriceLists", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PriceLists_BillingTypes_BillingTypeId",
                        column: x => x.BillingTypeId,
                        principalTable: "BillingTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
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

            migrationBuilder.CreateIndex(
                name: "IX_BillingItemMasters_BillingItemConfigurationId",
                table: "BillingItemMasters",
                column: "BillingItemConfigurationId");

            migrationBuilder.CreateIndex(
                name: "IX_ClientBillPayment_ItemMasterId",
                table: "ClientBillPayment",
                column: "ItemMasterId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ClientBillPayment_ModuleId",
                table: "ClientBillPayment",
                column: "ModuleId");

            migrationBuilder.CreateIndex(
                name: "IX_ClientBillPayment_PaymentTypeId",
                table: "ClientBillPayment",
                column: "PaymentTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_ItemMasters_ItemConfigurationId",
                table: "ItemMasters",
                column: "ItemConfigurationId");

            migrationBuilder.CreateIndex(
                name: "IX_ItemMasters_ItemTypeId",
                table: "ItemMasters",
                column: "ItemTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_ItemMasters_ItemTypeSubTypeId",
                table: "ItemMasters",
                column: "ItemTypeSubTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_ItemTypeSubTypes_ItemTypeId",
                table: "ItemTypeSubTypes",
                column: "ItemTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_PriceLists_BillingTypeId",
                table: "PriceLists",
                column: "BillingTypeId");

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
                column: "ModuleId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BillingDiscounts");

            migrationBuilder.DropTable(
                name: "BillingItemMasters");

            migrationBuilder.DropTable(
                name: "BillingItemTypes");

            migrationBuilder.DropTable(
                name: "BillingMasters");

            migrationBuilder.DropTable(
                name: "BillingSubItemTypes");

            migrationBuilder.DropTable(
                name: "ClientBillPayment");

            migrationBuilder.DropTable(
                name: "ClientBills");

            migrationBuilder.DropTable(
                name: "PaymentMasters");

            migrationBuilder.DropTable(
                name: "PriceLists");

            migrationBuilder.DropTable(
                name: "PriceMasters");

            migrationBuilder.DropTable(
                name: "BillingItemConfigurations");

            migrationBuilder.DropTable(
                name: "PaymentTypes");

            migrationBuilder.DropTable(
                name: "BillingTypes");

            migrationBuilder.DropTable(
                name: "ClientBillingItems");

            migrationBuilder.DropTable(
                name: "ItemMasters");

            migrationBuilder.DropTable(
                name: "Modules");

            migrationBuilder.DropTable(
                name: "ItemConfigurations");

            migrationBuilder.DropTable(
                name: "ItemTypeSubTypes");

            migrationBuilder.DropTable(
                name: "ItemTypes");
        }
    }
}
