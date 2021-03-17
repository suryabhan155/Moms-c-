using Microsoft.EntityFrameworkCore;
using Moms.Clinical.Core.Application.Consultation.Response;
using Moms.Clinical.Core.Domain.Queue;
using Moms.Clinical.Core.Domain.Queue.Models;
using Moms.Clinical.Core.Domain.Queue.Services;
using Moms.SharedKernel.Custom;
using System;
using System.Collections.Generic;
using System.Net;
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

        public async Task<(bool IsSuccess, Room room, ResponseModel model)> AddRoom(Room room)
        {
            try
            {
                if (room == null)
                    return (false, room, new ResponseModel { message = "No room found", data = room, code = HttpStatusCode.NotFound });

                if (room.Id.IsNullOrEmpty())
                {
                    _RoomRepository.Create(room);
                }
                else
                {
                    _RoomRepository.Update(room);
                }
                await _RoomRepository.Save();

                return (true, room, new ResponseModel { message = "Room created successfully", data = room, code = HttpStatusCode.OK });
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public async Task<(bool IsSuccess, Guid id, ResponseModel model)> UpdateRoom(Guid id)
        {
            try
            {
                var room = await _RoomRepository.GetAll(x => x.Id == id).FirstOrDefaultAsync();
                room.Void = true;
                if (room == null)
                    return (false, id, new ResponseModel { message = "No record found.", data = id, code = HttpStatusCode.NotFound });

                _RoomRepository.Update(room);
                await _RoomRepository.Save();

                return (true, id, new ResponseModel { message = "Record deleted successfully.", data = id, code = HttpStatusCode.OK });
            }
            catch (Exception e)
            {
                return (false, id, new ResponseModel { message = e.Message, data = id, code = HttpStatusCode.InternalServerError });
            }
        }

        public async Task<(bool IsSuccess, Guid id, ResponseModel model)> DeleteRoom(Guid id)
        {
            try
            {
                var room = await _RoomRepository.GetAll(x => x.Id == id && !x.Void).FirstOrDefaultAsync();
                room.Void = true;
                if (room == null)
                    return (false, id, new ResponseModel { message = "No record found.", data = id, code = HttpStatusCode.NotFound });
                
                _RoomRepository.Update(room);
                await _RoomRepository.Save();

                return (true, id, new ResponseModel { message = "Record deleted successfully.", data = id, code = HttpStatusCode.OK });
            }
            catch (Exception e)
            {
                return (false, id, new ResponseModel { message =e.Message , data = id, code = HttpStatusCode.InternalServerError });
            }
        }

        public (bool IsSuccess, Room room, ResponseModel model) GetRoom(Guid id)
        {
            try
            {
                var room = _RoomRepository.GetById(id);
                if (room == null)
                    return (false, null, new ResponseModel { message =  "Room not found.", data = null, code = HttpStatusCode.NotFound });
                return (true, room, new ResponseModel { message = "Room loaded successfully", data = room, code = HttpStatusCode.OK });
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return (false, null, new ResponseModel { message = e.Message, data = null, code = HttpStatusCode.InternalServerError });
            }
        }

        public async Task<(bool IsSuccess, IEnumerable<Room> rooms, ResponseModel model)> LoadRooms()
        {
            try
            {
                //var rooms = await _RoomRepository.GetAll().ToListAsync();
                var rooms = await _RoomRepository.GetAll(x=>x.Void == false).ToListAsync();
                if (rooms == null)
                    return (false, new List<Room>(), new ResponseModel { message = "No record found.", data = new List<Room>(), code = HttpStatusCode.NotFound });
                return (true, rooms, new ResponseModel { message ="Rooms loaded successfully." , data = rooms, code = HttpStatusCode.OK });
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
    }
}
