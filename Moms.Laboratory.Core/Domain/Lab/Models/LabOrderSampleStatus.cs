using System;
using System.Collections.Generic;
using System.Text;
using Moms.SharedKernel.Model;

namespace Moms.Laboratory.Core.Domain.Lab.Models
{
    public class LabOrderSampleStatus : Entity<Guid>
    {
        public Guid LabOrderSampleId { get; set; }
        public DateTime StatusDateTime { get; set; }
        public Int16 Status { get; set; }
        public String Comment { get; set; }
    }
}
