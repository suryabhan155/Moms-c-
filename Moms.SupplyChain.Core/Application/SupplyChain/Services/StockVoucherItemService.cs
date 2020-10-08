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
    public class StockVoucherItemService : IStockVoucherItemService
    {
        private readonly IStockVoucherItemRepository _stockVoucherItemRepository;

        public StockVoucherItemService(IStockVoucherItemRepository  stockVoucherItemRepository)
        {
            _stockVoucherItemRepository = stockVoucherItemRepository;
        }
        public async Task<(bool IsSuccess, StockVoucherItem stockVoucherItem, string ErrorMessage)> AddStockVoucherItem(StockVoucherItem stockVoucherItem)
        {
            try
            {
                if (stockVoucherItem == null)
                    return (false, stockVoucherItem, "No Stock Voucher item found");

                if (stockVoucherItem.Id.IsNullOrEmpty())
                {
                    _stockVoucherItemRepository.Create(stockVoucherItem);
                }
                else
                {
                    _stockVoucherItemRepository.Update(stockVoucherItem);
                }
                await _stockVoucherItemRepository.Save();

                return (true, stockVoucherItem, "Stock Voucher item created successfully");
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public async Task<(bool IsSuccess, Guid id, string ErrorMessage)> DeleteStockVoucherItem(Guid id)
        {
            try
            {

                var voucher = await _stockVoucherItemRepository.GetAll(x => x.Id == id).FirstOrDefaultAsync();
                if (voucher == null)
                    return (false, id, "No record found.");
                _stockVoucherItemRepository.Delete(voucher);

                return (false, id, "Record deleted successfully.");
            }
            catch (Exception e)
            {
                return (false, id, $"{e.Message}");
            }
        }

        public (bool IsSuccess, StockVoucherItem stockVoucherItems, string ErrorMessage) GetStockVoucherItem(Guid id)
        {
            try
            {
                var voucher = _stockVoucherItemRepository.GetById(id);
                if (voucher == null)
                    return (false, null, "Voucher item not found.");
                return (true, voucher, "Voucher item loaded successfully");
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return (false, null, $"{e.Message}");
            }
        }

        public async Task<(bool IsSuccess, IEnumerable<StockVoucherItem>, string ErrorMessage)> LoadStockVoucherItem()
        {
            try
            {
                var result = await _stockVoucherItemRepository.GetAll().ToListAsync();
                return result == null ? (false, new List<StockVoucherItem>(), "Record Not Found") : (true, result, "Stock Voucher Loaded");
            }
            catch (Exception e)
            {
                Log.Error("Stores Load: Error occurred", e);
                return (false, new List<StockVoucherItem>(), e.Message);
            }
        }
    }
}
