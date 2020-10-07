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
        private readonly IMapper _mapper;
        private readonly IStoreRepository _iStoreRepository;

        public StoreService(IStoreRepository iStoreRepository, IMapper iMapper)
        {
            _mapper = iMapper;
            _iStoreRepository = iStoreRepository;
        }


        public async Task<(bool IsSuccess, IEnumerable<Store>, string ErrorMessage)> LoadStores()
        {
            try
            {
                var stores = await _iStoreRepository.GetAll().ToListAsync();

                return (true, _mapper.Map<List<Store>>(stores), "Stores Loaded Successfully");
            }
            catch (Exception e)
            {
                Log.Error("Stores Load: Error occurred", e);
                IEnumerable<Store> stores = new List<Store>();
                return (false, stores, e.Message);
            }
        }



        public (bool IsSuccess, Store stores, string ErrorMessage) GetStore(Guid id)
        {
            try
            {
                var store = _iStoreRepository.GetById(id);
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
                    _iStoreRepository.Create(store);
                }
                else
                {
                    _iStoreRepository.Update(store);
                }
                await _iStoreRepository.Save();

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

                var stores = await _iStoreRepository.GetAll(x => x.Id == id).FirstOrDefaultAsync();
                if (stores == null)
                    return (false, id, "No record found.");
                _iStoreRepository.Delete(stores);

                return (false, id, "Record deleted successfully.");
            }
            catch (Exception e)
            {
                return (false, id, $"{e.Message}");
            }
        }


    }
}
