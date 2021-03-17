using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using Moms.RegistrationManagement.Core.Domain.Patient;
using Moms.RegistrationManagement.Core.Domain.Patient.Models;
using Moms.SharedKernel.Infrastructure.Persistence;
using Serilog;

namespace Moms.RegistrationManagement.Infrastructure.Persistence
{
    public class PatientGridRepository:BaseRepository<PatientGrid,Guid>, IPatientGridRepository
    {
        public PatientGridRepository(RegistrationContext context) : base(context)
        {
        }

        public async Task<(bool IsSuccess, IEnumerable<PatientGrid> patientGrids, string ErrorMessage)> SearchPatient(string searchString)
        {
            try
            {
                var results = await GetAll(x => x.SearchVector.Matches(EF.Functions.ToTsQuery(searchString)))
                    .ToListAsync();
                if(results==null)
                    return (false, new List<PatientGrid>(), $"No patient(s) Found using Search String: {searchString}");
                return (true, results, "Patient(s) Found");
            }
            catch (Exception e)
            {
                Log.Error("$patient Search Error : {e}");
                return (false, new List<PatientGrid>(), e.Message);
            }
        }

        public async Task<(bool IsSuccess, IEnumerable<PatientGrid> patientGrids, string ErrorMessage)> AllPatients()
        {
            try
            {
                var result = await GetAll().ToListAsync();
                if (result == null)
                    return (false, new List<PatientGrid>(), "No Patient Found");
                return (true, result, $"({result.Count}) Found in the database");
            }
            catch (Exception e)
            {
                Log.Error("$patient Search Error : {e}");
                return (false, new List<PatientGrid>(), e.Message);
            }
        }
    }
}
