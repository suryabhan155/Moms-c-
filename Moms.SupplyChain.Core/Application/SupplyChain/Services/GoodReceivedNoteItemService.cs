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
    public class GoodReceivedNoteItemService : IGoodReceivedNoteItemService
    {
        private readonly IMapper _mapper;
        private readonly IGoodReceivedNoteItemRepository _goodReceivedNoteItemRepository;

        public GoodReceivedNoteItemService(IGoodReceivedNoteItemRepository iGoodReceivedNoteItemRepository, IMapper iMapper)
        {
            _mapper = iMapper;
            _goodReceivedNoteItemRepository = iGoodReceivedNoteItemRepository;
        }
        public async Task<(bool IsSuccess, GoodReceivedNoteItem goodReceivedNoteItem, string ErrorMessage)> AddGoodReceivedNoteItems(GoodReceivedNoteItem goodReceivedNoteItem)
        {
            try
            {
                if (goodReceivedNoteItem == null)
                    return (false, goodReceivedNoteItem, "No GRN item found");

                if (goodReceivedNoteItem.Id.IsNullOrEmpty())
                {
                    _goodReceivedNoteItemRepository.Create(goodReceivedNoteItem);
                }
                else
                {
                    _goodReceivedNoteItemRepository.Update(goodReceivedNoteItem);
                }
                await _goodReceivedNoteItemRepository.Save();

                return (true, goodReceivedNoteItem, "GRN item created successfully");
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public async Task<(bool IsSuccess, Guid id, string ErrorMessage)> DeleteGoodReceivedNoteItems(Guid id)
        {
            try
            {

                var grn = await _goodReceivedNoteItemRepository.GetAll(x => x.Id == id).FirstOrDefaultAsync();
                if (grn == null)
                    return (false, id, "No record found.");
                _goodReceivedNoteItemRepository.Delete(grn);

                return (false, id, "Record deleted successfully.");
            }
            catch (Exception e)
            {
                return (false, id, $"{e.Message}");
            }
        }

        public (bool IsSuccess, GoodReceivedNoteItem goodReceivedNoteItems, string ErrorMessage) GetGoodReceivedNoteItems(Guid id)
        {
            try
            {
                var goodReceivedNoteItem = _goodReceivedNoteItemRepository.GetById(id);
                if (goodReceivedNoteItem == null)
                    return (false, null, "GRN item not found.");
                return (true, goodReceivedNoteItem, "GRN items loaded successfully");
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return (false, null, $"{e.Message}");
            }
        }

        public async Task<(bool IsSuccess, IEnumerable<GoodReceivedNoteItem>, string ErrorMessage)> LoadGoodReceivedNoteItems()
        {
            try
            {
                var grn = await _goodReceivedNoteItemRepository.GetAll().ToListAsync();

                return (true, _mapper.Map<List<GoodReceivedNoteItem>>(grn), "GRN items Loaded Successfully");
            }
            catch (Exception e)
            {
                Log.Error("Stores Load: Error occurred", e);
                IEnumerable<GoodReceivedNoteItem> grn = new List<GoodReceivedNoteItem>();
                return (false, grn, e.Message);
            }
        }
    }
}
