using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Moms.Laboratory.Core.Domain.Lab.Dto;
using Moms.Laboratory.Core.Domain.Lab.Models;

namespace Moms.Laboratory.Core.Domain.Lab.Services
{
    public interface IItemBillOfMaterialService
    {
        Task<(bool IsSuccess, IEnumerable<ItemBillOfMaterialDto>, string ErrorMessage)> LoadItemBillOfMaterials();
        Task<(bool IsSuccess, IEnumerable<ItemBillOfMaterialDto> itemBillOfMaterialDtos, string ErrorMessage)> GetItemBillOfMaterial(Guid id);
        Task<(bool IsSuccess, Guid id, string ErrorMessage)> DeleteItemBillOfMaterial(Guid id);
        Task<(bool IsSuccess, ItemBillOfMaterial itemBillOfMaterial, string ErrorMEssage)> AddItemBillOfMaterial(ItemBillOfMaterial itemBillOfMaterial);

    }
}
