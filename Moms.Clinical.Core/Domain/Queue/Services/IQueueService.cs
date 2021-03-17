using Moms.Clinical.Core.Application.Consultation.Response;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Moms.Clinical.Core.Domain.Queue.Services
{
    public interface IQueueService
    {
        Task<(bool IsSuccess, IEnumerable<Models.Queue> queues, ResponseModel model)> LoadQueues();
        (bool IsSuccess, Models.Queue queue, ResponseModel model) GetQueue(Guid id);
        Task<(bool IsSuccess, Guid id, ResponseModel model)> DeleteQueue(Guid id);
        Task<(bool IsSuccess, Models.Queue queue, ResponseModel model)> AddQueue(Models.Queue vitals);
    }
}
