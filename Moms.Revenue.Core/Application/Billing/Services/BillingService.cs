using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Moms.Revenue.Core.Domain.Billing;
using Moms.Revenue.Core.Domain.Billing.Dto;
using Moms.Revenue.Core.Domain.Billing.Models;
using Moms.Revenue.Core.Domain.Billing.Services;
using Serilog;
using Moms.SharedKernel.Response;

namespace Moms.Revenue.Core.Application.Billing.Services
{
    public class BillingService : IClientBillingService
    {
        private readonly IMapper _mapper;
        private readonly IPaymentTypeRepository _paymentTypeRepository;

        public BillingService(IMapper mapper, IPaymentTypeRepository paymentTypeRepository)
        {
            _mapper = mapper;
            _paymentTypeRepository = paymentTypeRepository;
        }

       /* public IEnumerable<PaymentTypeDto> LoadPaymentTypes()
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
        }*/

        public Task<(bool IsSuccess, ClientBill clientBill, ResponseModel model)> Create(ClientBill clientBill)
        {
            throw new NotImplementedException();
        }

        public Task<(bool IsSuccess, IEnumerable<ClientBill> clientBills, ResponseModel model)> GetAllBilling()
        {
            throw new NotImplementedException();
        }

        public Task<(bool IsSuccess, IEnumerable<ClientBill> clientBill, ResponseModel model)> GetClientBill(Guid Id)
        {
            throw new NotImplementedException();
        }


        public Task<(bool IsSuccess, Guid Id, ResponseModel model)> Delete(Guid Id)
        {
            throw new NotImplementedException();
        }
    }
}
