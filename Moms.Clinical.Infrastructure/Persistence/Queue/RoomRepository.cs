using Moms.Clinical.Core.Domain.Queue;
using Moms.Clinical.Core.Domain.Queue.Models;
using Moms.SharedKernel.Infrastructure.Persistence;
using System;
using System.Collections.Generic;
using System.Text;

namespace Moms.Clinical.Infrastructure.Persistence.Queue
{
    public class RoomRepository: BaseRepository<Room, Guid>, IRoomRepository
    {
        public RoomRepository(ClinicalContext context): base(context)
        {

        }
    }
}
