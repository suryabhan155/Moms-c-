using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Moms.Lookup.Core.Domain.ICD;
using Moms.Lookup.Core.Domain.ICD.Models;
using Moms.Lookup.Core.Domain.ICD.Services;

namespace Moms.Lookup.Core.Application.ICD.Services
{
    public class IcdCodeService : IIcdCodeService
    {
        private readonly IIcdCodeRepository _icdCodeRepository;

        public IcdCodeService(IIcdCodeRepository icdCodeRepository)
        {
            _icdCodeRepository = icdCodeRepository;
        }

        public async Task<(bool IsSuccess, IEnumerable<IcdCode> icdCode, string ErrorMessage)> SearchDiagnosis(String icdCode)
        {
            IEnumerable<IcdCode> lab = new List<IcdCode>();
            try
            {
                var icdCodes = await _icdCodeRepository.GetAll(x => x.Name.Contains(icdCode)).ToListAsync();
                if (icdCodes == null)
                    return (false, lab, "Diagnosis not found.");
                return (true, icdCodes, "Diagnosis found successfully");
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return (false, lab, $"{e.Message}");
            }
        }

        public async Task<(bool IsSuccess, IEnumerable<IcdCode> icdCodes, string ErrorMessage)> DiagnosisAll()
        {
            IEnumerable<IcdCode> _icdCodes = new List<IcdCode>();
            try
            {
                var icdCodes = await _icdCodeRepository.GetAll().ToListAsync();
                if (icdCodes == null)
                    return (false, (List<IcdCode>) null, "No diagnosis found");
                return (true, icdCodes, "Diagnosis List Found");
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return (false, _icdCodes, $"{e.Message}");
            }
        }
    }
}
