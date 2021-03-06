using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.ApplicationModels;
using Moms.Revenue.Core.Domain.Item.Models;
using Moms.SharedKernel.Custom;
using Moms.SharedKernel.Model;

namespace Moms.Revenue.Core.Domain.Billing.Models
{
    public class ClientBillPayment:Entity<Guid>
    {
        public Guid ClientBillingId { get; set; }
        public Guid ItemMasterId { get; set; }
        public ItemMaster ItemMaster { get; set; }
        public Guid PaymentTypeId { get; set; }
        public PaymentType PaymentType { get; set; }
        public Guid ModuleId { get; set; }
        public Module Module { get; set; }
        public Decimal DiscountedAmount { get; set; }
        public Decimal Amount { get; set; }
        public Boolean Status { get; set; }

        public IEnumerable<PaymentType> PaymentTypes = new List<PaymentType>();
        public IEnumerable<Module> Modules=new List<Module>();

        public ClientBillPayment()
        {

        }
        public ClientBillPayment(Guid clientBillingId, Guid itemMasterId,Guid paymentTypeId, Guid moduleId, Decimal amount)
        {
            if(clientBillingId.IsNullOrEmpty()) throw new ArgumentNullException(nameof(clientBillingId));
            if(itemMasterId.IsNullOrEmpty()) throw new ArgumentNullException(nameof(itemMasterId));
            if(paymentTypeId.IsNullOrEmpty()) throw new ArgumentException(nameof(paymentTypeId));
            if(moduleId.IsNullOrEmpty())throw new ArgumentNullException(nameof(moduleId));
            if(Amount<1) throw new  ArgumentOutOfRangeException(nameof(amount));

            ClientBillingId = clientBillingId;
            ItemMasterId = itemMasterId;
            PaymentTypeId = paymentTypeId;
            ModuleId = moduleId;
            Amount = amount;

        }

        public Decimal GetSaleAmount()
        {
            return (Amount - DiscountedAmount);
        }
    }
}
