using Moms.SharedKernel.Model;
using System;

namespace Moms.Laboratory.Core.Domain.Lab.Models
{
  public  class ItemBillOfMaterial:Entity<Guid>
    {
        public Guid ItemId { get; set; }
        public Guid BomItemId { get; set; }
        public String MeasureUnit { get; set; }
        public Double Quantity { get; set; }

    }
}
