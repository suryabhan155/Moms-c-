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
using Moms.SharedKernel.Custom;
using Serilog;

namespace Moms.Laboratory.Core.Application.Lab.Services
{
    public class ItemBillOfMaterialService : IItemBillOfMaterialService
    {
        private readonly IMapper _mapper;
        private readonly IItemBillOfMaterialRepository _itemBillOfMaterialRepository;

        public ItemBillOfMaterialService(IMapper iMapper, IItemBillOfMaterialRepository itemBillOfMaterialRepository)
        {
            _mapper = iMapper;
            _itemBillOfMaterialRepository = itemBillOfMaterialRepository;
        }
        

        public async Task<(bool IsSuccess, IEnumerable<ItemBillOfMaterialDto>, string ErrorMessage)> LoadItemBillOfMaterials()
        {
            IEnumerable<ItemBillOfMaterialDto> itemBillOfMaterialDtos = new List<ItemBillOfMaterialDto>();
            try
            {
                var item = await _itemBillOfMaterialRepository.GetAll().ToListAsync();
                if (item == null)
                    return (false, itemBillOfMaterialDtos, "No records found");
                return (true, _mapper.Map<List<ItemBillOfMaterialDto>>(itemBillOfMaterialDtos), "Item BoM loaded successfully");
            }
            catch (Exception e)
            {
                Log.Error("Error loading patient data");
                return (false, itemBillOfMaterialDtos, $"{e.Message}");
            }
        }

        
         public async Task<(bool IsSuccess, IEnumerable<ItemBillOfMaterialDto> itemBillOfMaterialDtos, string ErrorMessage)> GetItemBillOfMaterial(Guid id)
        {
            IEnumerable<ItemBillOfMaterialDto> itemBoM = new List<ItemBillOfMaterialDto>();
            try
            {
                var item = await _itemBillOfMaterialRepository.GetAll(x => x.ItemId == id).ToListAsync();
                if (item == null)
                    return (false, itemBoM, "Item BoM NOT found");
                return (true, _mapper.Map<List<ItemBillOfMaterialDto>>(item), "Item BoM found");
            }
            catch (Exception e)
            {
                Log.Error("Error loading item BoM");
                return (false, itemBoM, $"{e.Message}");
            }
        }

        public async Task<(bool IsSuccess, Guid id, string ErrorMessage)> DeleteItemBillOfMaterial(Guid id)
        {
            try
            {
                var death = await _itemBillOfMaterialRepository.GetAll(x => x.Id == id).FirstOrDefaultAsync();
                if (death == null)
                    return (true, id, "No item BoM to delete");
                _itemBillOfMaterialRepository.Delete(death);
                return (true, id, $"Item BOM deleted successfully{id}");
            }
            catch (Exception e)
            {
                Log.Error("Error deleting item bill of material");
                return (false, id, $"{e.Message}");
            }
        }

        public async Task<(bool IsSuccess, ItemBillOfMaterial itemBillOfMaterial, string ErrorMEssage)> AddItemBillOfMaterial(ItemBillOfMaterial itemBillOfMaterial)
        {
            //ItemBillOfMaterial itemBill = new ItemBillOfMaterial();
            try
            {
                if (itemBillOfMaterial == null)
                    return (false, null, "empty payload found");
                if (itemBillOfMaterial.ItemId.IsNullOrEmpty())
                    _itemBillOfMaterialRepository.Create(itemBillOfMaterial);
                _itemBillOfMaterialRepository.Update(itemBillOfMaterial);
                await _itemBillOfMaterialRepository.Save();
                return (true, itemBillOfMaterial, "Item BoM set successfully");
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }


    }
}
