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
    public class StockVoucherService : IStockVoucherService
    {
        private readonly IMapper _mapper;
        private readonly IStockVoucherRepository _repository;

        public StockVoucherService(IStockVoucherRepository iRepository, IMapper iMapper)
        {
            _mapper = iMapper;
            _repository = iRepository;
        }
        public async Task<(bool IsSuccess, StockVoucher stockVoucher, string ErrorMessage)> AddStockVoucher(StockVoucher stockVoucher)
        {
            try
            {
                if (stockVoucher == null)
                    return (false, stockVoucher, "No Stock Voucher found");

                if (stockVoucher.Id.IsNullOrEmpty())
                {
                    _repository.Create(stockVoucher);
                }
                else
                {
                    _repository.Update(stockVoucher);
                }
                await _repository.Save();

                return (true, stockVoucher, "Stock Voucher created successfully");
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public async Task<(bool IsSuccess, Guid id, string ErrorMessage)> DeleteStockVoucher(Guid id)
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

        public (bool IsSuccess, StockVoucher stockVouchers, string ErrorMessage) GetStockVoucher(Guid id)
        {
            try
            {
                var voucher = _repository.GetById(id);
                if (voucher == null)
                    return (false, null, "Voucher not found.");
                return (true, voucher, "Voucher loaded successfully");
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return (false, null, $"{e.Message}");
            }
        }

        public async Task<(bool IsSuccess, IEnumerable<StockVoucher>, string ErrorMessage)> LoadStockVoucher()
        {
            try
            {
                var stockVoucher = await _repository.GetAll().ToListAsync();

                return (true, _mapper.Map<List<StockVoucher>>(stockVoucher), "Stock Voucher Loaded Successfully");
            }
            catch (Exception e)
            {
                Log.Error("Stores Load: Error occurred", e);
                IEnumerable<StockVoucher> stockVoucher = new List<StockVoucher>();
                return (false, stockVoucher, e.Message);
            }
        }
    }
}
