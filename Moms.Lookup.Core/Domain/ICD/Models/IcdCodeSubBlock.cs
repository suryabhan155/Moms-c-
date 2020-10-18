using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Moms.Lookup.Core.Domain.Options.Models;
using Moms.SharedKernel.Model;


namespace Moms.Lookup.Core.Domain.ICD.Models
{
    public class IcdCodeSubBlock : Entity<Guid>
    {
<<<<<<< HEAD
        public string Code { get; set; }
        public string Name { get; set; }

        public Guid IcdCodeBlockId { get; set; }
       
        public IcdCodeBlock IcdCodeBlock { get; set; }
        public ICollection<IcdCode> IcdCodes { get; set; } = new List<IcdCode>();
=======
        public Guid IcdCodeBlockId { get; set; }
        public String Code { get; set; }
        public string Name { get; set; }
>>>>>>> 1ecead17d9c0beba2667da02127c435196f41328
    }
}
