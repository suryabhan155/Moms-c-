using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Moms.Lookup.Core.Application.Options.Response;
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

        public async Task<(bool IsSuccess, IEnumerable<IcdCode> icdCode, ResponseModel model)> SearchDiagnosis(String icdCode)
        {
            IEnumerable<IcdCode> lab = new List<IcdCode>();
            try
            {
                var icdCodes = await _icdCodeRepository.GetAll(x => x.Name.Contains(icdCode)).ToListAsync();
                if (icdCodes == null)
                    return (false, lab, new ResponseModel { message = "Diagnosis not found.", data = lab, code = HttpStatusCode.NotFound });
                return (true, icdCodes, new ResponseModel { message = "Diagnosis found successfully", data = lab, code = HttpStatusCode.OK });
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return (false, lab, new ResponseModel { message = $"{e.Message}", data = lab, code = HttpStatusCode.InternalServerError });
            }
        }

        public async Task<(bool IsSuccess, IEnumerable<IcdCode> icdCodes, ResponseModel model)> DiagnosisAll()
        {
            IEnumerable<IcdCode> _icdCodes = new List<IcdCode>();
            try
            {
                var icdCodes = await _icdCodeRepository.GetAll().ToListAsync();
                if (icdCodes == null)
                    return (false, (List<IcdCode>) null, new ResponseModel { message = "No diagnosis found", data = icdCodes, code = HttpStatusCode.NotFound });
                return (true, icdCodes, new ResponseModel { message = "Diagnosis List Found", data = icdCodes, code = HttpStatusCode.OK });
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return (false, _icdCodes, new ResponseModel { message = $"{e.Message}", data = _icdCodes, code = HttpStatusCode.InternalServerError });
            }
        }
    }
}
