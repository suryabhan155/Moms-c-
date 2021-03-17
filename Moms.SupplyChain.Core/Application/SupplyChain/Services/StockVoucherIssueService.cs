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
    public class StockVoucherIssueService : IStockVoucherIssueService
    {
        private readonly IStockVoucherIssueRepository _stockVoucherIssueRepository;

        public StockVoucherIssueService(IStockVoucherIssueRepository stockVoucherIssueRepository)
        {
            _stockVoucherIssueRepository = stockVoucherIssueRepository;
        }
        public async Task<(bool IsSuccess, StockVoucherIssue stockVoucherIssue, ResponseModel response)> AddStockVoucherIssue(StockVoucherIssue stockVoucher)
        {
            try
            {
                if (stockVoucher == null)
                    return (false, stockVoucher, new ResponseModel { message ="No Stock Voucher Issue found" , data =stockVoucher , code = HttpStatusCode.NotFound });

                if (stockVoucher.Id.IsNullOrEmpty())
                {
                    _stockVoucherIssueRepository.Create(stockVoucher);
                }
                else
                {
                    _stockVoucherIssueRepository.Update(stockVoucher);
                }
                await _stockVoucherIssueRepository.Save();

                return (true, stockVoucher, new ResponseModel { message = "Stock Voucher Issue created successfully", data = stockVoucher, code = HttpStatusCode.OK });
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public async Task<(bool IsSuccess, Guid id, ResponseModel response)> DeleteStockVoucherIssue(Guid id)
        {
            try
            {
                var voucher = await _stockVoucherIssueRepository.GetAll(x => x.Id == id).FirstOrDefaultAsync();
                if (voucher == null)
                    return (false, id, new ResponseModel { message = "No record found.", data = voucher, code = HttpStatusCode.NotFound });
                voucher.VoidDate = DateTime.Now;
                voucher.Void = true;
                _stockVoucherIssueRepository.Update(voucher);
                await _stockVoucherIssueRepository.Save();

                return (true, id, new ResponseModel { message ="Record deleted successfully." , data = voucher, code = HttpStatusCode.OK });
            }
            catch (Exception e)
            {
                return (false, id, new ResponseModel { message = e.Message, data = id, code = HttpStatusCode.InternalServerError });
            }
        }

        public (bool IsSuccess, StockVoucherIssue stockVoucherIssues, ResponseModel response) GetStockVoucherIssue(Guid id)
        {
            try
            {
                var voucher = _stockVoucherIssueRepository.GetById(id);
                if (voucher == null)
                    return (false, null, new ResponseModel { message = "Stock Voucher Issue not found.", data = voucher, code = HttpStatusCode.NotFound });
                return (true, voucher, new ResponseModel { message = "Stock Voucher Issue loaded successfully", data =voucher , code = HttpStatusCode.OK });
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return (false, null, new ResponseModel { message = e.Message, data = null, code = HttpStatusCode.InternalServerError });
            }
        }

        public async Task<(bool IsSuccess, IEnumerable<StockVoucherIssue>, ResponseModel response)> LoadStockVoucherIssue()
        {
            try
            {
                var result =await _stockVoucherIssueRepository.GetAll(x => x.Void == false).OrderByDescending(x => x.CreateDate).ToListAsync();
                return result.Count == 0 ? (false, new List<StockVoucherIssue>(), new ResponseModel { message ="Record not Found" , data =result , code = HttpStatusCode.NotFound } ) : (true, result, new ResponseModel { message ="Stock Voucher Issue Loaded" , data =result , code = HttpStatusCode.OK });
            }
            catch (Exception e)
            {
                Log.Error("Stores Load: Error occurred", e);
                return (false, new List<StockVoucherIssue>(), new ResponseModel { message = e.Message, data = new List<StockVoucherIssue>(), code = HttpStatusCode.InternalServerError });
            }
        }
    }
}
