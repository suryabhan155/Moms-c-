using System;
using Microsoft.AspNetCore.Mvc;
using Moms.Revenue.Core.Domain.Billing;
using Moms.Revenue.Core.Domain.Billing.Services;
using Serilog;

namespace Moms.Revenue.Management.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PaymentTypeController : ControllerBase
    {
        private readonly IClientBillingService _billingService;

        public PaymentTypeController(IClientBillingService billingService)
        {
            _billingService = billingService;
        }

      /*  [HttpGet]
        public ActionResult Get()
        {
            try
            {
                var results = _billingService.LoadPaymentTypes();
                return Ok(results);
            }
            catch (Exception e)
            {
                var msg = $"Error loading ";
                Log.Error(e, msg);
                return StatusCode(500, $"{msg} {e.Message}");
            }
        }*/
    }
}
