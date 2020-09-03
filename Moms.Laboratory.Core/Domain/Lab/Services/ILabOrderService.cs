using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Moms.Laboratory.Core.Domain.Lab.Models;

namespace Moms.Laboratory.Core.Domain.Lab.Services
{
    public interface ILabOrderService
    {

        Task<(bool IsSuccess, IEnumerable<LabOrder>, string ErrorMessage)> LoadLabOrders();
        Task<(bool IsSuccess, IEnumerable<LabOrder> labOrders, string ErrorMessage)> GetLabOrder(Guid id);
        Task<(bool IsSuccess, Guid id, string ErrorMessage)> DeleteLabOrder(Guid id);
        Task<(bool IsSuccess, LabOrder labOrder, string ErrorMEssage)> AddLabOrder(LabOrder labOrder);
    }
}
