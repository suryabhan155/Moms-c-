using Moms.SharedKernel.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Moms.Clinical.Core.Domain.Queue.Models
{
    public class Queue: Entity<Guid>
    {

        public Guid RoomId { get; set; }
        public Guid PatientId { get; set; }
        public DateTime QueueTime { get; set; }
        public int Priority { get; set; }
        public int Status { get; set; }

    }
}
