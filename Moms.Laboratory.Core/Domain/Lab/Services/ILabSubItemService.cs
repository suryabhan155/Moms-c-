using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Moms.Laboratory.Core.Domain.Lab.Models;

namespace Moms.Laboratory.Core.Domain.Lab.Services
{
    public interface ILabSubItemService
    {

        Task<(bool IsSuccess, IEnumerable<LabSubItem>, string ErrorMessage)> LoadLabSubItems();
        Task<(bool IsSuccess, IEnumerable<LabSubItem> labSubItems, string ErrorMessage)> GetLabSubItem(Guid id);
        Task<(bool IsSuccess, Guid id, string ErrorMessage)> DeleteLabSubItem(Guid id);
        Task<(bool IsSuccess, LabSubItem labSubItem, string ErrorMEssage)> AddLabSubItem(LabSubItem labSubItem);
    }
}
