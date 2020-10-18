using System;
using System.Text.Json.Serialization;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Moms.Lookup.Core.Domain.Options.Models;
using Moms.SharedKernel.Model;

namespace Moms.Lookup.Core.Domain.ICD.Models
{
    public class IcdCode : Entity<Guid>
    {
<<<<<<< HEAD
        public string Code { get; set; }
        public string Name { get; set; }

        public Guid IcdCodeSubBlockId { get; set; }

        public IcdCodeSubBlock IcdCodeSubBlock { get; set; }
=======
        public Guid IcdCodeSubBlockId { get; set; }
        public String Code { get; set; }
        public string Name { get; set; }

        //public IcdCodeSubBlock IcdCodeSubBlock { get; set; }
>>>>>>> 1ecead17d9c0beba2667da02127c435196f41328
    }
}
