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
    public class StockAdjustmentItemService : IStockAdjustmentItemService
    {
        private readonly IStockAdjustmentItemRepository _stockAdjustmentItemRepository;

        public StockAdjustmentItemService(IStockAdjustmentItemRepository stockAdjustmentItemRepository)
        {
            _stockAdjustmentItemRepository = stockAdjustmentItemRepository;
        }
        public async Task<(bool IsSuccess, StockAdjustmentItem stockAdjustmentItem, ResponseModel response)> AddStockAdjustmentItem(StockAdjustmentItem stockAdjustmentItem)
        {
            try
            {
                if (stockAdjustmentItem == null)
                    return (false, stockAdjustmentItem, new ResponseModel { message = "No record found", data = stockAdjustmentItem, code = HttpStatusCode.NotFound });

                if (stockAdjustmentItem.Id.IsNullOrEmpty())
                {
                    _stockAdjustmentItemRepository.Create(stockAdjustmentItem);
                }
                else
                {
                    _stockAdjustmentItemRepository.Update(stockAdjustmentItem);
                }
                await _stockAdjustmentItemRepository.Save();

                return (true, stockAdjustmentItem, new ResponseModel { message = "Stock adjustment item created successfully", data = stockAdjustmentItem, code = HttpStatusCode.OK });
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public async Task<(bool IsSuccess, Guid id, ResponseModel response)> DeleteStockAdjustmentItem(Guid id)
        {
            try
            {

                var voucher = await _stockAdjustmentItemRepository.GetAll(x => x.Id == id).FirstOrDefaultAsync();
                if (voucher == null)
                    return (false, id, new ResponseModel { message ="No record found." , data = voucher, code = HttpStatusCode.NotFound });
                voucher.VoidDate = DateTime.Now;
                voucher.Void = true;
                _stockAdjustmentItemRepository.Update(voucher);
                await _stockAdjustmentItemRepository.Save();

                return (true, id, new ResponseModel { message = "Record deleted successfully.", data = id, code = HttpStatusCode.OK });
            }
            catch (Exception e)
            {
                return (false, id, new ResponseModel { message = e.Message, data = id, code = HttpStatusCode.InternalServerError });
            }
        }

        public (bool IsSuccess, StockAdjustmentItem stockAdjustmentItem, ResponseModel response) GetStockAdjustmentItem(Guid id)
        {
            try
            {
                var stockAdjustmentItem = _stockAdjustmentItemRepository.GetById(id);
                if (stockAdjustmentItem == null)
                    return (false, null, new ResponseModel { message = "No record found.", data =stockAdjustmentItem , code = HttpStatusCode.NotFound });
                return (true, stockAdjustmentItem, new ResponseModel { message = "Stock adjustment item loaded successfully", data = stockAdjustmentItem, code = HttpStatusCode.OK });
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return (false, null, new ResponseModel { message = e.Message, data = null, code = HttpStatusCode.InternalServerError });
            }
        }

        public async Task<(bool IsSuccess, IEnumerable<StockAdjustmentItem>, ResponseModel response)> LoadStockAdjustmentItem()
        {
            try
            {
                var result = await _stockAdjustmentItemRepository.GetAll(x => x.Void == false).OrderByDescending(x => x.CreateDate).ToListAsync();
                return result.Count == 0 ? (false, new List<StockAdjustmentItem>(), new ResponseModel { message = "No Record Found", data = result, code = HttpStatusCode.NotFound }) : (true, result, new ResponseModel { message = "Records Loaded", data = result, code = HttpStatusCode.OK });
            }
            catch (Exception e)
            {
                Log.Error("Error Loading Stock Adjustment Items: Error occurred", e);
                return (false, new List<StockAdjustmentItem>(), new ResponseModel { message = e.Message, data = new List<StockAdjustmentItem>(), code = HttpStatusCode.NotFound });
            }
        }
    }
}
