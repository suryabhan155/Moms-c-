using System;
using System.Collections.Generic;
using System.Text;
using Moms.SharedKernel.Model;

namespace Moms.SupplyChain.Core.Domain.SupplyChain.Models
{
    public class PurchaseOrder : Entity<Guid>
    {
        public Guid StoreId { set; get; }
        public Guid SupplierId { set; get; }

        public String OrderNumber { set; get; }
        public DateTime OrderDateTime { set; get; }
        public int Status { set; get; }

        public Store Store { set; get; }
        public Supplier Supplier { set; get; }
    }
}
