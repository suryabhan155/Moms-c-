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
    public class GoodReceivedNoteItemService : IGoodReceivedNoteItemService
    {

        private readonly IGoodReceivedNoteItemRepository _goodReceivedNoteItemRepository;

        public GoodReceivedNoteItemService(IGoodReceivedNoteItemRepository iGoodReceivedNoteItemRepository)
        {
            _goodReceivedNoteItemRepository = iGoodReceivedNoteItemRepository;
        }
        public async Task<(bool IsSuccess, GoodReceivedNoteItem goodReceivedNoteItem, ResponseModel response)> AddGoodReceivedNoteItems(GoodReceivedNoteItem goodReceivedNoteItem)
        {
            try
            {
                if (goodReceivedNoteItem == null)
                    return (false, goodReceivedNoteItem, new ResponseModel { message = "No GRN item found", data = goodReceivedNoteItem, code = HttpStatusCode.NotFound });

                if (goodReceivedNoteItem.Id.IsNullOrEmpty())
                {
                    _goodReceivedNoteItemRepository.Create(goodReceivedNoteItem);
                }
                else
                {
                    _goodReceivedNoteItemRepository.Update(goodReceivedNoteItem);
                }
                await _goodReceivedNoteItemRepository.Save();

                return (true, goodReceivedNoteItem, new ResponseModel { message = "GRN item created successfully", data = goodReceivedNoteItem, code = HttpStatusCode.OK });
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public async Task<(bool IsSuccess, Guid id, ResponseModel response)> DeleteGoodReceivedNoteItems(Guid id)
        {
            try
            {

                var grn = await _goodReceivedNoteItemRepository.GetAll(x => x.Id == id).FirstOrDefaultAsync();
                if (grn == null)
                    return (false, id, new ResponseModel { message = "No record found.", data = grn, code = HttpStatusCode.NotFound });
                grn.VoidDate = DateTime.Now;
                grn.Void = true;
                _goodReceivedNoteItemRepository.Update(grn);
                await _goodReceivedNoteItemRepository.Save();

                return (true, id, new ResponseModel { message = "Record deleted successfully.", data = grn, code = HttpStatusCode.OK });
            }
            catch (Exception e)
            {
                return (false, id, new ResponseModel { message = e.Message, data = id, code = HttpStatusCode.InternalServerError });
            }
        }

        public (bool IsSuccess, GoodReceivedNoteItem goodReceivedNoteItems, ResponseModel response) GetGoodReceivedNoteItems(Guid id)
        {
            try
            {
                var goodReceivedNoteItem = _goodReceivedNoteItemRepository.GetById(id);
                if (goodReceivedNoteItem == null)
                    return (false, null, new ResponseModel { message ="GRN item not found." , data = goodReceivedNoteItem, code = HttpStatusCode.NotFound });
                return (true, goodReceivedNoteItem, new ResponseModel { message = "GRN items loaded successfully", data = goodReceivedNoteItem, code = HttpStatusCode.OK });
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return (false, null, new ResponseModel { message = e.Message, data =null, code = HttpStatusCode.InternalServerError });
            }
        }

        public async Task<(bool IsSuccess, IEnumerable<GoodReceivedNoteItem>, ResponseModel response)> LoadGoodReceivedNoteItems()
        {
            try
            {
                var result =await _goodReceivedNoteItemRepository.GetAll(x => x.Void == false).OrderByDescending(x => x.CreateDate).ToListAsync();
                if (result.Count == 0)
                    return (false, new List<GoodReceivedNoteItem>(), new ResponseModel { message = "Goods Received Note not Found", data = result, code = HttpStatusCode.NotFound } );
                return (true, result, new ResponseModel { message = "Records Found", data =result , code = HttpStatusCode.OK } );
            }
            catch (Exception e)
            {
                Log.Error("Stores Load: Error occurred", e);
                IEnumerable<GoodReceivedNoteItem> grn = new List<GoodReceivedNoteItem>();
                return (false, grn, new ResponseModel { message = e.Message, data = grn, code = HttpStatusCode.InternalServerError } );
            }
        }
    }
}
