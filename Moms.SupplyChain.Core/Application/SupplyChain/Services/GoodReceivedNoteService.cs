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
        private readonly IMapper _mapper;
        private readonly IGoodReceivedNoteRepository _goodReceivedNoteRepository;

        public GoodReceivedNoteService(IGoodReceivedNoteRepository iGoodReceivedNoteRepository, IMapper iMapper)
        {
            _mapper = iMapper;
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
                var grn = _goodReceivedNoteRepository.GetById(id);
                if (grn == null)
                    return (false, null, "GRN not found.");
                return (true, grn, "GRN loaded successfully");
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return (false, null, $"{e.Message}");
            }
        }

        public async Task<(bool IsSuccess, IEnumerable<GoodReceivedNote>, string ErrorMessage)> LoadGoodReceivedNotes()
        {
            try
            {
                var goodReceivedNotes = await _goodReceivedNoteRepository.GetAll().ToListAsync();

                return (true, _mapper.Map<List<GoodReceivedNote>>(goodReceivedNotes), "GRN Loaded Successfully");
            }
            catch (Exception e)
            {
                Log.Error("Stores Load: Error occurred", e);
                IEnumerable<GoodReceivedNote> grn = new List<GoodReceivedNote>();
                return (false, grn, e.Message);
            }
        }
    }
}
