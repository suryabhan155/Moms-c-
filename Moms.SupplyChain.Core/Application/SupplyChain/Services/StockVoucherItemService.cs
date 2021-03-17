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
    public class StockVoucherItemService : IStockVoucherItemService
    {
        private readonly IStockVoucherItemRepository _stockVoucherItemRepository;

        public StockVoucherItemService(IStockVoucherItemRepository  stockVoucherItemRepository)
        {
            _stockVoucherItemRepository = stockVoucherItemRepository;
        }
        public async Task<(bool IsSuccess, StockVoucherItem stockVoucherItem, ResponseModel response)> AddStockVoucherItem(StockVoucherItem stockVoucherItem)
        {
            try
            {
                if (stockVoucherItem == null)
                    return (false, stockVoucherItem, new ResponseModel { message = "No Stock Voucher item found", data = stockVoucherItem, code = HttpStatusCode.NotFound });

                if (stockVoucherItem.Id.IsNullOrEmpty())
                {
                    _stockVoucherItemRepository.Create(stockVoucherItem);
                }
                else
                {
                    _stockVoucherItemRepository.Update(stockVoucherItem);
                }
                await _stockVoucherItemRepository.Save();

                return (true, stockVoucherItem, new ResponseModel { message = "Stock Voucher item created successfully", data = stockVoucherItem, code = HttpStatusCode.OK });
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public async Task<(bool IsSuccess, Guid id, ResponseModel response)> DeleteStockVoucherItem(Guid id)
        {
            try
            {

                var voucher = await _stockVoucherItemRepository.GetAll(x => x.Id == id).FirstOrDefaultAsync();
                if (voucher == null)
                    return (false, id, new ResponseModel { message = "No record found.", data =voucher , code = HttpStatusCode.NotFound });
                voucher.VoidDate = DateTime.Now;
                voucher.Void = true;
                _stockVoucherItemRepository.Update(voucher);
                await _stockVoucherItemRepository.Save();

                return (true, id, new ResponseModel { message = "Record deleted successfully.", data = voucher, code = HttpStatusCode.OK });
            }
            catch (Exception e)
            {
                return (false, id, new ResponseModel { message = e.Message, data = id, code = HttpStatusCode.InternalServerError });
            }
        }

        public (bool IsSuccess, StockVoucherItem stockVoucherItems, ResponseModel response) GetStockVoucherItem(Guid id)
        {
            try
            {
                var voucher = _stockVoucherItemRepository.GetById(id);
                if (voucher == null)
                    return (false, null, new ResponseModel { message ="Voucher item not found." , data = voucher, code = HttpStatusCode.NotFound });
                return (true, voucher, new ResponseModel { message = "Voucher item loaded successfully", data = voucher, code = HttpStatusCode.OK });
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return (false, null, new ResponseModel { message = e.Message, data = null, code = HttpStatusCode.InternalServerError });
            }
        }

        public async Task<(bool IsSuccess, IEnumerable<StockVoucherItem>, ResponseModel response)> LoadStockVoucherItem()
        {
            try
            {
                var result = await _stockVoucherItemRepository.GetAll(x => x.Void == false).OrderByDescending(x => x.CreateDate).ToListAsync();
                return result.Count == 0 ? (false, new List<StockVoucherItem>(), new ResponseModel { message ="Record Not Found" , data = result, code = HttpStatusCode.NotFound } ) : (true, result, new ResponseModel { message ="Stock Voucher Loaded" , data =result , code = HttpStatusCode.OK });
            }
            catch (Exception e)
            {
                Log.Error("Stores Load: Error occurred", e);
                return (false, new List<StockVoucherItem>(), new ResponseModel { message = e.Message, data = new List<StockVoucherItem>(), code = HttpStatusCode.NotFound });
            }
        }
    }
}
