using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Moms.Laboratory.Core.Domain.Lab;
using Moms.Laboratory.Core.Domain.Lab.Models;
using Moms.Laboratory.Core.Domain.Lab.Services;
using Moms.SharedKernel.Custom;
using Serilog;

namespace Moms.Laboratory.Core.Application.Lab.Services
{
    public class LabSubItemService : ILabSubItemService
    {
        public readonly IMapper _IMapper;
        public readonly ILabSubItemRepository _LabSubItemRepository;

        public LabSubItemService(IMapper iMapper, ILabSubItemRepository itemRepository)
        {
            _IMapper = iMapper;
            _LabSubItemRepository = itemRepository;
        }

        public async Task<(bool IsSuccess, IEnumerable<LabSubItem> , string ErrorMessage)> LoadLabSubItems()
        {
            IEnumerable<LabSubItem> labSub = new List<LabSubItem>();
            try
            {
                var labSubItem = await _LabSubItemRepository.GetAll().ToListAsync();
                if (labSubItem == null)
                    return (false, labSub, "No records found");
                return (true, _IMapper.Map<List<LabSubItem>>(labSubItem), "Lab sub items loaded successfully.");
            }
            catch (Exception e)
            {

                Log.Error("Error loading lab sub items");
                return (false, labSub, $"{e.Message}");
            }
        }

        public async Task<(bool IsSuccess, IEnumerable<LabSubItem> labSubItems, string ErrorMessage)> GetLabSubItem(Guid id)
        {
            IEnumerable<LabSubItem> labSub = new List<LabSubItem>();
            try
            {
                var labItem = await _LabSubItemRepository.GetAll(x => x.ItemId == id).ToListAsync();
                if (labItem == null)
                    return (false, labSub, "No records found.");
                return (true, _IMapper.Map<List<LabSubItem>>(labItem), "Lab sub items loaded successfully.");
                
            }
            catch (Exception e)
            {
                Log.Error("Error loading the lab sub items.");
                return (false, labSub, $"{e.Message}");
            }
        }

        public async Task<(bool IsSuccess, LabSubItem labSubItem, string ErrorMEssage)> AddLabSubItem(LabSubItem labSubItem)
        {
            IEnumerable<LabSubItem> labSub = new List<LabSubItem>();
            try
            {
                if (labSubItem == null)
                    return (false, null, "No record found.");
                if(labSubItem.ItemId.IsNullOrEmpty())
                    _LabSubItemRepository.Create(labSubItem);
                _LabSubItemRepository.Update(labSubItem);
                await _LabSubItemRepository.Save();
                return (true, labSubItem, "Lab sub item saved successfully.");
            }
            catch (Exception e)
            {
                throw;
            }
        }

        public async Task<(bool IsSuccess, Guid id, string ErrorMessage)> DeleteLabSubItem(Guid id)
        {
            try
            {
                var labSubItem = await _LabSubItemRepository.GetAll(x=>x.ItemId == id).FirstOrDefaultAsync();
                if (labSubItem == null)
                    return (false, id, "No record found.");
                _LabSubItemRepository.Delete(labSubItem);

                return (false, id, "Record deleted successfully.");
            }
            catch (Exception e)
            {
                Log.Error("Error deleting lab sub items.");
                return (false, id, $"{e.Message}");

            }
        }
    }
}
