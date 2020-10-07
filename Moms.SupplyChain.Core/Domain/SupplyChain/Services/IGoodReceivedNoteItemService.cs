using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Moms.SupplyChain.Core.Domain.SupplyChain.Models;

namespace Moms.SupplyChain.Core.Domain.SupplyChain.Services
{
    public interface IGoodReceivedNoteItemService
    {
        Task<(bool IsSuccess, IEnumerable<GoodReceivedNoteItem>, String ErrorMessage)> LoadGoodReceivedNoteItems();
        (bool IsSuccess, GoodReceivedNoteItem goodReceivedNoteItems, String ErrorMessage) GetGoodReceivedNoteItems(Guid id);
        Task<(bool IsSuccess, Guid id, String ErrorMessage)> DeleteGoodReceivedNoteItems(Guid id);
        Task<(bool IsSuccess, GoodReceivedNoteItem goodReceivedNoteItem, String ErrorMessage)> AddGoodReceivedNoteItems(GoodReceivedNoteItem goodReceivedNoteItem);
        
    }
}
