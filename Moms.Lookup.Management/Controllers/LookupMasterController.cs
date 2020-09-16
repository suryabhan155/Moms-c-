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
    public class LookupMasterController:ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly ILookupMasterService _lookupMasterService;

        public LookupMasterController(IMediator mediator, ILookupMasterService lookupMasterService)
        {
            _mediator = mediator;
            _lookupMasterService = lookupMasterService;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var result = await _lookupMasterService.LoadAll();
                if (result.IsSuccess)
                    return Ok(result.lookupMasters);
                return BadRequest(result.ErrorMessage);
            }
            catch (Exception e)
            {
                var msg = $"Error loading ";
                Log.Error(e, msg);
                return StatusCode(500, $"{msg} {e.Message}");
            }
        }

        [HttpGet("masterById/{id}")]
        public async Task<IActionResult> GetLookupMaster(Guid id)
        {
            try
            {
                var result = await _lookupMasterService.GetLookupMaster(id);
                if (result.IsSuccess)
                    return Ok(result.lookupMaster);
                return BadRequest(result.ErrorMessage);
            }
            catch (Exception e)
            {
                var msg = $"Error loading ";
                Log.Error(e, msg);
                return StatusCode(500, $"{msg} {e.Message}");
            }
        }

        [HttpGet("MasterById/{name}")]
        public async Task<IActionResult> GetLookupMasterByName(string name)
        {
            try
            {
                var result = await _lookupMasterService.GetLookupMasterByName(name);
                if (result.IsSuccess)
                    return Ok(result.lookupMaster);
                return BadRequest(result.ErrorMessage);
            }
            catch (Exception e)
            {
                var msg = $"Error loading ";
                Log.Error(e, msg);
                return StatusCode(500, $"{msg} {e.Message}");
            }
        }

        [HttpGet("delete/{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            try
            {
                var result = await _lookupMasterService.DeleteLookupMaster(id);
                if (result.IsSuccess)
                    return Ok(result.ErrorMessage);
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
        public async Task<IActionResult> Post([FromBody] LookupMaster lookupMaster)
        {
            try
            {
                var result = await _lookupMasterService.AddLookupMaster(lookupMaster);
                if (result.IsSuccess)
                    return Ok(result.ErrorMEssage);
                return BadRequest(result.ErrorMEssage);
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
