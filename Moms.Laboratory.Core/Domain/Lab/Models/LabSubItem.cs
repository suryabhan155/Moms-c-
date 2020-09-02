using System;
using System.Collections.Generic;
using System.Text;
using Moms.SharedKernel.Model;

namespace Moms.Laboratory.Core.Domain.Lab.Models
{
    public class LabSubItem:Entity<Guid>
    {
        public Guid ItemId { get; set; }
        public Guid SubItemId { get; set; }

    }
}
