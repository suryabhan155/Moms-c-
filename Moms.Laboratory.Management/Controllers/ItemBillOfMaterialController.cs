using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Moms.Laboratory.Core.Domain.Lab.Services;
using Serilog;

namespace Moms.Laboratory.Management.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ItemBillOfMaterialController : ControllerBase
    {
        public readonly IMediator _iMediator;
        public readonly IItemBillOfMaterialService _ItemBillOfMaterialService;

        public ItemBillOfMaterialController(IMediator iMediator, IItemBillOfMaterialService itemBillOfMaterialService)
        {
            _iMediator = iMediator;
            _ItemBillOfMaterialService = itemBillOfMaterialService;
        }



        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var results = await _ItemBillOfMaterialService.LoadItemBillOfMaterials();
                if (results.IsSuccess)
                    return Ok(results);
                return NotFound(results);
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
