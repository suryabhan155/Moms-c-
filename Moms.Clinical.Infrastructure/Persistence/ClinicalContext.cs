using Microsoft.EntityFrameworkCore;
using Moms.Clinical.Core.Domain.Consultation.Models;
using Moms.SharedKernel.Infrastructure.Persistence;
using ConsultationService = Moms.Clinical.Core.Application.Consultation.Services.ConsultationService;

namespace Moms.Clinical.Infrastructure.Persistence
{
    public class ClinicalContext:BaseContext
    {
        /* Add the Dbset link to the models here */
        public DbSet<Consultation> Consultations { get; set; }
        public DbSet<ConsultationComplaint> ConsultationComplaints { get; set; }
        public DbSet<ConsultationDiagnosis> ConsultationDiagnoses { get; set; }
        public DbSet<ConsultationFinding> ConsultationFindings { get; set; }
        public DbSet<ConsultationTreatment> ConsultationTreatments { get; set; }
        public DbSet<Vital> Vitals { get; set; }

        public ClinicalContext(DbContextOptions<ClinicalContext> options) : base(options)
        {

        }

        public override void EnsureSeeded()
        {
            /* add seeding data here */

            SaveChanges();
        }
    }
}
