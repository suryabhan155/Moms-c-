using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Moms.SharedKernel.Response;
using Moms.SupplyChain.Core.Domain.SupplyChain.Models;

namespace Moms.SupplyChain.Core.Domain.SupplyChain.Services
{
    public interface IGoodReceivedNoteService
    {
        Task<(bool IsSuccess, IEnumerable<GoodReceivedNote>, ResponseModel response)> LoadGoodReceivedNotes();
        (bool IsSuccess, GoodReceivedNote goodReceivedNotes, ResponseModel response) GetGoodReceivedNote(Guid id);
        Task<(bool IsSuccess, Guid id, ResponseModel response)> DeleteGoodReceivedNote(Guid id);
        Task<(bool IsSuccess, GoodReceivedNote goodReceivedNote, ResponseModel response)> AddGoodReceivedNote(GoodReceivedNote goodReceivedNote);
    }
}
