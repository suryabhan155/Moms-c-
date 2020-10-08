﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Moms.Lookup.Infrastructure.Persistence;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace Moms.Lookup.Infrastructure.Migrations
{
    [DbContext(typeof(LookupContext))]
    partial class LookupContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn)
                .HasAnnotation("ProductVersion", "3.1.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            modelBuilder.Entity("Moms.Lookup.Core.Domain.ICD.Models.IcdCode", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Code")
                        .HasColumnType("text");

                    b.Property<DateTime>("CreateDate")
                        .HasColumnType("timestamp without time zone");

                    b.Property<Guid>("IcdCodeSubBlockId")
                        .HasColumnType("uuid");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uuid");

                    b.Property<bool>("Void")
                        .HasColumnType("boolean");

                    b.Property<DateTime?>("VoidDate")
                        .HasColumnType("timestamp without time zone");

                    b.HasKey("Id");

                    b.HasIndex("IcdCodeSubBlockId");

                    b.ToTable("IcdCodes");
                });

            modelBuilder.Entity("Moms.Lookup.Core.Domain.ICD.Models.IcdCodeBlock", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Code")
                        .HasColumnType("text");

                    b.Property<DateTime>("CreateDate")
                        .HasColumnType("timestamp without time zone");

                    b.Property<Guid>("IcdCodeChapterId")
                        .HasColumnType("uuid");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uuid");

                    b.Property<bool>("Void")
                        .HasColumnType("boolean");

                    b.Property<DateTime?>("VoidDate")
                        .HasColumnType("timestamp without time zone");

                    b.HasKey("Id");

                    b.HasIndex("IcdCodeChapterId");

                    b.ToTable("IcdCodeBlocks");
                });

            modelBuilder.Entity("Moms.Lookup.Core.Domain.ICD.Models.IcdCodeChapter", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<int>("Code")
                        .HasColumnType("integer");

                    b.Property<DateTime>("CreateDate")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uuid");

                    b.Property<bool>("Void")
                        .HasColumnType("boolean");

                    b.Property<DateTime?>("VoidDate")
                        .HasColumnType("timestamp without time zone");

                    b.HasKey("Id");

                    b.ToTable("IcdCodeChapters");
                });

            modelBuilder.Entity("Moms.Lookup.Core.Domain.ICD.Models.IcdCodeSubBlock", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Code")
                        .HasColumnType("text");

                    b.Property<DateTime>("CreateDate")
                        .HasColumnType("timestamp without time zone");

                    b.Property<Guid>("IcdCodeBlockId")
                        .HasColumnType("uuid");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uuid");

                    b.Property<bool>("Void")
                        .HasColumnType("boolean");

                    b.Property<DateTime?>("VoidDate")
                        .HasColumnType("timestamp without time zone");

                    b.HasKey("Id");

                    b.HasIndex("IcdCodeBlockId");

                    b.ToTable("IcdCodeSubBlocks");
                });

            modelBuilder.Entity("Moms.Lookup.Core.Domain.Options.Models.CountyLookup", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<int>("CountyCode")
                        .HasColumnType("integer");

                    b.Property<string>("CountyName")
                        .HasColumnType("text");

                    b.Property<Guid>("CountyUid")
                        .HasColumnType("uuid");

                    b.Property<DateTime>("CreateDate")
                        .HasColumnType("timestamp without time zone");

                    b.Property<int>("SubCountyCode")
                        .HasColumnType("integer");

                    b.Property<string>("SubCountyName")
                        .HasColumnType("text");

                    b.Property<Guid>("SubCountyUid")
                        .HasColumnType("uuid");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uuid");

                    b.Property<bool>("Void")
                        .HasColumnType("boolean");

                    b.Property<DateTime?>("VoidDate")
                        .HasColumnType("timestamp without time zone");

                    b.Property<int>("WardCode")
                        .HasColumnType("integer");

                    b.Property<string>("WardName")
                        .HasColumnType("text");

                    b.Property<Guid>("WardUid")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.ToTable("CountyLookups");
                });

            modelBuilder.Entity("Moms.Lookup.Core.Domain.Options.Models.LookupItem", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Alias")
                        .HasColumnType("text");

                    b.Property<DateTime>("CreateDate")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uuid");

                    b.Property<bool>("Void")
                        .HasColumnType("boolean");

                    b.Property<DateTime?>("VoidDate")
                        .HasColumnType("timestamp without time zone");

                    b.HasKey("Id");

                    b.ToTable("LookupItems");
                });

            modelBuilder.Entity("Moms.Lookup.Core.Domain.Options.Models.LookupMaster", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Alias")
                        .HasColumnType("text");

                    b.Property<DateTime>("CreateDate")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uuid");

                    b.Property<bool>("Void")
                        .HasColumnType("boolean");

                    b.Property<DateTime?>("VoidDate")
                        .HasColumnType("timestamp without time zone");

                    b.HasKey("Id");

                    b.ToTable("LookupMasters");
                });

            modelBuilder.Entity("Moms.Lookup.Core.Domain.Options.Models.LookupMasterItem", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<DateTime>("CreateDate")
                        .HasColumnType("timestamp without time zone");

                    b.Property<Guid>("LookupItemId")
                        .HasColumnType("uuid");

                    b.Property<Guid>("LookupMasterId")
                        .HasColumnType("uuid");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uuid");

                    b.Property<bool>("Void")
                        .HasColumnType("boolean");

                    b.Property<DateTime?>("VoidDate")
                        .HasColumnType("timestamp without time zone");

                    b.HasKey("Id");

                    b.ToTable("LookupMasterItems");
                });

            modelBuilder.Entity("Moms.Lookup.Core.Domain.Options.Models.LookupOption", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<DateTime>("CreateDate")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("LookupItemAlias")
                        .HasColumnName("lookupitemalias")
                        .HasColumnType("text");

                    b.Property<Guid>("LookupItemId")
                        .HasColumnName("lookupitemid")
                        .HasColumnType("uuid");

                    b.Property<string>("LookupItemName")
                        .HasColumnName("lookupitemname")
                        .HasColumnType("text");

                    b.Property<string>("LookupMasterAlias")
                        .HasColumnName("lookupmasteralias")
                        .HasColumnType("text");

                    b.Property<Guid>("LookupMasterId")
                        .HasColumnName("lookupmasterid")
                        .HasColumnType("uuid");

                    b.Property<string>("LookupMasterName")
                        .HasColumnName("lookupmastername")
                        .HasColumnType("text");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uuid");

                    b.Property<bool>("Void")
                        .HasColumnType("boolean");

                    b.Property<DateTime?>("VoidDate")
                        .HasColumnType("timestamp without time zone");

                    b.HasKey("Id");

                    b.ToTable("lookupoptions");
                });

            modelBuilder.Entity("Moms.Lookup.Core.Domain.ICD.Models.IcdCode", b =>
                {
                    b.HasOne("Moms.Lookup.Core.Domain.ICD.Models.IcdCodeSubBlock", "IcdCodeSubBlock")
                        .WithMany("IcdCodes")
                        .HasForeignKey("IcdCodeSubBlockId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Moms.Lookup.Core.Domain.ICD.Models.IcdCodeBlock", b =>
                {
                    b.HasOne("Moms.Lookup.Core.Domain.ICD.Models.IcdCodeChapter", "IcdCodeChapter")
                        .WithMany("Guardians")
                        .HasForeignKey("IcdCodeChapterId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Moms.Lookup.Core.Domain.ICD.Models.IcdCodeSubBlock", b =>
                {
                    b.HasOne("Moms.Lookup.Core.Domain.ICD.Models.IcdCodeBlock", "IcdCodeBlock")
                        .WithMany("IcdCodeSubBlocks")
                        .HasForeignKey("IcdCodeBlockId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
