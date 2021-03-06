// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Moms.Clinical.Infrastructure.Persistence;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace Moms.Clinical.Infrastructure.Migrations
{
    [DbContext(typeof(ClinicalContext))]
    partial class ClinicalContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn)
                .HasAnnotation("ProductVersion", "3.1.6")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            modelBuilder.Entity("Moms.Clinical.Core.Domain.Consultation.Models.Consultation", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<DateTime>("ConsultationDate")
                        .HasColumnType("timestamp without time zone");

                    b.Property<bool>("ConsultationType")
                        .HasColumnType("boolean");

                    b.Property<DateTime>("CreateDate")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("Details")
                        .HasColumnType("text");

                    b.Property<Guid>("PatientId")
                        .HasColumnType("uuid");

                    b.Property<string>("Recommendations")
                        .HasColumnType("text");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uuid");

                    b.Property<bool>("Void")
                        .HasColumnType("boolean");

                    b.Property<DateTime?>("VoidDate")
                        .HasColumnType("timestamp without time zone");

                    b.HasKey("Id");

                    b.ToTable("Consultations");
                });

            modelBuilder.Entity("Moms.Clinical.Core.Domain.Consultation.Models.ConsultationComplaint", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Complaint")
                        .HasColumnType("text");

                    b.Property<Guid>("ConsultationId")
                        .HasColumnType("uuid");

                    b.Property<DateTime>("CreateDate")
                        .HasColumnType("timestamp without time zone");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("timestamp without time zone");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uuid");

                    b.Property<bool>("Void")
                        .HasColumnType("boolean");

                    b.Property<DateTime?>("VoidDate")
                        .HasColumnType("timestamp without time zone");

                    b.HasKey("Id");

                    b.HasIndex("ConsultationId");

                    b.ToTable("ConsultationComplaints");
                });

            modelBuilder.Entity("Moms.Clinical.Core.Domain.Consultation.Models.ConsultationDiagnosis", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<Guid>("ConsultationId")
                        .HasColumnType("uuid");

                    b.Property<DateTime>("CreateDate")
                        .HasColumnType("timestamp without time zone");

                    b.Property<Guid>("Diagnosis")
                        .HasColumnType("uuid");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uuid");

                    b.Property<bool>("Void")
                        .HasColumnType("boolean");

                    b.Property<DateTime?>("VoidDate")
                        .HasColumnType("timestamp without time zone");

                    b.HasKey("Id");

                    b.HasIndex("ConsultationId");

                    b.ToTable("ConsultationDiagnoses");
                });

            modelBuilder.Entity("Moms.Clinical.Core.Domain.Consultation.Models.ConsultationFinding", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<Guid>("ConsultationId")
                        .HasColumnType("uuid");

                    b.Property<DateTime>("CreateDate")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("Finding")
                        .HasColumnType("text");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uuid");

                    b.Property<bool>("Void")
                        .HasColumnType("boolean");

                    b.Property<DateTime?>("VoidDate")
                        .HasColumnType("timestamp without time zone");

                    b.HasKey("Id");

                    b.HasIndex("ConsultationId");

                    b.ToTable("ConsultationFindings");
                });

            modelBuilder.Entity("Moms.Clinical.Core.Domain.Consultation.Models.ConsultationService", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<Guid>("ConsultationId")
                        .HasColumnType("uuid");

                    b.Property<DateTime>("CreateDate")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("Description")
                        .HasColumnType("text");

                    b.Property<Guid>("ItemId")
                        .HasColumnType("uuid");

                    b.Property<double>("Quantity")
                        .HasColumnType("double precision");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uuid");

                    b.Property<bool>("Void")
                        .HasColumnType("boolean");

                    b.Property<DateTime?>("VoidDate")
                        .HasColumnType("timestamp without time zone");

                    b.HasKey("Id");

                    b.HasIndex("ConsultationId");

                    b.ToTable("ConsultationService");
                });

            modelBuilder.Entity("Moms.Clinical.Core.Domain.Consultation.Models.ConsultationTreatment", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<Guid>("ConsultationId")
                        .HasColumnType("uuid");

                    b.Property<DateTime>("CreateDate")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("Treatment")
                        .HasColumnType("text");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uuid");

                    b.Property<bool>("Void")
                        .HasColumnType("boolean");

                    b.Property<DateTime?>("VoidDate")
                        .HasColumnType("timestamp without time zone");

                    b.HasKey("Id");

                    b.HasIndex("ConsultationId");

                    b.ToTable("ConsultationTreatments");
                });

            modelBuilder.Entity("Moms.Clinical.Core.Domain.Consultation.Models.Vital", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<decimal?>("BPDiastolic")
                        .HasColumnType("numeric");

                    b.Property<decimal?>("BPSystolic")
                        .HasColumnType("numeric");

                    b.Property<DateTime>("CreateDate")
                        .HasColumnType("timestamp without time zone");

                    b.Property<decimal>("Height")
                        .HasColumnType("numeric");

                    b.Property<string>("Notes")
                        .HasColumnType("text");

                    b.Property<Guid>("PatientId")
                        .HasColumnType("uuid");

                    b.Property<decimal?>("Pulse")
                        .HasColumnType("numeric");

                    b.Property<decimal?>("RespiratoryRate")
                        .HasColumnType("numeric");

                    b.Property<decimal>("Temperature")
                        .HasColumnType("numeric");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uuid");

                    b.Property<DateTime>("VitalDateTime")
                        .HasColumnType("timestamp without time zone");

                    b.Property<bool>("Void")
                        .HasColumnType("boolean");

                    b.Property<DateTime?>("VoidDate")
                        .HasColumnType("timestamp without time zone");

                    b.Property<decimal>("Weight")
                        .HasColumnType("numeric");

                    b.HasKey("Id");

                    b.ToTable("Vitals");
                });

            modelBuilder.Entity("Moms.Clinical.Core.Domain.Queue.Models.Room", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<DateTime>("CreateDate")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.Property<int>("Status")
                        .HasColumnType("integer");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uuid");

                    b.Property<bool>("Void")
                        .HasColumnType("boolean");

                    b.Property<DateTime?>("VoidDate")
                        .HasColumnType("timestamp without time zone");

                    b.HasKey("Id");

                    b.ToTable("Room");
                });

            modelBuilder.Entity("Moms.Clinical.Core.Domain.Consultation.Models.ConsultationComplaint", b =>
                {
                    b.HasOne("Moms.Clinical.Core.Domain.Consultation.Models.Consultation", "Consultation")
                        .WithMany("ConsultationComplaints")
                        .HasForeignKey("ConsultationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Moms.Clinical.Core.Domain.Consultation.Models.ConsultationDiagnosis", b =>
                {
                    b.HasOne("Moms.Clinical.Core.Domain.Consultation.Models.Consultation", "Consultation")
                        .WithMany("ConsultationDiagnosis")
                        .HasForeignKey("ConsultationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Moms.Clinical.Core.Domain.Consultation.Models.ConsultationFinding", b =>
                {
                    b.HasOne("Moms.Clinical.Core.Domain.Consultation.Models.Consultation", "Consultation")
                        .WithMany("ConsultationFindings")
                        .HasForeignKey("ConsultationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Moms.Clinical.Core.Domain.Consultation.Models.ConsultationService", b =>
                {
                    b.HasOne("Moms.Clinical.Core.Domain.Consultation.Models.Consultation", "Consultation")
                        .WithMany("ConsultationServices")
                        .HasForeignKey("ConsultationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Moms.Clinical.Core.Domain.Consultation.Models.ConsultationTreatment", b =>
                {
                    b.HasOne("Moms.Clinical.Core.Domain.Consultation.Models.Consultation", "Consultation")
                        .WithMany("ConsultationTreatments")
                        .HasForeignKey("ConsultationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
