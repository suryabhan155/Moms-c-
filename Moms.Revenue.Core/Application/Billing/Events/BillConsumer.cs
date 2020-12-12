using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using MassTransit;
using Moms.SharedKernel.Model;

namespace Moms.Revenue.Core.Application.Billing.Events
{
    public class BillConsumer : IConsumer<BillDto>
    {
        public async Task Consume(ConsumeContext<BillDto> context)
        {
            var data = context.Message;
            //Validate the Ticket Data
            //Store to Database
            //Notify the user via Email / SMS
        }
    }
}
