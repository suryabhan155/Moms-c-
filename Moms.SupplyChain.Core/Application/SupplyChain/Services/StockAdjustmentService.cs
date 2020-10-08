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
    public class StockAdjustmentService : IStockAdjustmentService
    {
        private readonly IStockAdjustmentRepository _stockAdjustmentRepository;

        public StockAdjustmentService(IStockAdjustmentRepository stockAdjustmentRepository)
        {
            _stockAdjustmentRepository = stockAdjustmentRepository;
        }
        public async Task<(bool IsSuccess, StockAdjustment stockAdjustment, string ErrorMessage)> AddStockAdjustment(StockAdjustment stockAdjustment)
        {
            try
            {
                if (stockAdjustment == null)
                    return (false, stockAdjustment, "No record found");

                if (stockAdjustment.Id.IsNullOrEmpty())
                {
                    _stockAdjustmentRepository.Create(stockAdjustment);
                }
                else
                {
                    _stockAdjustmentRepository.Update(stockAdjustment);
                }
                await _stockAdjustmentRepository.Save();

                return (true, stockAdjustment, "Stock Voucher item created successfully");
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public async Task<(bool IsSuccess, Guid id, string ErrorMessage)> DeleteStockAdjustment(Guid id)
        {
            try
            {

                var voucher = await _stockAdjustmentRepository.GetAll(x => x.Id == id).FirstOrDefaultAsync();
                if (voucher == null)
                    return (false, id, "No record found.");
                _stockAdjustmentRepository.Delete(voucher);

                return (false, id, "Record deleted successfully.");
            }
            catch (Exception e)
            {
                return (false, id, $"{e.Message}");
            }
        }

        public (bool IsSuccess, StockAdjustment stockAdjustment, string ErrorMessage) GetStockAdjustment(Guid id)
        {
            try
            {
                var stockAdjustment = _stockAdjustmentRepository.GetById(id);
                if (stockAdjustment == null)
                    return (false, null, "No record found.");
                return (true, stockAdjustment, "Stock adjustment loaded successfully");
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return (false, null, $"{e.Message}");
            }
        }

        public async Task<(bool IsSuccess, IEnumerable<StockAdjustment>, string ErrorMessage)> LoadStockAdjustment()
        {
            try
            {
                var result = await _stockAdjustmentRepository.GetAll().ToListAsync();
                return result == null ? (false, new List<StockAdjustment>(), "No Record Found") : (true, result, "Records Loaded");
            }
            catch (Exception e)
            {
                Log.Error("Error Loading Stock Adjustments: Error occurred", e);
                return (false, new List<StockAdjustment>(), e.Message);
            }
        }
    }
}
