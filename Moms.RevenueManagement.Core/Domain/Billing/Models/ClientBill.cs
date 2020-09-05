using System;
using Moms.SharedKernel.Custom;
using Moms.SharedKernel.Model;

namespace Moms.RevenueManagement.Core.Domain.Billing.Models
{

    public class ClientBill:Entity<Guid>
    {
        public Guid PatientId { get; set; }
        public DateTime BillingDate { get; set; }
        public string BillNumber { get; set; }
        public Decimal BillTotal { get; set; }

        public ClientBill(Guid patientId, DateTime  billingDate, string billNumber,Decimal billTotal)
        {
            if(patientId.IsNullOrEmpty()) throw new ArgumentNullException(nameof(patientId));
            if(billingDate.IsNullOrEmpty()) throw new ArgumentException(nameof(billingDate));
            if(string.IsNullOrEmpty(billNumber)) throw new ArgumentNullException(nameof(billNumber));
            if(billTotal<1) throw new ArgumentOutOfRangeException(nameof(billTotal));

            PatientId = patientId;
            BillingDate = billingDate;
            BillNumber = billNumber;
            BillTotal = billTotal;
        }
    }
}
