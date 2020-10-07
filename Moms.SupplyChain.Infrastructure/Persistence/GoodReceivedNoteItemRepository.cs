using System;
using System.Collections.Generic;
using System.Text;
using Moms.SharedKernel.Infrastructure.Persistence;
using Moms.SupplyChain.Core.Domain.SupplyChain;
using Moms.SupplyChain.Core.Domain.SupplyChain.Models;

namespace Moms.SupplyChain.Infrastructure.Persistence
{
    public class GoodReceivedNoteItemRepository:BaseRepository<GoodReceivedNoteItem, Guid>, IGoodReceivedNoteItemRepository
    {
      public  GoodReceivedNoteItemRepository(SupplyChainContext context) : base(context)
        {

        }
    }
}
