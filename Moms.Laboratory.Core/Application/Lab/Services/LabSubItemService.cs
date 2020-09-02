using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Moms.Laboratory.Core.Domain.Lab;
using Moms.Laboratory.Core.Domain.Lab.Models;
using Moms.Laboratory.Core.Domain.Lab.Services;
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

        public Task<(bool IsSuccess, IEnumerable<LabSubItem> labSubItems, string ErrorMessage)> GetLabSubItem(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<(bool IsSuccess, LabSubItem labSubItem, string ErrorMEssage)> AddLabSubItem(LabSubItem labSubItem)
        {
            throw new NotImplementedException();
        }

        public Task<(bool IsSuccess, Guid id, string ErrorMessage)> DeleteLabSubItem(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}
