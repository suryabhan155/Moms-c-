using Microsoft.EntityFrameworkCore;
using Moms.SharedKernel.Infrastructure.Persistence;

namespace Moms.Clinical.Infrastructure.Persistence
{
    public class ClinicalContext:BaseContext
    {
        /* Add the Dbset link to the models here */

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
