using System.Linq;
using Microsoft.EntityFrameworkCore;
using Moms.RegistrationManagement.Core.Domain.Facilities.Models;
using Moms.RegistrationManagement.Core.Domain.Patient.Models;
using Moms.SharedKernel.Infrastructure.Persistence;
using Moms.SharedKernel.Utility;

namespace Moms.RegistrationManagement.Infrastructure.Persistence
{
    public class RegistrationContext : BaseContext
    {
        public DbSet<Clinic> Clinics { get; set; }
        public DbSet<Contact> Contacts { get; set; }
        public DbSet<Death> Deaths { get; set; }
        public DbSet<Employer> Employers { get; set; }
        public DbSet<Guardian> Guardians { get; set; }
        public DbSet<Patient> Patients { get; set; }

        public RegistrationContext(DbContextOptions<RegistrationContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }

        public override void EnsureSeeded()
        {
            // For complex data use Pipes e.g SeedDataReader.ReadCsv<Clinic>(typeof(RegistrationContext).Assembly, "Seed", "|");

            if (!Clinics.Any())
            {
                var data = SeedDataReader.ReadCsv<Clinic>(typeof(RegistrationContext).Assembly);
                AddRange(data);
            }

            SaveChanges();
        }
    }
}
