using System;
using System.Collections.Generic;
using System.Text;
using Moms.SharedKernel.Model;

namespace Moms.SupplyChain.Core.Domain.SupplyChain.Models
{
    public class Store : Entity<Guid>
    {
        public String Name { set; get; }
        public String Category { set; get; }
        public int status { set; get; }

        public Store()
        {

        }
    }
}
