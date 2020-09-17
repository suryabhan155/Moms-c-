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

                    b.Property<Guid?>("IcdCodeSubBlockId")
                        .HasColumnType("uuid");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.Property<Guid>("SubBlockId")
                        .HasColumnType("uuid");

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

                    b.Property<Guid>("ChapterId")
                        .HasColumnType("uuid");

                    b.Property<string>("Code")
                        .HasColumnType("text");

                    b.Property<DateTime>("CreateDate")
                        .HasColumnType("timestamp without time zone");

                    b.Property<Guid?>("IcdCodeChapterId")
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

                    b.Property<Guid>("BlockId")
                        .HasColumnType("uuid");

                    b.Property<string>("Code")
                        .HasColumnType("text");

                    b.Property<DateTime>("CreateDate")
                        .HasColumnType("timestamp without time zone");

                    b.Property<Guid?>("IcdCodeBlockId")
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

            modelBuilder.Entity("Moms.Lookup.Core.Domain.Options.Models.LookupOption", b =>
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

                    b.Property<string>("LookupName")
                        .HasColumnType("text");

                    b.Property<string>("LookupNameAlias")
                        .HasColumnType("text");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uuid");

                    b.Property<bool>("Void")
                        .HasColumnType("boolean");

                    b.Property<DateTime?>("VoidDate")
                        .HasColumnType("timestamp without time zone");

                    b.HasKey("Id");

                    b.HasIndex("LookupItemId");

                    b.HasIndex("LookupMasterId");

                    b.ToTable("LookupOptions");
                });

            modelBuilder.Entity("Moms.Lookup.Core.Domain.ICD.Models.IcdCode", b =>
                {
                    b.HasOne("Moms.Lookup.Core.Domain.ICD.Models.IcdCodeSubBlock", "IcdCodeSubBlock")
                        .WithMany("Guardians")
                        .HasForeignKey("IcdCodeSubBlockId");
                });

            modelBuilder.Entity("Moms.Lookup.Core.Domain.ICD.Models.IcdCodeBlock", b =>
                {
                    b.HasOne("Moms.Lookup.Core.Domain.ICD.Models.IcdCodeChapter", "IcdCodeChapter")
                        .WithMany("Guardians")
                        .HasForeignKey("IcdCodeChapterId");
                });

            modelBuilder.Entity("Moms.Lookup.Core.Domain.ICD.Models.IcdCodeSubBlock", b =>
                {
                    b.HasOne("Moms.Lookup.Core.Domain.ICD.Models.IcdCodeBlock", "IcdCodeBlock")
                        .WithMany("Guardians")
                        .HasForeignKey("IcdCodeBlockId");
                });

            modelBuilder.Entity("Moms.Lookup.Core.Domain.Options.Models.LookupOption", b =>
                {
                    b.HasOne("Moms.Lookup.Core.Domain.Options.Models.LookupItem", "lookupItem")
                        .WithMany("lookupOptions")
                        .HasForeignKey("LookupItemId")
                        .OnDelete(DeleteBehavior.SetNull)
                        .IsRequired();

                    b.HasOne("Moms.Lookup.Core.Domain.Options.Models.LookupMaster", "lookupMater")
                        .WithMany("LookupOption")
                        .HasForeignKey("LookupMasterId")
                        .OnDelete(DeleteBehavior.SetNull)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
