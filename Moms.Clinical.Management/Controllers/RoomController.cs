using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Moms.Clinical.Core.Domain.Queue.Models;
using Moms.Clinical.Core.Domain.Queue.Services;
using Serilog;

namespace Moms.Clinical.Management.Controllers
{
    public class RoomController : ControllerBase
    {
        private readonly IRoomService _RoomService;

        public RoomController(IRoomService roomService)
        {
            _RoomService = roomService;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var results = await _RoomService.LoadRooms();

                if (results.IsSuccess)
                    return Ok(results.rooms);
                return NotFound(results);
            }
            catch (Exception e)
            {
                var msg = $"Error loading ";
                Log.Error(e, msg);
                return StatusCode(500, $"{msg} {e.Message}");
            }
        }

        [HttpGet("{id}")]
        public IActionResult Get(Guid id)
        {
            try
            {
                var results = _RoomService.GetRoom(id);
                if (results.IsSuccess)
                    return Ok(results.room);
                return NotFound(results);
            }
            catch (Exception e)
            {
                var msg = $"Error loading ";
                Serilog.Log.Error(e, msg);
                return StatusCode(500, $"{msg} {e.Message}");
            }
        }
        [HttpPost]
        public async Task<IActionResult> AddQueue([FromBody] Room room)
        {
            try
            {
                var results = await _RoomService.AddRoom(room);
                if (results.IsSuccess)
                    return Ok(results.room);
                return NotFound(results.ErrorMEssage);
            }
            catch (Exception e)
            {
                var msg = $"Error saving ";
                Log.Error(e, msg);
                return StatusCode(500, $"{msg} {e.Message}");
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            try
            {
                var results = await _RoomService.DeleteRoom(id);
                if (results.IsSuccess)
                    return Ok(results);
                return NotFound(results);
            }
            catch (Exception e)
            {
                var msg = $"Error deleting ";
                Log.Error(e, msg);
                return StatusCode(500, $"{msg} {e.Message}");
            }
        }
    }
}
