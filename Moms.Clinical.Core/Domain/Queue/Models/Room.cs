using Moms.SharedKernel.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Moms.Clinical.Core.Domain.Queue.Models
{
    public class Room: Entity<Guid>
    {
        public string Name { get; set; }
        public int Status { get; set; }

    }
}
