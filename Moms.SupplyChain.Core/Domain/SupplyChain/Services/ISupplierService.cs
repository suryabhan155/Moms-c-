using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Moms.SupplyChain.Core.Domain.SupplyChain.Models;

namespace Moms.SupplyChain.Core.Domain.SupplyChain.Services
{
    public interface ISupplierService
    {
        Task<(bool IsSuccess, IEnumerable<Supplier>, String ErrorMessage)> LoadSupplies();
        (bool IsSuccess, Supplier supplier, String ErrorMessage) GetSupplier(Guid id);
        Task<(bool IsSuccess, Guid id, String ErrorMessage)> DeleteSupplier(Guid id);
        Task<(bool IsSuccess, Supplier supplier, String ErrorMessage)> AddSupplier(Supplier supplier);

    }
}
