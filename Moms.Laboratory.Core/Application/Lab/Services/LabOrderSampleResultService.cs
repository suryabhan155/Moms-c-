using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Moms.Laboratory.Core.Domain.Lab;
using Moms.Laboratory.Core.Domain.Lab.Models;
using Moms.Laboratory.Core.Domain.Lab.Services;
using Moms.SharedKernel.Custom;

namespace Moms.Laboratory.Core.Application.Lab.Services
{
    public class LabOrderSampleResultService: ILabOrderSampleResultService
    {
        public readonly IMapper _IMapper;
        public readonly ILabOrderSampleResultRepository _LabOrderSampleResultRepository;

        public LabOrderSampleResultService(IMapper iMapper, ILabOrderSampleResultRepository labOrderSampleResultRepository)
        {
            _IMapper = iMapper;
            _LabOrderSampleResultRepository = labOrderSampleResultRepository;
        }

        public async Task<(bool IsSuccess, IEnumerable<LabOrderSampleResult>, string ErrorMessage)> LoadLabOrderSampleResult()
        {
            IEnumerable<LabOrderSampleResult> lab = new List<LabOrderSampleResult>();
            try
            {
                var labOrderSampleResults = await _LabOrderSampleResultRepository.GetAll().ToListAsync();
                if (labOrderSampleResults == null)
                    return (false, lab, "Record not found");
                return (true, _IMapper.Map<List<LabOrderSampleResult>>(labOrderSampleResults), "Lab order results loaded successfully");
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return (false, lab, $"{e.Message}");
            }
        }

        public async Task<(bool IsSuccess, IEnumerable<LabOrderSampleResult> labOrderSampleResults, string ErrorMessage)> GetLabOrderSampleResult(Guid id)
        {
            IEnumerable<LabOrderSampleResult> lab = new List<LabOrderSampleResult>();
            try
            {
                var labOrderSample = await _LabOrderSampleResultRepository.GetAll(x => x.Id == id).FirstOrDefaultAsync();
                if (labOrderSample == null)
                    return (false, lab, "Record not found");
                return (true, _IMapper.Map<List<LabOrderSampleResult>>(labOrderSample), "Lab order results loaded successfully");
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return (false, lab, $"{e.Message}");
            }
        }

        public async Task<(bool IsSuccess, LabOrderSampleResult labOrderSampleResult, string ErrorMEssage)> AddLabOrderSampleResult(LabOrderSampleResult labOrderSampleResult)
        {
            try
            {
                if (labOrderSampleResult == null)
                    return (false, labOrderSampleResult, "No record found");
                if(labOrderSampleResult.LabOrderSampleId.IsNullOrEmpty())
                    _LabOrderSampleResultRepository.Create(labOrderSampleResult);
                _LabOrderSampleResultRepository.Update(labOrderSampleResult);
                await _LabOrderSampleResultRepository.Save();

                return (true, labOrderSampleResult, "Lab order results created successfully");
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public async Task<(bool IsSuccess, Guid id, string ErrorMessage)> DeleteLabOrderSampleResult(Guid id)
        {
            try
            {
                var labOrderSampleResult = await _LabOrderSampleResultRepository.GetAll(x => x.Id == id).FirstOrDefaultAsync();
                if (labOrderSampleResult == null)
                    return (false, id, "Record not found");
                _LabOrderSampleResultRepository.Delete(labOrderSampleResult);

                return (false, id, "Record deleted successfully.");
            }
            catch (Exception e)
            {
                return (false, id, $"{e.Message}");
            }
        }

        public Task<(bool IsSuccess, LabOrderSampleResult labOrderSampleResult, string ErrorMEssage)> AddLabOrderSampleResut(LabOrderSampleResult labOrderSampleResult)
        {
            throw new NotImplementedException();
        }
    }
}
