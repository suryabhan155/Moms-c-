using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Moms.RegistrationManagement.Core.Application.Facilities.Commands;
using Moms.RegistrationManagement.Core.Application.Facilities.Queries;
using Moms.RegistrationManagement.Core.Domain.Facilities;
using Serilog;

namespace Moms.RegistrationManagement.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ClinicController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IClinicService _clinicService;

        public ClinicController(IMediator mediator, IClinicService clinicService)
        {
            _mediator = mediator;
            _clinicService = clinicService;
        }

        [HttpGet]
        public ActionResult Get()
        {
            try
            {
                var results = _clinicService.Load();

                    return Ok(results);
            }
            catch (Exception e)
            {
                var msg = $"Error loading ";
                Log.Error(e, msg);
                return StatusCode(500, $"{msg} {e.Message}");
            }
        }
        [HttpGet("Name")]
        public async Task<ActionResult> GetByName(string name)
        {
            try
            {
                var results = await _mediator.Send(new SampleQuery(name));
                if (results.IsSuccess)
                    return Ok(results.Value);

                if (results.IsFailure)
                    throw new Exception(results.Error);

                return NotFound();
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
