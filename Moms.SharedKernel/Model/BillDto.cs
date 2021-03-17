using System;
using System.Collections.Generic;
using System.Text;

namespace Moms.SharedKernel.Model
{

    public class BillDto
    {
        public Guid PatientId { get; set; }

        public DateTime BillDate { get; set; }

        public Guid ItemId { get; set; }

        public int Qty { get; set; }
    }
}
