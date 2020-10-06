using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Moms.RegistrationManagement.Core.Domain.Patient;
using Moms.RegistrationManagement.Core.Domain.Patient.Models;
using Moms.SharedKernel.Infrastructure.Persistence;
using Serilog;

namespace Moms.RegistrationManagement.Infrastructure.Persistence
{
    public class PatientRepository:BaseRepository<Patient,Guid>, IPatientRepository
    {
        public PatientRepository(RegistrationContext context) : base(context)
        {

        }

        public async Task<(bool IsSuccess, IEnumerable<Patient> patients, string ErrorMessage)> SearchPatient(string searchString)
        {
            try
            {
                var response = await GetAll(x => x.SearchVector.Matches(EF.Functions.ToTsQuery(searchString)))
                   // .Include(x=>x.Sex==x.LookupItems)
                   .ToListAsync();
               if (response.Count < 1)
                   return (false, new List<Patient>(), $"No patient(s) Found using Search String: {searchString}");
               return (true, response, "patient loaded successfully");
            }
            catch (Exception e)
            {
                Log.Error("$patient Search Error : {e}");
                return (false, new List<Patient>(), e.Message);
            }
        }
    }
}
