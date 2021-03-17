using Moms.Revenue.Core.Domain.Billing.Models;
using Moms.SharedKernel.Response;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Moms.Revenue.Core.Domain.Billing.Services
{
    public interface IBillingItemMasterService
    {
        Task<(bool IsSuccess, BillingItemMaster itemMaster, ResponseModel model)> Create(BillingItemMaster itemMaster);
        Task<(bool IsSuccess, IEnumerable<BillingItemMaster> itemMaster, ResponseModel model)> GetAllItemMaster();
        Task<(bool IsSuccess, BillingItemMaster itemMaster, ResponseModel model)> GetItemMaster(Guid Id);
        Task<(bool IsSuccess, Guid Id, ResponseModel model)> Delete(Guid Id);
    }
}
