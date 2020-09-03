using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Moms.Laboratory.Core.Domain.Lab;
using Moms.Laboratory.Core.Domain.Lab.Services;
using Serilog;

namespace Moms.Laboratory.Management.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LabSubItemController : ControllerBase
    {
        public readonly IMediator _IMediator;
        public readonly ILabSubItemService _LabSubItemService;

        public LabSubItemController(IMediator iMediator, ILabSubItemService labSubItemService)
        {
            _IMediator = iMediator;
            _LabSubItemService = labSubItemService;
        }

        [HttpGet("lab/sub/items")]
        public async Task<IActionResult> Get()
        {
            try
            {
                var results = await _LabSubItemService.LoadLabSubItems();
                if (results.IsSuccess)
                    return Ok(results);
                return NotFound();

            }
            catch (Exception e)
            {
                var msg = $"Error loading ";
                Log.Error(e, msg);
                return StatusCode(500, $"{msg} {e.Message}");
            }

        }

        [HttpGet("lab/sub/item")]
        public async Task<IActionResult> GetLabSubItem(Guid id)
        {
            try
            {
                var results = await _LabSubItemService.GetLabSubItem(id);
                if (results.IsSuccess)
                    return Ok(results);
                return NotFound();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
    }
}
