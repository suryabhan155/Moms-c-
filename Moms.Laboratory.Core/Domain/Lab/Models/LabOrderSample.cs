using System;
using System.Collections.Generic;
using System.Text;
using Moms.SharedKernel.Model;

namespace Moms.Laboratory.Core.Domain.Lab.Models
{
    public class LabOrderSample : Entity<Guid>
    {
        public Guid LabOrderId { get; set; }
        public String LabSampleName { get; set; }
        public DateTime DateSampleCollected { get; set; }
        public DateTime TimeSampleCollected { get; set; }
        public String SampleCode { get; set; }
    }
}
