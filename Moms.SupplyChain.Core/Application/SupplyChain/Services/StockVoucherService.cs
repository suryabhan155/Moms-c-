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
    public class StockVoucherService : IStockVoucherService
    {
        private readonly IStockVoucherRepository _stockVoucherRepository;

        public StockVoucherService(IStockVoucherRepository stockVoucherRepository)
        {
            _stockVoucherRepository = stockVoucherRepository;
        }
        public async Task<(bool IsSuccess, StockVoucher stockVoucher, ResponseModel response)> AddStockVoucher(StockVoucher stockVoucher)
        {
            try
            {
                if (stockVoucher == null)
                    return (false, stockVoucher, new ResponseModel { message ="No Stock Voucher found" , data =stockVoucher , code = HttpStatusCode.NotFound });

                if (stockVoucher.Id.IsNullOrEmpty())
                {
                    _stockVoucherRepository.Create(stockVoucher);
                }
                else
                {
                    _stockVoucherRepository.Update(stockVoucher);
                }
                await _stockVoucherRepository.Save();

                return (true, stockVoucher, new ResponseModel { message = "Stock Voucher created successfully", data = stockVoucher, code = HttpStatusCode.OK });
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public async Task<(bool IsSuccess, Guid id, ResponseModel response)> DeleteStockVoucher(Guid id)
        {
            try
            {
                var voucher = await _stockVoucherRepository.GetAll(x => x.Id == id).FirstOrDefaultAsync();
                if (voucher == null)
                    return (false, id, new ResponseModel { message = "No record found.", data = voucher, code = HttpStatusCode.NotFound });
                voucher.VoidDate = DateTime.Now;
                voucher.Void = true;
                _stockVoucherRepository.Update(voucher);
                await _stockVoucherRepository.Save();

                return (true, id, new ResponseModel { message ="Record deleted successfully." , data = voucher, code = HttpStatusCode.OK });
            }
            catch (Exception e)
            {
                return (false, id, new ResponseModel { message = e.Message, data = id, code = HttpStatusCode.InternalServerError });
            }
        }

        public (bool IsSuccess, StockVoucher stockVouchers, ResponseModel response) GetStockVoucher(Guid id)
        {
            try
            {
                var voucher = _stockVoucherRepository.GetById(id);
                if (voucher == null)
                    return (false, null, new ResponseModel { message = "Voucher not found.", data = voucher, code = HttpStatusCode.NotFound });
                return (true, voucher, new ResponseModel { message = "Voucher loaded successfully", data =voucher , code = HttpStatusCode.OK });
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return (false, null, new ResponseModel { message = e.Message, data = null, code = HttpStatusCode.InternalServerError });
            }
        }

        public async Task<(bool IsSuccess, IEnumerable<StockVoucher>, ResponseModel response)> LoadStockVoucher()
        {
            try
            {
                var result =await _stockVoucherRepository.GetAll(x => x.Void == false).OrderByDescending(x => x.CreateDate).ToListAsync();
                return result.Count == 0 ? (false, new List<StockVoucher>(), new ResponseModel { message ="Record not Found" , data =result , code = HttpStatusCode.NotFound } ) : (true, result, new ResponseModel { message ="Stock Voucher Loaded" , data =result , code = HttpStatusCode.OK });
            }
            catch (Exception e)
            {
                Log.Error("Stores Load: Error occurred", e);
                return (false, new List<StockVoucher>(), new ResponseModel { message = e.Message, data = new List<StockVoucher>(), code = HttpStatusCode.InternalServerError });
            }
        }
    }
}
