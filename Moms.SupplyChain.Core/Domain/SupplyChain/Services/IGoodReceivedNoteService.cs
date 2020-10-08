using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Moms.SupplyChain.Core.Domain.SupplyChain.Models;

namespace Moms.SupplyChain.Core.Domain.SupplyChain.Services
{
    public interface IGoodReceivedNoteService
    {
        Task<(bool IsSuccess, IEnumerable<GoodReceivedNote>, String ErrorMessage)> LoadGoodReceivedNotes();
        (bool IsSuccess, GoodReceivedNote goodReceivedNotes, String ErrorMessage) GetGoodReceivedNote(Guid id);
        Task<(bool IsSuccess, Guid id, String ErrorMessage)> DeleteGoodReceivedNote(Guid id);
        Task<(bool IsSuccess, GoodReceivedNote goodReceivedNote, String ErrorMessage)> AddGoodReceivedNote(GoodReceivedNote goodReceivedNote);
    }
}
