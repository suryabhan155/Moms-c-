using System;
using System.Collections.Generic;
using System.Text;
using Moms.SharedKernel.Model;

namespace Moms.Laboratory.Core.Domain.Lab.Models
{
    public class LabOrder : Entity<Guid>
    {
        public Guid PatientID { get; set; }
        public Guid ItemID { get; set; }
        public DateTime OrderDateTime { get; set; }
    }
}
