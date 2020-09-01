using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Moms.Laboratory.Core.Domain.Lab.Dto;

namespace Moms.Laboratory.Core.Domain.Lab.Services
{
    class IItemBillOfMaterialService
    {
        Task<(bool IsSuccess, IEnumerable<ItemBillOfMaterialDto>, string ErrorMessage)> LoadItemBillOfMaterials();

    }
}
