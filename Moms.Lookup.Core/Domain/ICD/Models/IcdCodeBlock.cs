using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Moms.Lookup.Core.Domain.Options.Models;
using Moms.SharedKernel.Model;


namespace Moms.Lookup.Core.Domain.ICD.Models
{
    public class IcdCodeBlock : Entity<Guid>
    {
<<<<<<< HEAD
        public string Code { get; set; }
        public string Name { get; set; }
        public Guid IcdCodeChapterId { get; set; }
      
        public IcdCodeChapter IcdCodeChapter { get; set; }


        public ICollection<IcdCodeSubBlock> IcdCodeSubBlocks { get; set; } = new List<IcdCodeSubBlock>();
=======
        public Guid IcdCodeChapterId { get; set; }
        public String Code { get; set; }
        public string Name { get; set; }
>>>>>>> 1ecead17d9c0beba2667da02127c435196f41328
    }
}
