using Microsoft.EntityFrameworkCore;
using Moms.SharedKernel.Infrastructure.Persistence;

namespace Moms.Laboratory.Infrastructure.Persistence
{
    public class LaboratoryContext: BaseContext
    {
        public LaboratoryContext(DbContextOptions<LaboratoryContext> options):base(options)
        {

        }
    }
}
