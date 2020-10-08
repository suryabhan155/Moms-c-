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
    public class SupplierService:ISupplierService
    {
        private readonly ISupplierRepository _supplierRepository;

        public SupplierService(ISupplierRepository supplierRepository)
        {
            _supplierRepository = supplierRepository;
        }

        public async Task<(bool IsSuccess, IEnumerable<Supplier>, string ErrorMessage)> LoadSuppliers()
        {
            try
            {
                var result = await _supplierRepository.GetAll().ToListAsync();
                return result == null ? (false, new List<Supplier>(), "Record Not Found") : (true, result, "Suppliers Loaded Successfully");
            }
            catch (Exception e)
            {
                Log.Error("Suppliers Load: Error occurred", e);
                return (false, new List<Supplier>(), e.Message);
            }
        }


        public Task<(bool IsSuccess, IEnumerable<Supplier>, string ErrorMessage)> LoadSupplies()
        {
            throw new NotImplementedException();
        }

        public (bool IsSuccess, Supplier supplier, string ErrorMessage) GetSupplier(Guid id)
        {
            try
            {
                var result = _supplierRepository.GetById(id);
                return result == null ? (false, new Supplier(), "Supplier Not Found") : (true, result, "Supplier loaded successfully");
            }
            catch (Exception e)
            {
                Log.Error("Suppliers Load: Error occurred", e);
                return (false, new Supplier(), e.Message);
            }
        }

        public async Task<(bool IsSuccess, Supplier supplier, string ErrorMessage)> AddSupplier(Supplier supplier)
        {
            try
            {
                if (supplier == null)
                    return (false, supplier, "No supplier found");

                if (supplier.Id.IsNullOrEmpty())
                {
                    _supplierRepository.Create(supplier);
                }
                else
                {
                    _supplierRepository.Update(supplier);
                }
                await _supplierRepository.Save();

                return (true, supplier, "Supplier created successfully");
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
        public async Task<(bool IsSuccess, Guid id, string ErrorMessage)> DeleteSupplier(Guid id)
        {
            try
            {

                var supplier = await _supplierRepository.GetAll(x => x.Id == id).FirstOrDefaultAsync();
                if (supplier == null)
                    return (false, id, "No record found.");
                _supplierRepository.Delete(supplier);

                return (false, id, "Record deleted successfully.");
            }
            catch (Exception e)
            {
                return (false, id, $"{e.Message}");
            }
        }


    }
}
