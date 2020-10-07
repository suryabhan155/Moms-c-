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
        private readonly IMapper _mapper;
        private readonly IStockAdjustmentRepository _repository;

        public StockAdjustmentService(IStockAdjustmentRepository iRepository, IMapper iMapper)
        {
            _mapper = iMapper;
            _repository = iRepository;
        }
        public async Task<(bool IsSuccess, StockAdjustment stockAdjustment, string ErrorMessage)> AddStockAdjustment(StockAdjustment stockAdjustment)
        {
            try
            {
                if (stockAdjustment == null)
                    return (false, stockAdjustment, "No record found");

                if (stockAdjustment.Id.IsNullOrEmpty())
                {
                    _repository.Create(stockAdjustment);
                }
                else
                {
                    _repository.Update(stockAdjustment);
                }
                await _repository.Save();

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

        public (bool IsSuccess, StockAdjustment, string ErrorMessage) GetStockAdjustment(Guid id)
        {
            try
            {
                var stockAdjustment = _repository.GetById(id);
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
                var stockAdjustments = await _repository.GetAll().ToListAsync();

                return (true, _mapper.Map<List<StockAdjustment>>(stockAdjustments), "Stock adjustment Loaded Successfully");
            }
            catch (Exception e)
            {
                Log.Error("Stores Load: Error occurred", e);
                IEnumerable<StockAdjustment> stockAdjustments = new List<StockAdjustment>();
                return (false, stockAdjustments, e.Message);
            }
        }
    }
}
