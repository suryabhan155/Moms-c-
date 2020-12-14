using Microsoft.EntityFrameworkCore;
using Moms.Clinical.Core.Domain.Queue;
using Moms.Clinical.Core.Domain.Queue.Models;
using Moms.Clinical.Core.Domain.Queue.Services;
using Moms.SharedKernel.Custom;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Moms.Clinical.Core.Application.Consultation.Services.Queue
{
    public class RoomService : IRoomService
    {
        public readonly IRoomRepository _RoomRepository;

        public RoomService(IRoomRepository roomRepository)
        {
            _RoomRepository = roomRepository;
        }

        public async Task<(bool IsSuccess, Room room, string ErrorMEssage)> AddRoom(Room room)
        {
            try
            {
                if (room == null)
                    return (false, room, "No room found");

                if (room.Id.IsNullOrEmpty())
                {
                    _RoomRepository.Create(room);
                }
                else
                {
                    _RoomRepository.Update(room);
                }
                await _RoomRepository.Save();

                return (true, room, "Room created successfully");
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public async Task<(bool IsSuccess, Guid id, string ErrorMessage)> DeleteRoom(Guid id)
        {
            try
            {

                var room = await _RoomRepository.GetAll(x => x.Id == id).FirstOrDefaultAsync();
                if (room == null)
                    return (false, id, "No record found.");
                _RoomRepository.Delete(room);

                return (false, id, "Record deleted successfully.");
            }
            catch (Exception e)
            {
                return (false, id, $"{e.Message}");
            }
        }

        public (bool IsSuccess, Room room, string ErrorMessage) GetRoom(Guid id)
        {
            try
            {
                var room = _RoomRepository.GetById(id);
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

        public async Task<(bool IsSuccess, IEnumerable<Room> rooms, string ErrorMessage)> LoadRooms()
        {
            try
            {
                var rooms = await _RoomRepository.GetAll().ToListAsync();
                if (rooms == null)
                    return (false, new List<Room>(), "No record found.");
                return (true, rooms, "Rooms loaded successfully.");
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
    }
}
