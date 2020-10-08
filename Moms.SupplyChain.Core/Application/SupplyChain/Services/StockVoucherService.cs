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
        private readonly IStockVoucherRepository _stockVoucherRepository;

        public StockVoucherService(IStockVoucherRepository stockVoucherRepository)
        {
            _stockVoucherRepository = stockVoucherRepository;
        }
        public async Task<(bool IsSuccess, StockVoucher stockVoucher, string ErrorMessage)> AddStockVoucher(StockVoucher stockVoucher)
        {
            try
            {
                if (stockVoucher == null)
                    return (false, stockVoucher, "No Stock Voucher found");

                if (stockVoucher.Id.IsNullOrEmpty())
                {
                    _stockVoucherRepository.Create(stockVoucher);
                }
                else
                {
                    _stockVoucherRepository.Update(stockVoucher);
                }
                await _stockVoucherRepository.Save();

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

                var voucher = await _stockVoucherRepository.GetAll(x => x.Id == id).FirstOrDefaultAsync();
                if (voucher == null)
                    return (false, id, "No record found.");
                _stockVoucherRepository.Delete(voucher);

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
                var voucher = _stockVoucherRepository.GetById(id);
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
                var result = await _stockVoucherRepository.GetAll().ToListAsync();
                return result == null ? (false, new List<StockVoucher>(), "Record not Found") : (true, result, "Stock Voucher Loaded");
            }
            catch (Exception e)
            {
                Log.Error("Stores Load: Error occurred", e);
                return (false, new List<StockVoucher>(), e.Message);
            }
        }
    }
}
