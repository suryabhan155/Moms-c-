using System;
using System.Collections.Generic;
using System.Text;
using Moms.Laboratory.Core.Domain.Lab;
using Moms.Laboratory.Core.Domain.Lab.Models;
using Moms.SharedKernel.Infrastructure.Persistence;

namespace Moms.Laboratory.Infrastructure.Persistence
{
    public class LabOrderRepository : BaseRepository<LabOrder, Guid>, ILabOrderRepository
    {
        public LabOrderRepository(LaboratoryContext context) : base(context)
        {

        }

    }
}
