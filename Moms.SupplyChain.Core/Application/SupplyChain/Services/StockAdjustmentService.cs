using System;
using System.Collections.Generic;
using System.Linq;
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
    public class StockAdjustmentService : IStockAdjustmentService
    {
        private readonly IStockAdjustmentRepository _stockAdjustmentRepository;

        public StockAdjustmentService(IStockAdjustmentRepository stockAdjustmentRepository)
        {
            _stockAdjustmentRepository = stockAdjustmentRepository;
        }
        public async Task<(bool IsSuccess, StockAdjustment stockAdjustment, ResponseModel response)> AddStockAdjustment(StockAdjustment stockAdjustment)
        {
            try
            {
                if (stockAdjustment == null)
                    return (false, stockAdjustment, new ResponseModel { message = "No record found", data = stockAdjustment, code = HttpStatusCode.NotFound });

                if (stockAdjustment.Id.IsNullOrEmpty())
                {
                    _stockAdjustmentRepository.Create(stockAdjustment);
                }
                else
                {
                    _stockAdjustmentRepository.Update(stockAdjustment);
                }
                await _stockAdjustmentRepository.Save();

                return (true, stockAdjustment, new ResponseModel { message = "Stock Voucher item created successfully", data = stockAdjustment, code = HttpStatusCode.OK });
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public async Task<(bool IsSuccess, Guid id, ResponseModel response)> DeleteStockAdjustment(Guid id)
        {
            try
            {

                var voucher = await _stockAdjustmentRepository.GetAll(x => x.Id == id).FirstOrDefaultAsync();
                if (voucher == null)
                    return (false, id, new ResponseModel { message ="No record found." , data = voucher, code = HttpStatusCode.NotFound });
                voucher.VoidDate = DateTime.Now;
                voucher.Void = true;
                _stockAdjustmentRepository.Update(voucher);
                await _stockAdjustmentRepository.Save();

                return (true, id, new ResponseModel { message = "Record deleted successfully.", data = id, code = HttpStatusCode.OK });
            }
            catch (Exception e)
            {
                return (false, id, new ResponseModel { message = e.Message, data = id, code = HttpStatusCode.InternalServerError });
            }
        }

        public (bool IsSuccess, StockAdjustment stockAdjustment, ResponseModel response) GetStockAdjustment(Guid id)
        {
            try
            {
                var stockAdjustment = _stockAdjustmentRepository.GetById(id);
                if (stockAdjustment == null)
                    return (false, null, new ResponseModel { message = "No record found.", data =stockAdjustment , code = HttpStatusCode.NotFound });
                return (true, stockAdjustment, new ResponseModel { message = "Stock adjustment loaded successfully", data = stockAdjustment, code = HttpStatusCode.OK });
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return (false, null, new ResponseModel { message = e.Message, data = null, code = HttpStatusCode.InternalServerError });
            }
        }

        public async Task<(bool IsSuccess, IEnumerable<StockAdjustment>, ResponseModel response)> LoadStockAdjustment()
        {
            try
            {
                var result = await _stockAdjustmentRepository.GetAll(x => x.Void == false).OrderByDescending(x => x.CreateDate).ToListAsync();
                return result.Count == 0 ? (false, new List<StockAdjustment>(), new ResponseModel { message = "No Record Found", data = result, code = HttpStatusCode.NotFound }) : (true, result, new ResponseModel { message = "Records Loaded", data = result, code = HttpStatusCode.OK });
            }
            catch (Exception e)
            {
                Log.Error("Error Loading Stock Adjustments: Error occurred", e);
                return (false, new List<StockAdjustment>(), new ResponseModel { message = e.Message, data = new List<StockAdjustment>(), code = HttpStatusCode.NotFound });
            }
        }
    }
}
