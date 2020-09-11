using System;
using System.Collections.Generic;
using System.Text;
using Moms.Laboratory.Core.Domain.Lab.Models;
using Moms.SharedKernel.Interfaces.Persistence;

namespace Moms.Laboratory.Core.Domain.Lab
{
    public interface ILabOrderSampleStatusRepository : IRepository<LabOrderSampleStatus, Guid>
    {

    }
}
