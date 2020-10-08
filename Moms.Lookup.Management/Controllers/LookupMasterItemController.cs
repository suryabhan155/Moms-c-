using System;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Moms.Lookup.Core.Domain;
using Moms.Lookup.Core.Domain.Options.Models;
using Moms.Lookup.Core.Domain.Options.Service;
using Serilog;

namespace Moms.Lookup.Management.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LookupMasterItemController:ControllerBase
    {
        private readonly ILookupMasterItemService _lookupOptionsService;
        public LookupMasterItemController(ILookupMasterItemService lookupOptionsService )
        {
            _lookupOptionsService = lookupOptionsService;
        }

        [HttpGet("optionsByName/{name}")]
       /* public async Task<IActionResult> GetLookupOptionsByName(string name)
        {
            try
            {
                var results = await _lookupOptionsService.GetLookupOptionsByName(name);
                if (results.IsSuccess)
                    return Ok(results.lookupOptionsDtos);
                return BadRequest($"{results.ErrorMessage}");
            }
            catch (Exception e)
            {
                var msg = $"Error loading ";
                Log.Error(e, msg);
                return StatusCode(500, $"{msg} {e.Message}");
            }
        }*/

        [HttpGet("optionsById/{id}")]
       /* public async Task<IActionResult> GetLookupOptionsById(Guid id)
        {
            try
            {
                var result = await _lookupOptionsService.GetLookupOptionsById(id);
                if (result.IsSuccess)
                    return Ok(result);
                return BadRequest(result.ErrorMessage);
            }
            catch (Exception e)
            {
                var msg = $"Error loading ";
                Log.Error(e, msg);
                return StatusCode(500, $"{msg} {e.Message}");
            }
        }*/

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var result = await _lookupOptionsService.LoadAll();
                if (result.IsSuccess)
                    return Ok(result.lookupMasterItems);
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
               var result= await _lookupOptionsService.DeleteLookupOption(id);
               if(result.IsSuccess)
                return Ok("LookupOption deleted successfully");
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
        public async Task<IActionResult> Post([FromBody] LookupMasterItem lookupOption)
        {
            try
            {
               var result= await _lookupOptionsService.AddLookupMasterItem(lookupOption);
                if(result.IsSuccess)
                    return Ok("Lookup Option added successuly");
                return BadRequest(result.ErrorMEssage);
            }
            catch (Exception e)
            {
                var msg = $"Error loading ";
                Log.Error(e, msg);
                return StatusCode(500, $"{msg} {e.Message}");
            }
        }

        [HttpGet("GetCounty/{name}")]
        public async Task<IActionResult> GetCounty(string name)
        {
            try
            {
                var result = await _lookupOptionsService.GetCounty(name);
                if (result.IsSuccess)
                    return Ok(result.CountyLookup);
                return BadRequest(result.ErrorMessage);
            }
            catch (Exception e)
            {
                var msg = $"Error loading ";
                Log.Error(e, msg);
                return StatusCode(500, $"{msg} {e.Message}");
            }
        }

        [HttpGet("GetSubCounty/{name}")]
        public async Task<IActionResult> GetSubCounty(string name)
        {
            try
            {
                var result = await _lookupOptionsService.GetSubCounty(name);
                if (result.IsSuccess)
                    return Ok(result.CountyLookup);
                return BadRequest(result.ErrorMessage);
            }
            catch (Exception e)
            {
                var msg = $"Error loading ";
                Log.Error(e, msg);
                return StatusCode(500, $"{msg} {e.Message}");
            }
        }

        [HttpGet("GetWard/{name}")]
        public async Task<IActionResult> GetWard(string name)
        {
            try
            {
                var result = await _lookupOptionsService.GetWards(name);
                if (result.IsSuccess)
                    return Ok(result.CountyLookup);
                return BadRequest(result.ErrorMessage);
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
