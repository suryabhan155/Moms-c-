using Microsoft.EntityFrameworkCore;

namespace Moms.SharedKernel.Infrastructure.Persistence
{
    public abstract class BaseContext : DbContext
    {
        protected BaseContext(DbContextOptions options) : base(options)
        {
        }

        public virtual void EnsureSeeded()
        {
        }
    }
}
