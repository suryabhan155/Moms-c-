using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Moms.SupplyChain.Core.Domain.SupplyChain.Models;
using Moms.SupplyChain.Core.Domain.SupplyChain.Services;
using Serilog;

namespace Moms.SupplyChain.Management.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StoreController : ControllerBase
    {

        public readonly IMediator _IMediator;
        public readonly IStoreService _Service;

        public StoreController(IMediator iMediator, IStoreService service)
        {
            _IMediator = iMediator;
            _Service = service;
        }

        [HttpGet("lab/stores")]
        public async Task<IActionResult> Get()
        {
            try
            {
                var results = await _Service.LoadStores();
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

        [HttpGet("{id}")]
        public IActionResult Get(Guid id)
        {
            try
            {
                var results = _Service.GetStore(id);
                if (results.IsSuccess)
                    return Ok(results.stores);
                return NotFound(results);
            }
            catch (Exception e)
            {
                var msg = $"Error loading ";
                Log.Error(e, msg);
                return StatusCode(500, $"{msg} {e.Message}");
            }
        }

        [HttpPost]
        public async Task<IActionResult> AddStore([FromBody] Store store)
        {
            try
            {
                var results = await _Service.AddStore(store);
                if (results.IsSuccess)
                    return Ok(results.store);
                return NotFound(results.ErrorMessage);
            }
            catch (Exception e)
            {
                var msg = $"Error saving ";
                Log.Error(e, msg);
                return StatusCode(500, $"{msg} {e.Message}");
            }
        }

        // DELETE api/<VitalsController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            try
            {
                var results = await _Service.DeleteStore(id);
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
