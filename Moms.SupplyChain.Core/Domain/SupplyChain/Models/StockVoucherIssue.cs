using System;
using System.Collections.Generic;
using System.Text;
using Moms.SharedKernel.Model;

namespace Moms.SupplyChain.Core.Domain.SupplyChain.Models
{
    public class StockVoucherIssue : Entity<Guid>
    {
        public Guid StockVoucherId { set; get; }
        public DateTime IssueDate { set; get; }
        public Guid GoodReceivedNoteItemId { set; get; }
        public decimal IssuedQuantity { get; set; }
        public StockVoucherIssue()
        {

        }
    }
}
