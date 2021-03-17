using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Moms.SharedKernel.Response;
using Moms.SupplyChain.Core.Domain.SupplyChain.Models;

namespace Moms.SupplyChain.Core.Domain.SupplyChain.Services
{
    public interface ISupplierService
    {
        Task<(bool IsSuccess, IEnumerable<Supplier>, ResponseModel response)> LoadSuppliers();
        (bool IsSuccess, Supplier supplier, ResponseModel response) GetSupplier(Guid id);
        Task<(bool IsSuccess, Guid id, ResponseModel response)> DeleteSupplier(Guid id);
        Task<(bool IsSuccess, Supplier supplier, ResponseModel response)> AddSupplier(Supplier supplier);
    }
}
