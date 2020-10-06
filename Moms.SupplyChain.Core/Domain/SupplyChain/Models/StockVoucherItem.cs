using System;
using System.Collections.Generic;
using System.Text;
using Moms.SharedKernel.Model;

namespace Moms.SupplyChain.Core.Domain.SupplyChain.Models
{
    public class StockVoucherItem:Entity<Guid>
    {
        public Guid StockVoucherId { set; get; }
        public Guid ItemId { set; get; }
        public decimal VoucherQuantity { set; get; }

        public Guid? GoodReceivedNoteItemId { set; get; }
        public decimal? IssuedQuantity { set; get; }
        public DateTime? IssueDate { set; get; }

        public StockVoucher StockVoucher { set; get; }
        public GoodReceivedNoteItem GoodReceivedNoteItem { set; get; }


    }
}
