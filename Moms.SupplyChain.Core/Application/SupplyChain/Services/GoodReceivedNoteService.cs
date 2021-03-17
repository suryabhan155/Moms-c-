using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Moms.SharedKernel.Custom;
using Moms.SharedKernel.Interfaces.Persistence;
using Moms.SharedKernel.Response;
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
        public async Task<(bool IsSuccess, GoodReceivedNote goodReceivedNote, ResponseModel response)> AddGoodReceivedNote(GoodReceivedNote goodReceivedNote)
        {
            try
            {
                if (goodReceivedNote == null)
                    return (false, goodReceivedNote, new ResponseModel { message = "No good received note found", data =goodReceivedNote , code = HttpStatusCode.NotFound });

                if (goodReceivedNote.Id.IsNullOrEmpty())
                {
                    _goodReceivedNoteRepository.Create(goodReceivedNote);
                }
                else
                {
                    _goodReceivedNoteRepository.Update(goodReceivedNote);
                }
                await _goodReceivedNoteRepository.Save();

                return (true, goodReceivedNote, new ResponseModel { message = "Good Received Note created successfully", data = goodReceivedNote, code = HttpStatusCode.OK });
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public async Task<(bool IsSuccess, Guid id, ResponseModel response)> DeleteGoodReceivedNote(Guid id)
        {
            try
            {

                var grn = await _goodReceivedNoteRepository.GetAll(x => x.Id == id).FirstOrDefaultAsync();
                if (grn == null)
                    return (false, id, new ResponseModel { message = "No record found.", data = grn, code = HttpStatusCode.NotFound });
                grn.VoidDate = DateTime.Now;
                grn.Void = true;
                _goodReceivedNoteRepository.Update(grn);
                await _goodReceivedNoteRepository.Save();

                return (true, id, new ResponseModel { message = "Record deleted successfully.", data = grn, code = HttpStatusCode.OK });
            }
            catch (Exception e)
            {
                return (false, id, new ResponseModel { message = e.Message, data = id, code = HttpStatusCode.InternalServerError });
            }
        }

        public (bool IsSuccess, GoodReceivedNote goodReceivedNotes, ResponseModel response) GetGoodReceivedNote(Guid id)
        {
            try
            {
                var result = _goodReceivedNoteRepository.GetById(id);
                return result == null ? (false, new GoodReceivedNote(), new ResponseModel { message ="GRN Not found" , data = result, code = HttpStatusCode.NotFound }) : (true, result, new ResponseModel { message ="GRN Found" , data = result, code = HttpStatusCode.OK });
            }
            catch (Exception e)
            {
                Log.Error("Stores Load: Error occurred", e);
                return (false, new GoodReceivedNote(), new ResponseModel { message =e.Message , data = new GoodReceivedNote(), code = HttpStatusCode.InternalServerError });
            }
        }

        public async Task<(bool IsSuccess, IEnumerable<GoodReceivedNote>, ResponseModel response)> LoadGoodReceivedNotes()
        {
            try
            {
                var result =await _goodReceivedNoteRepository.GetAll(x => x.Void == false).OrderByDescending(x=>x.CreateDate).ToListAsync();

                return result.Count == 0 ? (false, new List<GoodReceivedNote>(), new ResponseModel { message = "No GRN Found", data = result, code = HttpStatusCode.NotFound }) : (true, result, new ResponseModel { message = "GRN  Found", data = result, code = HttpStatusCode.OK });
            }
            catch (Exception e)
            {
                Log.Error("Stores Load: Error occurred", e);
                return (false, new List<GoodReceivedNote>(), new ResponseModel { message = e.Message, data = new List<GoodReceivedNote>(), code = HttpStatusCode.InternalServerError });
            }
        }
    }
}
