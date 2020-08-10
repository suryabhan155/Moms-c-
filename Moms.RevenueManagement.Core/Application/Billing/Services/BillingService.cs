using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Moms.RevenueManagement.Core.Domain.Billing;
using Moms.RevenueManagement.Core.Domain.Billing.Dto;
using Serilog;

namespace Moms.RevenueManagement.Core.Application.Billing.Services
{
    public class BillingService : IBillingService
    {
        private readonly IMapper _mapper;
        private readonly IPaymentTypeRepository _paymentTypeRepository;

        public BillingService(IMapper mapper, IPaymentTypeRepository paymentTypeRepository)
        {
            _mapper = mapper;
            _paymentTypeRepository = paymentTypeRepository;
        }

        public IEnumerable<PaymentTypeDto> LoadPaymentTypes()
        {
            try
            {
                var paymentTypes = _paymentTypeRepository.GetAll().ToList();
                return _mapper.Map<List<PaymentTypeDto>>(paymentTypes);
            }
            catch (Exception e)
            {
                Log.Error("Error occured",e);
                throw new Exception($"Error loading records ! {e.Message}");
            }
        }
    }
}
