using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Moms.SupplyChain.Core.Domain.SupplyChain.Models;

namespace Moms.SupplyChain.Core.Domain.SupplyChain.Services
{
   public interface IStoreService
   {
       Task<(bool IsSuccess, IEnumerable<Store>, String ErrorMessage)> LoadStores();
       (bool IsSuccess, Store stores, String ErrorMessage) GetStore(Guid id);
       Task<(bool IsSuccess, Guid id, String ErrorMessage)> DeleteStore(Guid id);
       Task<(bool IsSuccess, Store store, String ErrorMessage)> AddStore(Store store);

   }
}
