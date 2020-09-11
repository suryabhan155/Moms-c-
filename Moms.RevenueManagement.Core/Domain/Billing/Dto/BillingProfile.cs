using AutoMapper;
using Moms.RevenueManagement.Core.Domain.Billing.Models;

namespace Moms.RevenueManagement.Core.Domain.Billing.Dto
{
    public class BillingProfile: Profile
    {
        public BillingProfile()
        {
            CreateMap<PaymentType, PaymentTypeDto>();
            CreateMap<BillingDiscount, BillingDiscountDto>();
            CreateMap<BillingType, BillingTypeDto>();
            CreateMap<ClientBill, ClientBillDto>();
            CreateMap<ClientBillingItem, ClientBillingItemDto>();
            CreateMap<PriceList, PriceListDto>();
        }
    }
}
