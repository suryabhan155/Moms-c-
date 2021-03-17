using System;
using System.Collections.Generic;
using System.Text;
using Moms.SharedKernel.Model;

namespace Moms.SupplyChain.Core.Domain.SupplyChain.Models
{
    public class Supplier : Entity<Guid>
    {
        public String Name { set; get; }
        public int Status { set; get; }

        public Supplier()
        {

        }
    }
}
