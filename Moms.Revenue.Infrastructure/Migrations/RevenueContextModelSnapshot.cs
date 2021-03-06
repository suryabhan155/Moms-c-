// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Moms.Revenue.Infrastructure.Persistence;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace Moms.Revenue.Infrastructure.Migrations
{
    [DbContext(typeof(RevenueContext))]
    partial class RevenueContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn)
                .HasAnnotation("ProductVersion", "3.1.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            modelBuilder.Entity("Moms.Revenue.Core.Domain.Billing.Models.BillingDiscount", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<DateTime>("CreateDate")
                        .HasColumnType("timestamp without time zone");

                    b.Property<bool>("IsPercentage")
                        .HasColumnType("boolean");

                    b.Property<decimal>("MaxDiscount")
                        .HasColumnType("numeric");

                    b.Property<decimal>("MinDiscount")
                        .HasColumnType("numeric");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.Property<bool>("NeedsApproval")
                        .HasColumnType("boolean");

                    b.Property<bool>("Status")
                        .HasColumnType("boolean");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uuid");

                    b.Property<bool>("Void")
                        .HasColumnType("boolean");

                    b.Property<DateTime?>("VoidDate")
                        .HasColumnType("timestamp without time zone");

                    b.HasKey("Id");

                    b.ToTable("BillingDiscounts");
                });

            modelBuilder.Entity("Moms.Revenue.Core.Domain.Billing.Models.BillingItemConfiguration", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<DateTime>("CreateDate")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("DispensingUnit")
                        .HasColumnType("text");

                    b.Property<Guid>("ItemMasterId")
                        .HasColumnType("uuid");

                    b.Property<int>("MaxStock")
                        .HasColumnType("integer");

                    b.Property<int>("MinStock")
                        .HasColumnType("integer");

                    b.Property<string>("PurchaseUnit")
                        .HasColumnType("text");

                    b.Property<decimal>("PurchaseUnitPrice")
                        .HasColumnType("numeric");

                    b.Property<string>("QuantityPerDispenseUnit")
                        .HasColumnType("text");

                    b.Property<decimal>("QuantityPerPurchaseUnit")
                        .HasColumnType("numeric");

                    b.Property<bool>("Status")
                        .HasColumnType("boolean");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uuid");

                    b.Property<bool>("Void")
                        .HasColumnType("boolean");

                    b.Property<DateTime?>("VoidDate")
                        .HasColumnType("timestamp without time zone");

                    b.HasKey("Id");

                    b.ToTable("BillingItemConfigurations");
                });

            modelBuilder.Entity("Moms.Revenue.Core.Domain.Billing.Models.BillingItemMaster", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Abbreviation")
                        .HasColumnType("text");

                    b.Property<Guid?>("BillingItemConfigurationId")
                        .HasColumnType("uuid");

                    b.Property<DateTime>("CreateDate")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("DisplayName")
                        .HasColumnType("text");

                    b.Property<string>("ItemCode")
                        .HasColumnType("text");

                    b.Property<string>("ItemDescription")
                        .HasColumnType("text");

                    b.Property<Guid>("ItemSubTypeId")
                        .HasColumnType("uuid");

                    b.Property<Guid?>("ItemTypeId")
                        .HasColumnType("uuid");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.Property<string>("Type")
                        .HasColumnType("text");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uuid");

                    b.Property<bool>("Void")
                        .HasColumnType("boolean");

                    b.Property<DateTime?>("VoidDate")
                        .HasColumnType("timestamp without time zone");

                    b.HasKey("Id");

                    b.HasIndex("BillingItemConfigurationId");

                    b.ToTable("BillingItemMasters");
                });

            modelBuilder.Entity("Moms.Revenue.Core.Domain.Billing.Models.BillingItemType", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<DateTime>("CreateDate")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.Property<bool>("Status")
                        .HasColumnType("boolean");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uuid");

                    b.Property<bool>("Void")
                        .HasColumnType("boolean");

                    b.Property<DateTime?>("VoidDate")
                        .HasColumnType("timestamp without time zone");

                    b.HasKey("Id");

                    b.ToTable("BillingItemTypes");
                });

            modelBuilder.Entity("Moms.Revenue.Core.Domain.Billing.Models.BillingMaster", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<DateTime>("CreateDate")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.Property<bool>("Status")
                        .HasColumnType("boolean");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uuid");

                    b.Property<bool>("Void")
                        .HasColumnType("boolean");

                    b.Property<DateTime?>("VoidDate")
                        .HasColumnType("timestamp without time zone");

                    b.HasKey("Id");

                    b.ToTable("BillingMasters");
                });

            modelBuilder.Entity("Moms.Revenue.Core.Domain.Billing.Models.BillingSubItemType", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<DateTime>("CreateDate")
                        .HasColumnType("timestamp without time zone");

                    b.Property<Guid>("ItemTypeID")
                        .HasColumnType("uuid");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.Property<bool>("Status")
                        .HasColumnType("boolean");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uuid");

                    b.Property<bool>("Void")
                        .HasColumnType("boolean");

                    b.Property<DateTime?>("VoidDate")
                        .HasColumnType("timestamp without time zone");

                    b.HasKey("Id");

                    b.ToTable("BillingSubItemTypes");
                });

            modelBuilder.Entity("Moms.Revenue.Core.Domain.Billing.Models.BillingType", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<DateTime>("CreateDate")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.Property<bool>("Status")
                        .HasColumnType("boolean");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uuid");

                    b.Property<bool>("Void")
                        .HasColumnType("boolean");

                    b.Property<DateTime?>("VoidDate")
                        .HasColumnType("timestamp without time zone");

                    b.HasKey("Id");

                    b.ToTable("BillingTypes");
                });

            modelBuilder.Entity("Moms.Revenue.Core.Domain.Billing.Models.ClientBill", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("BillNumber")
                        .HasColumnType("text");

                    b.Property<decimal>("BillTotal")
                        .HasColumnType("numeric");

                    b.Property<DateTime>("BillingDate")
                        .HasColumnType("timestamp without time zone");

                    b.Property<DateTime>("CreateDate")
                        .HasColumnType("timestamp without time zone");

                    b.Property<Guid>("PatientId")
                        .HasColumnType("uuid");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uuid");

                    b.Property<bool>("Void")
                        .HasColumnType("boolean");

                    b.Property<DateTime?>("VoidDate")
                        .HasColumnType("timestamp without time zone");

                    b.HasKey("Id");

                    b.ToTable("ClientBills");
                });

            modelBuilder.Entity("Moms.Revenue.Core.Domain.Billing.Models.ClientBillPayment", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<decimal>("Amount")
                        .HasColumnType("numeric");

                    b.Property<Guid>("ClientBillingId")
                        .HasColumnType("uuid");

                    b.Property<DateTime>("CreateDate")
                        .HasColumnType("timestamp without time zone");

                    b.Property<decimal>("DiscountedAmount")
                        .HasColumnType("numeric");

                    b.Property<Guid>("ItemMasterId")
                        .HasColumnType("uuid");

                    b.Property<Guid>("ModuleId")
                        .HasColumnType("uuid");

                    b.Property<Guid>("PaymentTypeId")
                        .HasColumnType("uuid");

                    b.Property<bool>("Status")
                        .HasColumnType("boolean");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uuid");

                    b.Property<bool>("Void")
                        .HasColumnType("boolean");

                    b.Property<DateTime?>("VoidDate")
                        .HasColumnType("timestamp without time zone");

                    b.HasKey("Id");

                    b.HasIndex("ItemMasterId")
                        .IsUnique();

                    b.HasIndex("ModuleId");

                    b.HasIndex("PaymentTypeId");

                    b.ToTable("ClientBillPayment");
                });

            modelBuilder.Entity("Moms.Revenue.Core.Domain.Billing.Models.ClientBillingItem", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<Guid>("BillId")
                        .HasColumnType("uuid");

                    b.Property<DateTime>("CreateDate")
                        .HasColumnType("timestamp without time zone");

                    b.Property<Guid>("ItemMasterId")
                        .HasColumnType("uuid");

                    b.Property<decimal>("Price")
                        .HasColumnType("numeric");

                    b.Property<decimal>("Quantity")
                        .HasColumnType("numeric");

                    b.Property<bool>("Status")
                        .HasColumnType("boolean");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uuid");

                    b.Property<bool>("Void")
                        .HasColumnType("boolean");

                    b.Property<DateTime?>("VoidDate")
                        .HasColumnType("timestamp without time zone");

                    b.HasKey("Id");

                    b.ToTable("ClientBillingItems");
                });

            modelBuilder.Entity("Moms.Revenue.Core.Domain.Billing.Models.PaymentMaster", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<DateTime>("CreateDate")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.Property<bool>("Status")
                        .HasColumnType("boolean");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uuid");

                    b.Property<bool>("Void")
                        .HasColumnType("boolean");

                    b.Property<DateTime?>("VoidDate")
                        .HasColumnType("timestamp without time zone");

                    b.HasKey("Id");

                    b.ToTable("PaymentMasters");
                });

            modelBuilder.Entity("Moms.Revenue.Core.Domain.Billing.Models.PaymentType", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<DateTime>("CreateDate")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("Description")
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uuid");

                    b.Property<bool>("Void")
                        .HasColumnType("boolean");

                    b.Property<DateTime?>("VoidDate")
                        .HasColumnType("timestamp without time zone");

                    b.HasKey("Id");

                    b.ToTable("PaymentTypes");
                });

            modelBuilder.Entity("Moms.Revenue.Core.Domain.Billing.Models.PriceList", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<Guid>("BillTypeId")
                        .HasColumnType("uuid");

                    b.Property<Guid?>("BillingTypeId")
                        .HasColumnType("uuid");

                    b.Property<Guid?>("ClientBillingItemsId")
                        .HasColumnType("uuid");

                    b.Property<DateTime>("CreateDate")
                        .HasColumnType("timestamp without time zone");

                    b.Property<DateTime>("EffectiveDate")
                        .HasColumnType("timestamp without time zone");

                    b.Property<bool>("IsDiscounted")
                        .HasColumnType("boolean");

                    b.Property<Guid>("ItemMasterId")
                        .HasColumnType("uuid");

                    b.Property<string>("ItemName")
                        .HasColumnType("text");

                    b.Property<Guid>("ModuleId")
                        .HasColumnType("uuid");

                    b.Property<decimal>("SellingPrice")
                        .HasColumnType("numeric");

                    b.Property<bool>("Status")
                        .HasColumnType("boolean");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uuid");

                    b.Property<bool>("Void")
                        .HasColumnType("boolean");

                    b.Property<DateTime?>("VoidDate")
                        .HasColumnType("timestamp without time zone");

                    b.HasKey("Id");

                    b.HasIndex("BillingTypeId");

                    b.HasIndex("ClientBillingItemsId");

                    b.HasIndex("ItemMasterId")
                        .IsUnique();

                    b.HasIndex("ModuleId");

                    b.ToTable("PriceLists");
                });

            modelBuilder.Entity("Moms.Revenue.Core.Domain.Billing.Models.PriceMaster", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<Guid>("BillTypeId")
                        .HasColumnType("uuid");

                    b.Property<DateTime>("CreateDate")
                        .HasColumnType("timestamp without time zone");

                    b.Property<DateTime>("EffectiveDate")
                        .HasColumnType("timestamp without time zone");

                    b.Property<bool>("IsDiscounted")
                        .HasColumnType("boolean");

                    b.Property<Guid>("ItemMasterId")
                        .HasColumnType("uuid");

                    b.Property<string>("ItemName")
                        .HasColumnType("text");

                    b.Property<Guid>("ModuleId")
                        .HasColumnType("uuid");

                    b.Property<decimal>("SellingPrice")
                        .HasColumnType("numeric");

                    b.Property<bool>("Status")
                        .HasColumnType("boolean");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uuid");

                    b.Property<bool>("Void")
                        .HasColumnType("boolean");

                    b.Property<DateTime?>("VoidDate")
                        .HasColumnType("timestamp without time zone");

                    b.HasKey("Id");

                    b.ToTable("PriceMasters");
                });

            modelBuilder.Entity("Moms.Revenue.Core.Domain.Item.Models.ItemConfiguration", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<DateTime>("CreateDate")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("DispensingUnit")
                        .HasColumnType("text");

                    b.Property<Guid>("ItemMasterId")
                        .HasColumnType("uuid");

                    b.Property<int>("MaxStock")
                        .HasColumnType("integer");

                    b.Property<int>("MinStock")
                        .HasColumnType("integer");

                    b.Property<string>("PurchaseUnit")
                        .HasColumnType("text");

                    b.Property<decimal>("PurchaseUnitPrice")
                        .HasColumnType("numeric");

                    b.Property<string>("QuantityPerDispenseUnit")
                        .HasColumnType("text");

                    b.Property<decimal>("QuantityPerPurchaseUnit")
                        .HasColumnType("numeric");

                    b.Property<bool>("Status")
                        .HasColumnType("boolean");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uuid");

                    b.Property<bool>("Void")
                        .HasColumnType("boolean");

                    b.Property<DateTime?>("VoidDate")
                        .HasColumnType("timestamp without time zone");

                    b.HasKey("Id");

                    b.ToTable("ItemConfigurations");
                });

            modelBuilder.Entity("Moms.Revenue.Core.Domain.Item.Models.ItemMaster", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Abbreviation")
                        .HasColumnType("text");

                    b.Property<DateTime>("CreateDate")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("DisplayName")
                        .HasColumnType("text");

                    b.Property<string>("ItemCode")
                        .HasColumnType("text");

                    b.Property<Guid?>("ItemConfigurationId")
                        .HasColumnType("uuid");

                    b.Property<string>("ItemDescription")
                        .HasColumnType("text");

                    b.Property<Guid>("ItemSubTypeId")
                        .HasColumnType("uuid");

                    b.Property<Guid?>("ItemTypeId")
                        .HasColumnType("uuid");

                    b.Property<Guid?>("ItemTypeSubTypeId")
                        .HasColumnType("uuid");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.Property<Guid>("Type")
                        .HasColumnType("uuid");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uuid");

                    b.Property<bool>("Void")
                        .HasColumnType("boolean");

                    b.Property<DateTime?>("VoidDate")
                        .HasColumnType("timestamp without time zone");

                    b.HasKey("Id");

                    b.HasIndex("ItemConfigurationId");

                    b.HasIndex("ItemTypeId");

                    b.HasIndex("ItemTypeSubTypeId");

                    b.ToTable("ItemMasters");
                });

            modelBuilder.Entity("Moms.Revenue.Core.Domain.Item.Models.ItemType", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<DateTime>("CreateDate")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.Property<bool>("Status")
                        .HasColumnType("boolean");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uuid");

                    b.Property<bool>("Void")
                        .HasColumnType("boolean");

                    b.Property<DateTime?>("VoidDate")
                        .HasColumnType("timestamp without time zone");

                    b.HasKey("Id");

                    b.ToTable("ItemTypes");
                });

            modelBuilder.Entity("Moms.Revenue.Core.Domain.Item.Models.ItemTypeSubType", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<DateTime>("CreateDate")
                        .HasColumnType("timestamp without time zone");

                    b.Property<Guid>("ItemTypeId")
                        .HasColumnType("uuid");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.Property<bool>("Status")
                        .HasColumnType("boolean");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uuid");

                    b.Property<bool>("Void")
                        .HasColumnType("boolean");

                    b.Property<DateTime?>("VoidDate")
                        .HasColumnType("timestamp without time zone");

                    b.HasKey("Id");

                    b.HasIndex("ItemTypeId");

                    b.ToTable("ItemTypeSubTypes");
                });

            modelBuilder.Entity("Moms.Revenue.Core.Domain.Item.Models.Module", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<DateTime>("CreateDate")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<bool>("Status")
                        .HasColumnType("boolean");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uuid");

                    b.Property<bool>("Void")
                        .HasColumnType("boolean");

                    b.Property<DateTime?>("VoidDate")
                        .HasColumnType("timestamp without time zone");

                    b.HasKey("Id");

                    b.ToTable("Modules");
                });

            modelBuilder.Entity("Moms.Revenue.Core.Domain.Billing.Models.BillingItemMaster", b =>
                {
                    b.HasOne("Moms.Revenue.Core.Domain.Billing.Models.BillingItemConfiguration", null)
                        .WithMany("BillingItemMasters")
                        .HasForeignKey("BillingItemConfigurationId");
                });

            modelBuilder.Entity("Moms.Revenue.Core.Domain.Billing.Models.ClientBillPayment", b =>
                {
                    b.HasOne("Moms.Revenue.Core.Domain.Item.Models.ItemMaster", "ItemMaster")
                        .WithOne("ClientBillPayments")
                        .HasForeignKey("Moms.Revenue.Core.Domain.Billing.Models.ClientBillPayment", "ItemMasterId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Moms.Revenue.Core.Domain.Item.Models.Module", "Module")
                        .WithMany("ClientBillPayments")
                        .HasForeignKey("ModuleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Moms.Revenue.Core.Domain.Billing.Models.PaymentType", "PaymentType")
                        .WithMany("ClientBillPayments")
                        .HasForeignKey("PaymentTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Moms.Revenue.Core.Domain.Billing.Models.PriceList", b =>
                {
                    b.HasOne("Moms.Revenue.Core.Domain.Billing.Models.BillingType", "BillingType")
                        .WithMany("PriceList")
                        .HasForeignKey("BillingTypeId");

                    b.HasOne("Moms.Revenue.Core.Domain.Billing.Models.ClientBillingItem", "ClientBillingItems")
                        .WithMany()
                        .HasForeignKey("ClientBillingItemsId");

                    b.HasOne("Moms.Revenue.Core.Domain.Item.Models.ItemMaster", "ItemMaster")
                        .WithOne("PriceList")
                        .HasForeignKey("Moms.Revenue.Core.Domain.Billing.Models.PriceList", "ItemMasterId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Moms.Revenue.Core.Domain.Item.Models.Module", "Module")
                        .WithMany("PriceList")
                        .HasForeignKey("ModuleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Moms.Revenue.Core.Domain.Item.Models.ItemMaster", b =>
                {
                    b.HasOne("Moms.Revenue.Core.Domain.Item.Models.ItemConfiguration", "ItemConfiguration")
                        .WithMany("ItemMasters")
                        .HasForeignKey("ItemConfigurationId");

                    b.HasOne("Moms.Revenue.Core.Domain.Item.Models.ItemType", "ItemType")
                        .WithMany("ItemMaster")
                        .HasForeignKey("ItemTypeId");

                    b.HasOne("Moms.Revenue.Core.Domain.Item.Models.ItemTypeSubType", "ItemTypeSubType")
                        .WithMany("ItemMaster")
                        .HasForeignKey("ItemTypeSubTypeId");
                });

            modelBuilder.Entity("Moms.Revenue.Core.Domain.Item.Models.ItemTypeSubType", b =>
                {
                    b.HasOne("Moms.Revenue.Core.Domain.Item.Models.ItemType", "ItemType")
                        .WithMany("ItemTypeSubType")
                        .HasForeignKey("ItemTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
