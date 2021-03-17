using System;
using System.Collections.Generic;
using System.Text;
using Moms.SharedKernel.Model;

namespace Moms.SupplyChain.Core.Domain.SupplyChain.Models
{
    public class GoodReceivedNoteItem:Entity<Guid>
    {
        public GoodReceivedNoteItem()
        {

        }
        public Guid GoodReceivedNoteId { set; get; }
        public Guid ItemId { set; get; }
        public String BatchNumber { set; get; }
        public decimal ReceivedQuantity { set; get; }
        //public DateTime ReceiveDateTime { set; get; }
        public DateTime ExpiryDateTime { set; get; }
        public decimal UnitPrice { set; get; }
        //public decimal UnitPrice12 { set; get; }
        //public GoodReceivedNote GoodReceivedNote { set; get; }
    }
}
