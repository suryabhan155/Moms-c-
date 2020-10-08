using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Moms.SharedKernel.Custom;
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


        public async Task<(bool IsSuccess, IEnumerable<Store>, string ErrorMessage)> LoadStores()
        {
            try
            {
                var result = await _storeRepository.GetAll().ToListAsync();
                return result == null ? (false, new List<Store>(), "No Record Found") : (true, result, "Stores Loaded");
            }
            catch (Exception e)
            {
                Log.Error("Stores Load: Error occurred", e);
                return (false, new List<Store>(), e.Message);
            }
        }



        public (bool IsSuccess, Store stores, string ErrorMessage) GetStore(Guid id)
        {
            try
            {
                var store = _storeRepository.GetById(id);
                if (store == null)
                    return (false, null, "Store not found.");
                return (true, store, "Store loaded successfully");
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return (false, null, $"{e.Message}");
            }
        }

        public async Task<(bool IsSuccess, Store store, string ErrorMessage)> AddStore(Store store)
        {
            try
            {
                if (store == null)
                    return (false, store, "No store found");

                if (store.Id.IsNullOrEmpty())
                {
                    _storeRepository.Create(store);
                }
                else
                {
                    _storeRepository.Update(store);
                }
                await _storeRepository.Save();

                return (true, store, "Stores created successfully");
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
        public async Task<(bool IsSuccess, Guid id, string ErrorMessage)> DeleteStore(Guid id)
        {
            try
            {

                var stores = await _storeRepository.GetAll(x => x.Id == id).FirstOrDefaultAsync();
                if (stores == null)
                    return (false, id, "No record found.");
                _storeRepository.Delete(stores);

                return (false, id, "Record deleted successfully.");
            }
            catch (Exception e)
            {
                return (false, id, $"{e.Message}");
            }
        }


    }
}
