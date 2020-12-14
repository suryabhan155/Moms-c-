using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Moms.Clinical.Core.Domain.Queue.Services
{
    public interface IRoomService
    {
        Task<(bool IsSuccess, IEnumerable<Models.Room> rooms, string ErrorMessage)> LoadRooms();
        (bool IsSuccess, Models.Room room, string ErrorMessage) GetRoom(Guid id);
        Task<(bool IsSuccess, Guid id, string ErrorMessage)> DeleteRoom(Guid id);
        Task<(bool IsSuccess, Models.Room room, string ErrorMEssage)> AddRoom(Models.Room room);
    }
}
