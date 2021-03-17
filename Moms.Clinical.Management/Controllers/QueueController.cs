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
    [Route("api/[controller]")]
    [ApiController]
    public class QueueController : ControllerBase
    {
        private readonly IQueueService _QueueService;

        public QueueController(IQueueService queueService)
        {
            _QueueService = queueService;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var results = await _QueueService.LoadQueues();

                if (results.IsSuccess)
                    return Ok(results.model);
                return NotFound(results.model);
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
                var results = _QueueService.GetQueue(id);
                if (results.IsSuccess)
                    return Ok(results.model);
                return NotFound(results.model);
            }
            catch (Exception e)
            {
                var msg = $"Error loading ";
                Log.Error(e, msg);
                return StatusCode(500, $"{msg} {e.Message}");
            }
        }
        [HttpPost]
        public async Task<IActionResult> AddQueue([FromBody] Queue queue)
        {
            try
            {
                var results = await _QueueService.AddQueue(queue);
                if (results.IsSuccess)
                    return Ok(results.model);
                return NotFound(results.model);
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
                var results = await _QueueService.DeleteQueue(id);
                if (results.IsSuccess)
                    return Ok(results.model);
                return NotFound(results.model);
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
