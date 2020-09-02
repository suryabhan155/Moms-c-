using System;

namespace Moms.Laboratory.Core.Domain.Lab.Dto
{
    public class ItemBillOfMaterialDto
    {
        public Guid ItemId { get; set; }
        public Guid BomItemId { get; set; }
        public String MeasureUnit { get; set; }
        public Double Quantity { get; set; }

    }
}
