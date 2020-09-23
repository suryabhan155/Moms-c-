using System;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Moms.Lookup.Core.Domain.Options.Models;
using Moms.Lookup.Core.Domain.Options.Service;
using Serilog;

namespace Moms.Lookup.Management.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LookupItemController:ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly ILookupItemService _lookupItemService;
        public LookupItemController(IMediator mediator, ILookupItemService lookupItemService)
        {
            _mediator = mediator;
            _lookupItemService = lookupItemService;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var result = await _lookupItemService.LoadAll();
                if (result.IsSuccess)
                    return Ok(result.lookupItem);
                return BadRequest(result.ErrorMessage);
            }
            catch (Exception e)
            {
                var msg = $"Error loading ";
                Log.Error(e, msg);
                return StatusCode(500, $"{msg} {e.Message}");
            }
        }

        [HttpGet("item/{id}")]
        public async Task<IActionResult> GetLookupItem(Guid id)
        {
            try
            {
                var result = await _lookupItemService.GetLookupItem(id);
                if (result.IsSuccess)
                    return Ok(result.lookupItem);
                return BadRequest(result.ErrorMessage);
            }
            catch (Exception e)
            {
                var msg = $"Error loading ";
                Log.Error(e, msg);
                return StatusCode(500, $"{msg} {e.Message}");
            }
        }

        [HttpGet("Delete/{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            try
            {
                var result = await _lookupItemService.DeleteLookupItem(id);
                if (result.IsSuccess)
                    return Ok(result.id);
                return BadRequest(result.ErrorMessage);
            }
            catch (Exception e)
            {
                var msg = $"Error loading ";
                Log.Error(e, msg);
                return StatusCode(500, $"{msg} {e.Message}");
            }
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] LookupItem lookupItem)
        {
            try
            {
                var result = await _lookupItemService.AddLookupItem(lookupItem);
                if (result.IsSuccess)
                    return Ok(result.ErrorMEssage);
                return BadRequest(result.lookupItem);
            }
            catch (Exception e)
            {
                var msg = $"Error loading ";
                Log.Error(e, msg);
                return StatusCode(500, $"{msg} {e.Message}");
            }
        }
    }
}
