using Moms.Clinical.Core.Application.Consultation.Response;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Moms.Clinical.Core.Domain.Queue.Services
{
    public interface IRoomService
    {
        Task<(bool IsSuccess, IEnumerable<Models.Room> rooms, ResponseModel model)> LoadRooms();
        (bool IsSuccess, Models.Room room, ResponseModel model) GetRoom(Guid id);
        Task<(bool IsSuccess, Guid id, ResponseModel model)> DeleteRoom(Guid id);
        Task<(bool IsSuccess, Guid id, ResponseModel model)> UpdateRoom(Guid id);
        Task<(bool IsSuccess, Models.Room room, ResponseModel model)> AddRoom(Models.Room room);
    }
}
