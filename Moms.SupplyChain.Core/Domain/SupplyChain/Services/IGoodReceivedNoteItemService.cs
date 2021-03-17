using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Moms.SharedKernel.Response;
using Moms.SupplyChain.Core.Domain.SupplyChain.Models;

namespace Moms.SupplyChain.Core.Domain.SupplyChain.Services
{
    public interface IGoodReceivedNoteItemService
    {
        Task<(bool IsSuccess, IEnumerable<GoodReceivedNoteItem>, ResponseModel response)> LoadGoodReceivedNoteItems();
        (bool IsSuccess, GoodReceivedNoteItem goodReceivedNoteItems, ResponseModel response) GetGoodReceivedNoteItems(Guid id);
        Task<(bool IsSuccess, Guid id, ResponseModel response)> DeleteGoodReceivedNoteItems(Guid id);
        Task<(bool IsSuccess, GoodReceivedNoteItem goodReceivedNoteItem, ResponseModel response)> AddGoodReceivedNoteItems(GoodReceivedNoteItem goodReceivedNoteItem);
        
    }
}
