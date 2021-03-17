using Moms.Clinical.Core.Domain.Queue;
using Moms.SharedKernel.Infrastructure.Persistence;
using System;
using System.Collections.Generic;
using System.Text;

namespace Moms.Clinical.Infrastructure.Persistence.Queue
{
    public class QueueRepository: BaseRepository<Core.Domain.Queue.Models.Queue, Guid>, IQueueRepository
    {
        public QueueRepository(ClinicalContext context): base(context)
        {

        }
    }
}
