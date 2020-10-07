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
        private readonly IMapper _mapper;
        private readonly IStockVoucherItemRepository _repository;

        public StockVoucherItemService(IStockVoucherItemRepository iRepository, IMapper iMapper)
        {
            _mapper = iMapper;
            _repository = iRepository;
        }
        public async Task<(bool IsSuccess, StockVoucherItem stockVoucherItem, string ErrorMessage)> AddStockVoucherItem(StockVoucherItem stockVoucherItem)
        {
            try
            {
                if (stockVoucherItem == null)
                    return (false, stockVoucherItem, "No Stock Voucher item found");

                if (stockVoucherItem.Id.IsNullOrEmpty())
                {
                    _repository.Create(stockVoucherItem);
                }
                else
                {
                    _repository.Update(stockVoucherItem);
                }
                await _repository.Save();

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

                var voucher = await _repository.GetAll(x => x.Id == id).FirstOrDefaultAsync();
                if (voucher == null)
                    return (false, id, "No record found.");
                _repository.Delete(voucher);

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
                var voucher = _repository.GetById(id);
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
                var stockVoucherItems = await _repository.GetAll().ToListAsync();

                return (true, _mapper.Map<List<StockVoucherItem>>(stockVoucherItems), "Stock Voucher items Loaded Successfully");
            }
            catch (Exception e)
            {
                Log.Error("Stores Load: Error occurred", e);
                IEnumerable<StockVoucherItem> stockVoucher = new List<StockVoucherItem>();
                return (false, stockVoucher, e.Message);
            }
        }
    }
}
