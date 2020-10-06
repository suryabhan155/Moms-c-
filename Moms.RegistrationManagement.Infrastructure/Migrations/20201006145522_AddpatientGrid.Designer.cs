﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Moms.RegistrationManagement.Infrastructure.Persistence;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using NpgsqlTypes;

namespace Moms.RegistrationManagement.Infrastructure.Migrations
{
    [DbContext(typeof(RegistrationContext))]
    [Migration("20201006145522_AddpatientGrid")]
    partial class AddpatientGrid
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn)
                .HasAnnotation("ProductVersion", "3.1.6")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

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

                    b.Property<Guid?>("PatientId")
                        .HasColumnType("uuid");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uuid");

                    b.Property<bool>("Void")
                        .HasColumnType("boolean");

                    b.Property<DateTime?>("VoidDate")
                        .HasColumnType("timestamp without time zone");

                    b.HasKey("Id");

                    b.HasIndex("PatientId");

                    b.ToTable("LookupItem");
                });

            modelBuilder.Entity("Moms.RegistrationManagement.Core.Domain.Facilities.Models.Clinic", b =>
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

                    b.ToTable("Clinics");
                });

            modelBuilder.Entity("Moms.RegistrationManagement.Core.Domain.Patient.Models.Contact", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Address")
                        .HasColumnType("text");

                    b.Property<Guid>("City")
                        .HasColumnType("uuid");

                    b.Property<Guid>("County")
                        .HasColumnType("uuid");

                    b.Property<DateTime>("CreateDate")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("Email")
                        .HasColumnType("text");

                    b.Property<string>("HomePhone")
                        .HasColumnType("text");

                    b.Property<string>("MobilePhone")
                        .HasColumnType("text");

                    b.Property<Guid>("PatientId")
                        .HasColumnType("uuid");

                    b.Property<string>("PostalCode")
                        .HasColumnType("text");

                    b.Property<Guid>("SubCounty")
                        .HasColumnType("uuid");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uuid");

                    b.Property<bool>("Void")
                        .HasColumnType("boolean");

                    b.Property<DateTime?>("VoidDate")
                        .HasColumnType("timestamp without time zone");

                    b.HasKey("Id");

                    b.HasIndex("PatientId");

                    b.ToTable("Contacts");
                });

            modelBuilder.Entity("Moms.RegistrationManagement.Core.Domain.Patient.Models.Death", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<DateTime>("CreateDate")
                        .HasColumnType("timestamp without time zone");

                    b.Property<DateTime>("DateDeceased")
                        .HasColumnType("timestamp without time zone");

                    b.Property<Guid>("ICD10")
                        .HasColumnType("uuid");

                    b.Property<Guid>("PatientId")
                        .HasColumnType("uuid");

                    b.Property<Guid>("ReasonDeceased")
                        .HasColumnType("uuid");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uuid");

                    b.Property<bool>("Void")
                        .HasColumnType("boolean");

                    b.Property<DateTime?>("VoidDate")
                        .HasColumnType("timestamp without time zone");

                    b.HasKey("Id");

                    b.HasIndex("PatientId")
                        .IsUnique();

                    b.ToTable("Deaths");
                });

            modelBuilder.Entity("Moms.RegistrationManagement.Core.Domain.Patient.Models.Employer", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<Guid>("City")
                        .HasColumnType("uuid");

                    b.Property<Guid>("Country")
                        .HasColumnType("uuid");

                    b.Property<DateTime>("CreateDate")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("EmployerAddress")
                        .HasColumnType("text");

                    b.Property<string>("Employers")
                        .HasColumnType("text");

                    b.Property<string>("Industry")
                        .HasColumnType("text");

                    b.Property<string>("Occupation")
                        .HasColumnType("text");

                    b.Property<Guid>("PatientId")
                        .HasColumnType("uuid");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uuid");

                    b.Property<bool>("Void")
                        .HasColumnType("boolean");

                    b.Property<DateTime?>("VoidDate")
                        .HasColumnType("timestamp without time zone");

                    b.HasKey("Id");

                    b.HasIndex("PatientId");

                    b.ToTable("Employers");
                });

            modelBuilder.Entity("Moms.RegistrationManagement.Core.Domain.Patient.Models.Guardian", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<DateTime>("CreateDate")
                        .HasColumnType("timestamp without time zone");

                    b.Property<Guid>("PatientId")
                        .HasColumnType("uuid");

                    b.Property<Guid>("Relationship")
                        .HasColumnType("uuid");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uuid");

                    b.Property<bool>("Void")
                        .HasColumnType("boolean");

                    b.Property<DateTime?>("VoidDate")
                        .HasColumnType("timestamp without time zone");

                    b.HasKey("Id");

                    b.HasIndex("PatientId");

                    b.ToTable("Guardians");
                });

            modelBuilder.Entity("Moms.RegistrationManagement.Core.Domain.Patient.Models.Patient", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<DateTime>("CreateDate")
                        .HasColumnType("timestamp without time zone");

                    b.Property<DateTime>("DoB")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("FirstName")
                        .HasColumnType("text");

                    b.Property<string>("IdentificationNumber")
                        .HasColumnType("text");

                    b.Property<string>("LastName")
                        .HasColumnType("text");

                    b.Property<Guid>("MaritalStatus")
                        .HasColumnType("uuid");

                    b.Property<string>("MiddleName")
                        .HasColumnType("text");

                    b.Property<string>("Narrative")
                        .HasColumnType("text");

                    b.Property<string>("PatientNumber")
                        .HasColumnType("text");

                    b.Property<string>("Phone")
                        .HasColumnType("text");

                    b.Property<DateTime>("RegistrationDate")
                        .HasColumnType("timestamp without time zone");

                    b.Property<NpgsqlTsVector>("SearchVector")
                        .HasColumnType("tsvector");

                    b.Property<Guid>("Sex")
                        .HasColumnType("uuid");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uuid");

                    b.Property<bool>("Void")
                        .HasColumnType("boolean");

                    b.Property<DateTime?>("VoidDate")
                        .HasColumnType("timestamp without time zone");

                    b.HasKey("Id");

                    b.HasIndex("SearchVector")
                        .HasAnnotation("Npgsql:IndexMethod", "GIN");

                    b.ToTable("Patients");
                });

            modelBuilder.Entity("Moms.RegistrationManagement.Core.Domain.Patient.Models.PatientGrid", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<DateTime>("CreateDate")
                        .HasColumnType("timestamp without time zone");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uuid");

                    b.Property<bool>("Void")
                        .HasColumnType("boolean");

                    b.Property<DateTime?>("VoidDate")
                        .HasColumnType("timestamp without time zone");

                    b.Property<DateTime>("dob")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("firstname")
                        .HasColumnType("text");

                    b.Property<string>("identificationnumber")
                        .HasColumnType("text");

                    b.Property<string>("lastname")
                        .HasColumnType("text");

                    b.Property<string>("maritalstatus")
                        .HasColumnType("text");

                    b.Property<Guid>("maritalstatusid")
                        .HasColumnType("uuid");

                    b.Property<string>("middlename")
                        .HasColumnType("text");

                    b.Property<string>("narrative")
                        .HasColumnType("text");

                    b.Property<string>("patientnumber")
                        .HasColumnType("text");

                    b.Property<string>("phone")
                        .HasColumnType("text");

                    b.Property<DateTime>("registrationdate")
                        .HasColumnType("timestamp without time zone");

                    b.Property<NpgsqlTsVector>("searchvector")
                        .HasColumnType("tsvector");

                    b.Property<string>("sex")
                        .HasColumnType("text");

                    b.Property<Guid>("sexId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.ToTable("PatientGrids");
                });

            modelBuilder.Entity("Moms.Lookup.Core.Domain.Options.Models.LookupItem", b =>
                {
                    b.HasOne("Moms.RegistrationManagement.Core.Domain.Patient.Models.Patient", null)
                        .WithMany("LookupItems")
                        .HasForeignKey("PatientId");
                });

            modelBuilder.Entity("Moms.RegistrationManagement.Core.Domain.Patient.Models.Contact", b =>
                {
                    b.HasOne("Moms.RegistrationManagement.Core.Domain.Patient.Models.Patient", "Patient")
                        .WithMany("Contacts")
                        .HasForeignKey("PatientId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Moms.RegistrationManagement.Core.Domain.Patient.Models.Death", b =>
                {
                    b.HasOne("Moms.RegistrationManagement.Core.Domain.Patient.Models.Patient", "Patient")
                        .WithOne("Death")
                        .HasForeignKey("Moms.RegistrationManagement.Core.Domain.Patient.Models.Death", "PatientId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Moms.RegistrationManagement.Core.Domain.Patient.Models.Employer", b =>
                {
                    b.HasOne("Moms.RegistrationManagement.Core.Domain.Patient.Models.Patient", "Patient")
                        .WithMany("Employers")
                        .HasForeignKey("PatientId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Moms.RegistrationManagement.Core.Domain.Patient.Models.Guardian", b =>
                {
                    b.HasOne("Moms.RegistrationManagement.Core.Domain.Patient.Models.Patient", "Patient")
                        .WithMany("Guardians")
                        .HasForeignKey("PatientId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
