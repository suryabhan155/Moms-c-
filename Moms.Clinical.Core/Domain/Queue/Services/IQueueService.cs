using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Moms.Clinical.Core.Domain.Queue.Services
{
    public interface IQueueService
    {
        Task<(bool IsSuccess, IEnumerable<Models.Queue> queues, string ErrorMessage)> LoadQueues();
        (bool IsSuccess, Models.Queue queue, string ErrorMessage) GetQueue(Guid id);
        Task<(bool IsSuccess, Guid id, string ErrorMessage)> DeleteQueue(Guid id);
        Task<(bool IsSuccess, Models.Queue queue, string ErrorMEssage)> AddQueue(Models.Queue vitals);
    }
}
