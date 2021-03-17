using System;
using Moms.Laboratory.Core.Domain.Lab;
using Moms.Laboratory.Core.Domain.Lab.Models;
using Moms.SharedKernel.Infrastructure.Persistence;

namespace Moms.Laboratory.Infrastructure.Persistence
{
    public class LabSubItemRepository : BaseRepository<LabSubItem, Guid>, ILabSubItemRepository
    {
        public LabSubItemRepository(LaboratoryContext context) : base(context)
        {

        }
    }
}
