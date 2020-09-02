using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Moms.Laboratory.Core.Domain.Lab;
using Moms.Laboratory.Core.Domain.Lab.Dto;
using Moms.Laboratory.Core.Domain.Lab.Models;
using Moms.Laboratory.Core.Domain.Lab.Services;
using Serilog;

namespace Moms.Laboratory.Core.Application.Lab.Services
{
    public class ItemBillOfMaterialService: IItemBillOfMaterialService
    {
        private readonly IMapper _mapper;
        private readonly IItemBillOfMaterialRepository _itemBillOfMaterialRepository;

        public ItemBillOfMaterialService(IMapper iMapper, IItemBillOfMaterialRepository itemBillOfMaterialRepository)
        {
            _mapper = iMapper;
            _itemBillOfMaterialRepository = itemBillOfMaterialRepository;
        }


        public async Task<(bool IsSuccess, IEnumerable<ItemBillOfMaterial> itemBillOfMaterialDtos, string ErrorMessage)> LoadItemBillOfMaterials()
        {
            IEnumerable<ItemBillOfMaterialDto> deathDtos = new List<ItemBillOfMaterialDto>();
            try
            {
                var death = await _itemBillOfMaterialRepository.GetAll().ToListAsync();
                if (death == null)
                    return (false, deathDtos, "No records found");
                return (true, _mapper.Map<List<ItemBillOfMaterialDto>>(death), "death data loaded successfully");
            }
            catch (Exception e)
            {
                Log.Error("Error loading patient data");
                return (false, deathDtos, $"{e.Message}");
            }
        }


    }
}
