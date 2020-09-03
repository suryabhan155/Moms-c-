using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Moms.Laboratory.Core.Domain.Lab;
using Moms.Laboratory.Core.Domain.Lab.Models;
using Moms.Laboratory.Core.Domain.Lab.Services;
using Moms.SharedKernel.Custom;

namespace Moms.Laboratory.Core.Application.Lab.Services
{
    public class LabOrderService : ILabOrderService
    {
        public readonly IMapper _IMapper;
        public readonly ILabOrderRepository _LabOrderRepository;

        public LabOrderService(IMapper iMapper, ILabOrderRepository labSubItemRepository)
        {
            _IMapper = iMapper;
            _LabOrderRepository = labSubItemRepository;
        }

        public async Task<(bool IsSuccess, IEnumerable<LabOrder>, string ErrorMessage)> LoadLabOrders()
        {
            IEnumerable<LabOrder> lab = new List<LabOrder>();
            try
            {
                var labOrders = await _LabOrderRepository.GetAll().ToListAsync();
                if (labOrders == null)
                    return (false, lab, "No record found.");
                return (true, _IMapper.Map<List<LabOrder>>(labOrders), "Lab orders loaded successfully.");
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public async Task<(bool IsSuccess, IEnumerable<LabOrder> labOrders, string ErrorMessage)> GetLabOrder(Guid id)
        {
            IEnumerable<LabOrder> lab = new List<LabOrder>();
            try
            {
                var labOrder = await _LabOrderRepository.GetAll(x => x.Id == id).ToListAsync();
                if (labOrder == null)
                    return (false, lab, "Lab order not found.");
                return (true, _IMapper.Map<List<LabOrder>>(labOrder), "Lab order loaded successfully");

            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return (false, lab, $"{e.Message}");
            }
        }

        public async Task<(bool IsSuccess, LabOrder labOrder, string ErrorMEssage)> AddLabOrder(LabOrder labOrder)
        {
            try
            {
                if (labOrder == null)
                    return (false, labOrder, "No lab order found");
                if(labOrder.ItemID.IsNullOrEmpty())
                    _LabOrderRepository.Create(labOrder);
                _LabOrderRepository.Update(labOrder);
                await _LabOrderRepository.Save();

                return (true, labOrder, "Lab order created successfully");
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public async Task<(bool IsSuccess, Guid id, string ErrorMessage)> DeleteLabOrder(Guid id)
        {
            try
            {

                var labOrder = await _LabOrderRepository.GetAll(x => x.Id == id).FirstOrDefaultAsync();
                if (labOrder == null)
                    return (false, id, "No record found.");
                _LabOrderRepository.Delete(labOrder);

                return (false, id, "Record deleted successfully.");
            }
            catch (Exception e)
            {
                return (false, id, $"{e.Message}");
            }
        }
    }
}
