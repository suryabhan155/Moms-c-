using Moms.SharedKernel.Interfaces.Persistence;
using System;
using System.Collections.Generic;
using System.Text;

namespace Moms.Clinical.Core.Domain.Queue
{
    public interface IRoomRepository: IRepository<Models.Room, Guid>
    {
    }
}
