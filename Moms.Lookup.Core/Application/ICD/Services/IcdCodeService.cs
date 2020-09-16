using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Moms.Lookup.Core.Domain.ICD;
using Moms.Lookup.Core.Domain.ICD.Models;
using Moms.Lookup.Core.Domain.ICD.Services;
using Moms.RegistrationManagement.Core.Domain.Facilities;
using Moms.RegistrationManagement.Core.Domain.Facilities.Dto;
using Moms.RegistrationManagement.Core.Domain.Facilities.Models;
using Serilog;

namespace Moms.Lookup.Core.Application.ICD.Services
{
    public class IcdCodeService : IIcdCodeService
    {
        private readonly IMapper _mapper;
        private readonly IIcdCodeRepository _icdCodeRepository;

        public IcdCodeService(IMapper mapper, IIcdCodeRepository icdCodeRepository)
        {
            _mapper = mapper;
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
                return (true, _mapper.Map<List<IcdCode>>(icdCodes), "Diagnosis found successfully");

            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return (false, lab, $"{e.Message}");
            }
        }
    }
}
