using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Moms.SharedKernel.Response;
using Moms.SupplyChain.Core.Domain.SupplyChain.Models;

namespace Moms.SupplyChain.Core.Domain.SupplyChain.Services
{
   public interface IStoreService
   {
       Task<(bool IsSuccess, IEnumerable<Store>, ResponseModel response)> LoadStores();
       (bool IsSuccess, Store stores, ResponseModel response) GetStore(Guid id);
       Task<(bool IsSuccess, Guid id, ResponseModel response)> DeleteStore(Guid id);
       Task<(bool IsSuccess, Store store, ResponseModel response)> AddStore(Store store);

   }
}
