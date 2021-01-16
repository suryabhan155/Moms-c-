using Microsoft.EntityFrameworkCore;
using Moms.Clinical.Core.Domain.Queue;
using Moms.Clinical.Core.Domain.Queue.Services;
using Moms.SharedKernel.Custom;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Moms.Clinical.Core.Application.Consultation.Services.Queue
{
    public class QueueService: IQueueService
    {
        public readonly IQueueRepository _QueueRepository;

        public QueueService(IQueueRepository queueRepository)
        {
            _QueueRepository = queueRepository;
        }


        public async Task<(bool IsSuccess, Domain.Queue.Models.Queue queue, string ErrorMEssage)> AddQueue(Domain.Queue.Models.Queue queue)
        {
            try
            {
                if (queue == null)
                    return (false, queue, "No queue found");

                if (queue.Id.IsNullOrEmpty())
                {
                    _QueueRepository.Create(queue);
                }
                else
                {
                    _QueueRepository.Update(queue);
                }
                await _QueueRepository.Save();

                return (true, queue, "Queue created successfully");
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public async Task<(bool IsSuccess, Guid id, string ErrorMessage)> DeleteQueue(Guid id)
        {
            try
            {

                var queue = await _QueueRepository.GetAll(x => x.Id == id).FirstOrDefaultAsync();
                if (queue == null)
                    return (false, id, "No record found.");
                _QueueRepository.Delete(queue);

                return (false, id, "Record deleted successfully.");
            }
            catch (Exception e)
            {
                return (false, id, $"{e.Message}");
            }
        }

        public (bool IsSuccess, Domain.Queue.Models.Queue queue, string ErrorMessage) GetQueue(Guid id)
        {
            try
            {
                var room = _QueueRepository.GetById(id);
                if (room == null)
                    return (false, null, "Room not found.");
                return (true, room, "Room loaded successfully");
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return (false, null, $"{e.Message}");
            }
        }

        public async Task<(bool IsSuccess, IEnumerable<Domain.Queue.Models.Queue> queues, string ErrorMessage)> LoadQueues()
        {
            try
            {
                var queues = await _QueueRepository.GetAll().ToListAsync();
                if (queues == null)
                    return (false, new List<Domain.Queue.Models.Queue>(), "No record found.");
                return (true, queues, "Queues loaded successfully.");
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

    }
}
