using System;
using System.Collections.Generic;
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
    public class SupplierService:ISupplierService
    {
        private readonly ISupplierRepository _supplierRepository;

        public SupplierService(ISupplierRepository supplierRepository)
        {
            _supplierRepository = supplierRepository;
        }

        public async Task<(bool IsSuccess, IEnumerable<Supplier>, ResponseModel response)> LoadSuppliers()
        {
            try
            {
                var result = _supplierRepository.GetAllOrder(x => x.Void == false, x => x.CreateDate, Sorted.DESC);
                return result == null ? (false, new List<Supplier>(), new ResponseModel { message = "Record Not Found", data =result , code = HttpStatusCode.NotFound }) : (true, result, new ResponseModel { message ="Suppliers Loaded Successfully" , data = result, code = HttpStatusCode.OK });
            }
            catch (Exception e)
            {
                Log.Error("Suppliers Load: Error occurred", e);
                return (false, new List<Supplier>(), new ResponseModel { message = e.Message, data = new List<Supplier>(), code = HttpStatusCode.InternalServerError });
            }
        }


        public Task<(bool IsSuccess, IEnumerable<Supplier>, ResponseModel response)> LoadSupplies()
        {
            throw new NotImplementedException();
        }

        public (bool IsSuccess, Supplier supplier, ResponseModel response) GetSupplier(Guid id)
        {
            try
            {
                var result = _supplierRepository.GetById(id);
                return result == null ? (false, new Supplier(), new ResponseModel { message = "Supplier Not Found", data = result, code = HttpStatusCode.NotFound }) : (true, result, new ResponseModel { message ="Supplier loaded successfully" , data = result, code = HttpStatusCode.OK });
            }
            catch (Exception e)
            {
                Log.Error("Suppliers Load: Error occurred", e);
                return (false, new Supplier(), new ResponseModel { message = e.Message, data =new Supplier() , code = HttpStatusCode.InternalServerError });
            }
        }

        public async Task<(bool IsSuccess, Supplier supplier, ResponseModel response)> AddSupplier(Supplier supplier)
        {
            try
            {
                if (supplier == null)
                    return (false, supplier, new ResponseModel { message ="No supplier found" , data =supplier , code = HttpStatusCode.NotFound });

                if (supplier.Id.IsNullOrEmpty())
                {
                    _supplierRepository.Create(supplier);
                }
                else
                {
                    _supplierRepository.Update(supplier);
                }
                await _supplierRepository.Save();

                return (true, supplier, new ResponseModel { message = "Supplier created successfully", data = supplier, code = HttpStatusCode.OK });
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
        public async Task<(bool IsSuccess, Guid id, ResponseModel response)> DeleteSupplier(Guid id)
        {
            try
            {

                var supplier = await _supplierRepository.GetAll(x => x.Id == id).FirstOrDefaultAsync();
                if (supplier == null)
                    return (false, id, new ResponseModel { message ="No record found." , data = supplier, code = HttpStatusCode.NotFound });
                supplier.VoidDate = DateTime.Now;
                supplier.Void = true;
                _supplierRepository.Update(supplier);
                await _supplierRepository.Save();

                return (true, id, new ResponseModel { message = "Record deleted successfully.", data = supplier, code = HttpStatusCode.OK });
            }
            catch (Exception e)
            {
                return (false, id, new ResponseModel { message = e.Message, data = id, code = HttpStatusCode.InternalServerError });
            }
        }
    }
}
