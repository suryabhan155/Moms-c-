using System;

namespace Moms.Revenue.Core.Domain.Billing.Dto
{
    public class ClientBillDto
    {
        public Guid Id { get; set; }
        public Guid PatientId { get; set; }
        public DateTime BillingDate { get; set; }
        public string BillNumber { get; set; }
        public Decimal BillTotal { get; set; }
    }
}
