using System;
using System.Collections.Generic;
using System.Text;
using Moms.SharedKernel.Model;

namespace Moms.Laboratory.Core.Domain.Lab.Models
{
    public class LabOrderSampleResult : Entity<Guid>
    {
        public Guid LabOrderSampleId { get; set; }
        public Guid LabItemId { get; set; }
        public DateTime LabResultDate { get; set; }
        public String LabResult { get; set; }
        public String Comment { get; set; }
        public Int16 Status { get; set; }
    }
}
