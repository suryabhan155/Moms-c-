using System;
using System.Collections.Generic;
using System.Text;
using Moms.SharedKernel.Model;

namespace Moms.SupplyChain.Core.Domain.SupplyChain.Models
{
    public class StockVoucher:Entity<Guid>
    {
        public Guid StoreId { set; get; }
        public Guid SourceStoreId { set; get; }
        public DateTime VoucherDateTime { set; get; }

        public Store Store { set; get; }

        public StockVoucher()
        {

        }
    }
}
