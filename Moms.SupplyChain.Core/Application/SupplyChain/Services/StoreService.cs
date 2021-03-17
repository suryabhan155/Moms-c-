using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Moms.SharedKernel.Custom;
using Moms.SharedKernel.Interfaces.Persistence;
using Moms.SharedKernel.Response;
using Moms.SupplyChain.Core.Domain.SupplyChain;
using Moms.SupplyChain.Core.Domain.SupplyChain.Models;
using Moms.SupplyChain.Core.Domain.SupplyChain.Services;
using Serilog;

namespace Moms.SupplyChain.Core.Application.SupplyChain.Services
{
    public class StoreService:IStoreService
    {
        private readonly IStoreRepository _storeRepository;

        public StoreService(IStoreRepository storeRepository)
        {
            _storeRepository = storeRepository;
        }


        public async Task<(bool IsSuccess, IEnumerable<Store>, ResponseModel response)> LoadStores()
        {
            try
            {
                var result = _storeRepository.GetAllOrder(x => x.Void == false, x=>x.CreateDate, Sorted.DESC);
                return result == null ? (false, new List<Store>(), new ResponseModel{message = "No Record Found", data = new List<Store>(), code = HttpStatusCode.NotFound }) : (true, result, new ResponseModel { message = "Stores Loaded", data = result, code = HttpStatusCode.OK });
            }
            catch (Exception e)
            {
                Log.Error("Stores Load: Error occurred", e);
                return (false, new List<Store>(), new ResponseModel { message = e.Message, data = new List<Store>(), code = HttpStatusCode.InternalServerError });
            }
        }



        public (bool IsSuccess, Store stores, ResponseModel response) GetStore(Guid id)
        {
            try
            {
                var store = _storeRepository.GetById(id);
                if (store == null)
                    return (false, null, new ResponseModel { message = "Store not found.", data = store, code = HttpStatusCode.NotFound });
                return (true, store, new ResponseModel { message = "Store loaded successfully", data = store, code = HttpStatusCode.OK });
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return (false, null, new ResponseModel { message =e.Message , data = null, code = HttpStatusCode.InternalServerError });
            }
        }

        public async Task<(bool IsSuccess, Store store, ResponseModel response)> AddStore(Store store)
        {
            try
            {
                if (store == null)
                    return (false, store, new ResponseModel { message = "No store found", data = store, code = HttpStatusCode.NotFound });

                if (store.Id.IsNullOrEmpty())
                {
                    _storeRepository.Create(store);
                }
                else
                {
                    _storeRepository.Update(store);
                }
                await _storeRepository.Save();

                return (true, store, new ResponseModel { message = "Stores created successfully", data = store , code = HttpStatusCode.OK });
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
        public async Task<(bool IsSuccess, Guid id, ResponseModel response)> DeleteStore(Guid id)
        {
            try
            {

                var stores = await _storeRepository.GetAll(x => x.Id == id).FirstOrDefaultAsync();
                if (stores == null)
                    return (false, id, new ResponseModel { message = "No record found.", data = stores, code = HttpStatusCode.NotFound });
                else
                {
                    stores.VoidDate = DateTime.Now;
                    stores.Void = true;
                    _storeRepository.Update(stores);
                    await _storeRepository.Save();
                }

                return (false, id, new ResponseModel { message = "Record deleted successfully.", data = stores, code = HttpStatusCode.OK });
            }
            catch (Exception e)
            {
                return (false, id, new ResponseModel { message = e.Message, data = id, code = HttpStatusCode.InternalServerError });
            }
        }
    }
}
