using AutoMapper;
using Moms.Revenue.Core.Domain.Billing.Models;

namespace Moms.Revenue.Core.Domain.Billing.Dto
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
