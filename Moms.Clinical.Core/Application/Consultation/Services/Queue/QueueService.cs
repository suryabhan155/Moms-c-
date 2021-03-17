using Microsoft.EntityFrameworkCore;
using Moms.Clinical.Core.Application.Consultation.Response;
using Moms.Clinical.Core.Domain.Queue;
using Moms.Clinical.Core.Domain.Queue.Services;
using Moms.SharedKernel.Custom;
using System;
using System.Collections.Generic;
using System.Net;
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


        public async Task<(bool IsSuccess, Domain.Queue.Models.Queue queue, ResponseModel model)> AddQueue(Domain.Queue.Models.Queue queue)
        {
            try
            {
                if (queue == null)
                    return (false, queue, new ResponseModel { message = "No queue found", data = queue, code = HttpStatusCode.NotFound });

                if (queue.Id.IsNullOrEmpty())
                {
                    _QueueRepository.Create(queue);
                }
                else
                {
                    _QueueRepository.Update(queue);
                }
                await _QueueRepository.Save();

                return (true, queue, new ResponseModel { message = "Queue created successfully", data = queue, code = HttpStatusCode.OK });
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public async Task<(bool IsSuccess, Guid id, ResponseModel model)> DeleteQueue(Guid id)
        {
            try
            {

                var queue = await _QueueRepository.GetAll(x => x.Id == id).FirstOrDefaultAsync();
                if (queue == null)
                    return (false, id, new ResponseModel { message =  "No record found.", data = id, code = HttpStatusCode.NotFound });
                _QueueRepository.Delete(queue);

                return (false, id, new ResponseModel { message = "Record deleted successfully.", data = id, code = HttpStatusCode.OK });
            }
            catch (Exception e)
            {
                return (false, id, new ResponseModel { message =e.Message , data = id, code = HttpStatusCode.InternalServerError });
            }
        }

        public (bool IsSuccess, Domain.Queue.Models.Queue queue, ResponseModel model) GetQueue(Guid id)
        {
            try
            {
                var room = _QueueRepository.GetById(id);
                if (room == null)
                    return (false, null, new ResponseModel { message = "Room not found.", data = null, code = HttpStatusCode.NotFound } );
                return (true, room, new ResponseModel { message = "Room loaded successfully", data = room, code = HttpStatusCode.OK });
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return (false, null, new ResponseModel { message = e.Message, data = null, code = HttpStatusCode.InternalServerError });
            }
        }

        public async Task<(bool IsSuccess, IEnumerable<Domain.Queue.Models.Queue> queues, ResponseModel model)> LoadQueues()
        {
            try
            {
                var queues = await _QueueRepository.GetAll().ToListAsync();
                if (queues == null)
                    return (false, new List<Domain.Queue.Models.Queue>(), new ResponseModel { message ="No record found." , data = new List<Domain.Queue.Models.Queue>() , code = HttpStatusCode.NotFound });
                return (true, queues, new ResponseModel { message = "Queues loaded successfully.", data = queues, code = HttpStatusCode.OK });
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

    }
}
