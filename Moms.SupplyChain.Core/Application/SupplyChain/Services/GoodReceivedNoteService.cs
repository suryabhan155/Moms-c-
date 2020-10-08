using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Moms.SharedKernel.Custom;
using Moms.SupplyChain.Core.Domain.SupplyChain;
using Moms.SupplyChain.Core.Domain.SupplyChain.Models;
using Moms.SupplyChain.Core.Domain.SupplyChain.Services;
using Serilog;

namespace Moms.SupplyChain.Core.Application.SupplyChain.Services
{
    public class GoodReceivedNoteService : IGoodReceivedNoteService
    {
        private readonly IGoodReceivedNoteRepository _goodReceivedNoteRepository;

        public GoodReceivedNoteService(IGoodReceivedNoteRepository iGoodReceivedNoteRepository)
        {
            _goodReceivedNoteRepository = iGoodReceivedNoteRepository;
        }
        public async Task<(bool IsSuccess, GoodReceivedNote goodReceivedNote, string ErrorMessage)> AddGoodReceivedNote(GoodReceivedNote goodReceivedNote)
        {
            try
            {
                if (goodReceivedNote == null)
                    return (false, goodReceivedNote, "No good received note found");

                if (goodReceivedNote.Id.IsNullOrEmpty())
                {
                    _goodReceivedNoteRepository.Create(goodReceivedNote);
                }
                else
                {
                    _goodReceivedNoteRepository.Update(goodReceivedNote);
                }
                await _goodReceivedNoteRepository.Save();

                return (true, goodReceivedNote, "Good Received Note created successfully");
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public async Task<(bool IsSuccess, Guid id, string ErrorMessage)> DeleteGoodReceivedNote(Guid id)
        {
            try
            {

                var grn = await _goodReceivedNoteRepository.GetAll(x => x.Id == id).FirstOrDefaultAsync();
                if (grn == null)
                    return (false, id, "No record found.");
                _goodReceivedNoteRepository.Delete(grn);

                return (false, id, "Record deleted successfully.");
            }
            catch (Exception e)
            {
                return (false, id, $"{e.Message}");
            }
        }

        public (bool IsSuccess, GoodReceivedNote goodReceivedNotes, string ErrorMessage) GetGoodReceivedNote(Guid id)
        {
            try
            {
                var result = _goodReceivedNoteRepository.GetById(id);
                return result == null ? (false, new GoodReceivedNote(), "GRN Not found") : (true, result, "GRN Found");
            }
            catch (Exception e)
            {
                Log.Error("Stores Load: Error occurred", e);
                return (false, new GoodReceivedNote(), e.Message);
            }
        }

        public async Task<(bool IsSuccess, IEnumerable<GoodReceivedNote>, string ErrorMessage)> LoadGoodReceivedNotes()
        {
            try
            {
                var result = await _goodReceivedNoteRepository.GetAll().ToListAsync();
                return result == null ? (false, new List<GoodReceivedNote>(), "No GRN Found") : (true, result, "GRN  Found");
            }
            catch (Exception e)
            {
                Log.Error("Stores Load: Error occurred", e);
                return (false, new List<GoodReceivedNote>(), e.Message);
            }
        }
    }
}
