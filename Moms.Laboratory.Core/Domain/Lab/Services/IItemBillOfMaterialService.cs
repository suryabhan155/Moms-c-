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
        Task<(bool IsSuccess, IEnumerable<ItemBillOfMaterial> itemBillOfMaterialDtos, string ErrorMessage)> LoadItemBillOfMaterials();

    }
}
